using System;
using System.Reflection;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Blocks.States
{
    internal class BumpedBlockState : BlockState
    {
        private readonly ConstructorInfo postBumpBlockState;

        public BumpedBlockState(IBlock block, Type blockStateType) : base(block)
        {
            this.postBumpBlockState = blockStateType.GetConstructors()[0];
            base.Block.SetSprite(blockStateType.Name);

            TimedActionManager.Instance.RegisterTimedAction(PlayBumpAnimation, SetToStateAfterBump, Timers.BlockBumpTimer);
        }

        private void PlayBumpAnimation(float elapsedTime)
        {
            Block.Location += elapsedTime < Timers.BlockBumpTimer / 2f ? Physics.BlockBumpVelocity : -Physics.BlockBumpVelocity;
        }

        private void SetToStateAfterBump()
        {
            Block.BlockState = postBumpBlockState.Invoke(new object[] { Block }) as IBlockState;
        }
    }
}
