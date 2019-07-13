using Microsoft.Xna.Framework;
using SuperMarioBrosClone.GameObjects.Items.States;

namespace SuperMarioBrosClone.GameObjects.Items
{
    internal class Star : SpawningItem
    {
        public Star(Vector2 location, Color color) : base(location, color, typeof(BouncingItemState))
        {

        }

        public override void Land()
        {
            ItemState.Land();
        }

        public override void Fall() { }
    }
}
