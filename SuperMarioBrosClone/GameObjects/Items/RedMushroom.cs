using Microsoft.Xna.Framework;
using SuperMarioBrosClone.GameObjects.Items.States;

namespace SuperMarioBrosClone.GameObjects.Items
{
    internal class RedMushroom : SpawningItem
    {
        public RedMushroom(Vector2 location, Color color) : base(location, color, typeof(MovingItemState))
        {

        }
    }
}
