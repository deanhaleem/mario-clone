﻿using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Audio;
using SuperMarioBrosClone.GameObjects.Items.States;
using SuperMarioBrosClone.Statistics;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Items
{
    internal class SpinningCoin : Item
    {
        public SpinningCoin(Vector2 location, Color color) : base(location, color)
        {
            base.ItemState = new IdleItemState(this);
            base.ApplyImpulse(Physics.SpinningCoinImpulse);
            base.ApplyForce(Physics.GravitationalForce);
            base.SetMaxVelocity(Physics.MaxSpinningCoinVelocity);

            StatManager.Instance.GainPoints(Rectangle.Empty, GetType().Name);
            StatManager.Instance.GainCoin();
            SoundManager.Instance.PlaySoundEffect(GetType().Name);
        }

        public override void Update(GameTime gameTime)
        {
            if (Velocity.Y >= Physics.MaxSpinningCoinVelocity.Y)
            {
                Game1.Instance.DisposeOfObject(this);
            }
            base.Update(gameTime);
        }
    }
}
