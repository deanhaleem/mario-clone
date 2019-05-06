using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrosClone
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private ILevel level;
        private ICollisionManager collisionManager;
        private IHud hud;

        public bool IsShowingRectangles { get; private set; }
        public IGameState GameState { get; set; }
        public ICamera Camera { get; private set; }
        public Point ScreenSize { get; private set; }
        public string LevelName => level.Name;

        public IPlayer Player { get => level.Player; set => level.Player = value; }

        public static Game1 Instance { get; } = new Game1();

        private Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            ScreenSize = new Point(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            level = new Level();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Instance.LoadContent("Content/Textures.json", "Content/SpriteRegistrars.json", "Content/Sprites.json", "Fonts/Emulogic");
            SoundManager.Instance.LoadContent("Content/SoundEffects.json", "Content/SoundEffectNames.json", "Content/Songs.json");
            StatManager.Instance.LoadContent(new ScoreKeeper("Content/Points.json", "Content/PointAllocators.json"), new LifeKeeper(3), new CoinKeeper(), new Timer(400));
            level.LoadContent("Content/1-1.json");
            HardReset();
            GameState = new PlayingGameState(this, level);
            hud = new Hud(ScreenSize);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            GameState.Update(gameTime);
            collisionManager.Update(Camera);
            hud.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Player.Location.X < 10000 ? new Color(146, 144, 255) : Color.Black);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, transformMatrix: Camera.Transform);
            GameState.Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp);
            hud.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ToggleRectangles()
        {
            IsShowingRectangles = !IsShowingRectangles;
        }

        public void EndLevel()
        {
            GameState.EndLevel();
        }

        public void Pause()
        {
            GameState.Pause();
        }

        public void Transition()
        {
            GameState.Transition();
        }

        public void Die()
        {
            GameState.Die();
        }

        public void Warp()
        {
            GameState.Warp();
        }

        public void Warp(Vector2 location)
        {
            GameState.Warp(location);
        }

        public void TallyUp()
        {
            GameState.TallyUp();
        }

        public void DisposeOfObject(IGameObject gameObject)
        {
            level.DisposeOfGameObject(gameObject);
        }

        public void RegisterGameObject(IGameObject gameObject)
        {
            level.RegisterGameObject(gameObject);
        }

        public void UnregisterGameObject(IGameObject gameObject)
        {
            level.UnregisterGameObject(gameObject);
        }

        public void SoftReset()
        {
            SoundManager.Instance.StopSong();

            level.Reset();
            TimedActionManager.Instance.Reset();
            StatManager.Instance.SoftReset();
            collisionManager = new CollisionManager(level);
            Camera = new Camera(new Vector2(), ScreenSize);
            GameState = new PlayingGameState(this, level);
        }

        public void HardReset()
        {
            SoundManager.Instance.StopSong();

            level.Reset();
            TimedActionManager.Instance.Reset();
            StatManager.Instance.HardReset();
            collisionManager = new CollisionManager(level);
            Camera = new Camera(new Vector2(), ScreenSize);
            GameState = new PlayingGameState(this, level);
        }
    }
}
