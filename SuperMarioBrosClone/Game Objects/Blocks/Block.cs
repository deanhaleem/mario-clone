using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal abstract class Block : GameObject, IBlock
    {
        public IBlockState BlockState { get; set; }

        protected Block(Vector2 location, Color color) : base(location, color)
        {
            base.SetSprite();
        }

        public override void Update(GameTime gameTime)
        {
            BlockState.Update(gameTime);

            base.Update(gameTime);
        }

        public virtual void Bump()
        {
            BlockState.Bump();
        }

        public virtual void Destroy()
        {
            BlockState.Destroy();
        }
    }
}
