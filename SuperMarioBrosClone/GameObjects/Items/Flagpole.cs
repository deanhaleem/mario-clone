using Microsoft.Xna.Framework;
using SuperMarioBrosClone.GameObjects.Items.States;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Items
{
    internal class Flagpole : Item
    {
        private bool canUpdate;

        public override Rectangle HitBox => new Rectangle(base.HitBox.X + Offsets.FlagpoleWidthOffset, base.HitBox.Y,
            base.HitBox.Width, base.HitBox.Height);

        public Flagpole(Vector2 location, Color color) : base(location, color)
        {
            base.ItemState = new IdleItemState(this);
        }

        public override void Update(GameTime gameTime)
        {
            if (canUpdate)
            {
                base.Update(gameTime);
            }
        }

        public override void Fall()
        {
            if (!canUpdate)
            {
                TimedActionManager.Instance.RegisterTimedAction(null, StopFlagFall, Timers.FlagFallTimer);
            }
            canUpdate = true;
        }

        private void StopFlagFall()
        {
            canUpdate = false;
        }
    }
}
