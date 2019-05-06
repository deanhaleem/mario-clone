using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrosClone
{
    internal abstract class GameObject : IGameObject
    {
        private readonly Color gameObjectColor;
        private ISprite gameObjectSprite;

        protected virtual string SpriteName => GetType().Name;

        public Vector2 Location { get; set; }

        public virtual Rectangle HitBox
        {
            get
            {
                int xRectangleLocation = (int)Location.X - gameObjectSprite.Size.X / 2;
                int yRectangleLocation = (int)Location.Y - gameObjectSprite.Size.Y;
                return new Rectangle(xRectangleLocation, yRectangleLocation, gameObjectSprite.Size.X, gameObjectSprite.Size.Y);
            }
        }

        protected GameObject(Vector2 location, Color color)
        {
            this.Location = location;
            this.gameObjectColor = color;
        }

        public virtual void Update(GameTime gameTime)
        {
            gameObjectSprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            gameObjectSprite.Draw(spriteBatch, Location, gameObjectColor);
        }

        public virtual void SetSprite(string spriteName)
        {
            gameObjectSprite = SpriteFactory.Instance.CreateSprite(spriteName);
        }

        protected virtual void SetSprite()
        {
            gameObjectSprite = SpriteFactory.Instance.CreateSprite(SpriteName);
        }
    }
}
