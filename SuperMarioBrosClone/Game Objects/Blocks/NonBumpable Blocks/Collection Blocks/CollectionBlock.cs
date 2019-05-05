using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrosClone
{
    internal abstract class CollectionBlock : NonBumpableBlock
    {
        private readonly int blocksInRow;
        private readonly int blocksInColumn;

        public override Rectangle HitBox => new Rectangle(base.HitBox.X, base.HitBox.Y, base.HitBox.Width * blocksInRow,
            base.HitBox.Height * blocksInColumn);

        protected CollectionBlock(Vector2 location, Color color, Point size) : base(location, color)
        {
            this.blocksInRow = size.X;
            this.blocksInColumn = size.Y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 initialLocation = Location;
            for (int i = 0; i < blocksInColumn; i++)
            {
                for (int j = 0; j < blocksInRow; j++)
                {
                    base.Draw(spriteBatch);
                    Location += new Vector2(Offsets.TileOffset, 0);
                }
                Location = new Vector2(initialLocation.X, initialLocation.Y + Offsets.TileOffset * (i + 1));
            }
            Location = initialLocation;
        }
    }
}
