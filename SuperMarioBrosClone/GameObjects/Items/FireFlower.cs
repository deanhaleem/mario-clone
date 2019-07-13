using Microsoft.Xna.Framework;
using SuperMarioBrosClone.GameObjects.Items.States;

namespace SuperMarioBrosClone.GameObjects.Items
{
    internal class FireFlower : SpawningItem
    {
        public FireFlower(Vector2 location, Color color) : base(location, color, typeof(IdleItemState))
        {

        }
    }
}
