using Microsoft.Xna.Framework;
using SuperMarioBrosClone.GameObjects.Items.States;

namespace SuperMarioBrosClone.GameObjects.Items
{
    internal class GreenMushroom : SpawningItem
    {
        public GreenMushroom(Vector2 location, Color color) : base(location, color, typeof(MovingItemState))
        {

        }
    }
}
