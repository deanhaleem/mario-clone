using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Blocks.States
{
    internal class DestroyedBlockState : BlockState
    {
        public DestroyedBlockState(IBlock block) : base(block)
        {
            base.Block.SetSprite(GetType().Name);

            BlockFactory.CreateDebris(Block.Location);
            TimedActionManager.Instance.RegisterTimedAction(PlayBumpAnimation, DisposeOfBlock, Timers.BlockDestroyTimer);
        }

        private void PlayBumpAnimation(float elapsedTime)
        {
            if (elapsedTime < Timers.BlockDestroyTimer / 2f)
            {
                Block.Location += -Physics.BlockBumpVelocity;
            }
        }

        private void DisposeOfBlock()
        {
            Game1.Instance.DisposeOfObject(Block);
        }
    }
}
