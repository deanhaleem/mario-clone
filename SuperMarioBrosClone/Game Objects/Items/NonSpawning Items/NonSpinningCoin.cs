using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class NonSpinningCoin : Item
    {
        public NonSpinningCoin(Vector2 location, Color color) : base(location, color)
        {
            base.ItemState = new IdleItemState(this);
        }

        public override void Fall() { }
    }
}
