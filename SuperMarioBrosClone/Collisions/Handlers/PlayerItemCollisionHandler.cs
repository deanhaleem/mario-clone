using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Audio;
using SuperMarioBrosClone.GameObjects.Items;
using SuperMarioBrosClone.GameObjects.Players;
using SuperMarioBrosClone.GameStates;
using SuperMarioBrosClone.Statistics;
using SuperMarioBrosClone.Utility;
using System.Reflection;
using SuperMarioBrosClone.GameObjects;

namespace SuperMarioBrosClone.Collisions.Handlers
{
    internal class PlayerItemCollisionHandler
    {
        private readonly IPlayer player;
        private readonly IItem item;
        private readonly ICollision collision;

        public PlayerItemCollisionHandler(IPlayer player, IItem item, ICollision collision)
        {
            this.player = player;
            this.item = item;
            this.collision = collision;
        }

        public void HandlePlayerFireFlowerCollision()
        {
            player.Upgrade();
            Game1.Instance.DisposeOfObject(item);

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
        }

        public void HandlePlayerGreenMushroomCollision()
        {
            Game1.Instance.DisposeOfObject(item);

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
            StatManager.Instance.GainOrLoseLife(true);
            SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
        }

        public void HandlePlayerRedMushroomCollision()
        {
            player.Upgrade();
            Game1.Instance.DisposeOfObject(item);

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
        }

        public void HandlePlayerNonSpinningCoinCollision()
        {
            Game1.Instance.DisposeOfObject(item);

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
            StatManager.Instance.GainCoin();
            SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
        }

        public void HandlePlayerStarCollision()
        {
            Game1.Instance.Player = new StarMario(player);
            player.Decorate();
            Game1.Instance.DisposeOfObject(item);

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
        }

        public void HandleNonUpgradingPlayerPowerUpCollision()
        {
            Game1.Instance.DisposeOfObject(item);

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
        }

        public void HandleBlinkingPlayerRedMushroomCollision()
        {
            (player as PlayerDecorator)?.RemoveDecorator();
            player.Upgrade();
            Game1.Instance.DisposeOfObject(item);

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
        }

        public void HandleBlinkingPlayerFireFlowerCollision()
        {
            (player as PlayerDecorator)?.RemoveDecorator();
            player.Upgrade();
            Game1.Instance.DisposeOfObject(item);

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
        }

        public void HandleBlinkingPlayerStarCollision()
        {
            (player as PlayerDecorator)?.RemoveDecorator();
            Game1.Instance.Player = new StarMario(Game1.Instance.Player);
            player.Decorate();
            Game1.Instance.DisposeOfObject(item);

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
        }

        public void HandlePlayerFlagpoleCollision()
        {
            if (!(Game1.Instance.GameState is VictoryGameState))
            {
                (player as PlayerDecorator)?.RemoveDecorator();
                player.WinLevel();
                player.ApplyImpulse(Physics.SlideDownFlagImpulse);
                item.Fall();
                Game1.Instance.EndLevel();

                StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
            }
        }

        public void HandlePlayerCastleDoorCollision()
        {
            player.Location = new Vector2(player.Location.X, -player.Location.Y);
            player.WinLevel();
            Game1.Instance.TallyUp();
        }
    }
}
