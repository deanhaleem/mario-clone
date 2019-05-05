using System;
using System.Collections.Generic;
using System.Reflection;

namespace SuperMarioBrosClone
{
    internal class PlayerBlockCollisionResponder : ICollisionResponder
    {
        private readonly Dictionary<(Type, Type, Type), ConstructorInfo> playerBlockCollisionCommands;

        public void RespondToCollision(ICollidable player, ICollidable block, ICollision collisionSide)
        {
            var collisionType = ((player as IPlayer)?.PowerUpState.GetType(), block.GetType(), collisionSide.GetType());
            if (playerBlockCollisionCommands.ContainsKey(collisionType))
            {
                (playerBlockCollisionCommands[collisionType].Invoke(new object[] { player, block, collisionSide }) as ICommand)?.Execute();
            }
        }

        public PlayerBlockCollisionResponder()
        {
            this.playerBlockCollisionCommands = new Dictionary<(Type, Type, Type), ConstructorInfo>
            {
                { (typeof(SmallPowerUpState), typeof(ItemBrickBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(ItemBrickBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(ItemBrickBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(ItemBrickBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(SmallPowerUpState), typeof(BrickBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(BrickBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(BrickBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(BrickBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(SmallPowerUpState), typeof(BrickCollectionBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(BrickCollectionBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(BrickCollectionBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(BrickCollectionBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(SmallPowerUpState), typeof(HiddenBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpRevealedBlockCommand).GetConstructors()[0] },

                { (typeof(SmallPowerUpState), typeof(NonPowerUpQuestionBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(NonPowerUpQuestionBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(NonPowerUpQuestionBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(NonPowerUpQuestionBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(SmallPowerUpState), typeof(PowerUpQuestionBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(PowerUpQuestionBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(PowerUpQuestionBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(PowerUpQuestionBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(SmallPowerUpState), typeof(FloorBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(FloorBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(FloorBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(FloorBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(SmallPowerUpState), typeof(StairBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(StairBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(StairBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(StairBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(SmallPowerUpState), typeof(UsedBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(UsedBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(UsedBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(UsedBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(SmallPowerUpState), typeof(SmallVerticalGreenPipe), typeof(TopCollision)), typeof(PushPlayerUpNotWarpingCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(SmallVerticalGreenPipe), typeof(BottomCollision)), typeof(PushPlayerDownNotWarpingCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(SmallVerticalGreenPipe), typeof(LeftCollision)), typeof(PushPlayerRightNotWarpingCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(SmallVerticalGreenPipe), typeof(RightCollision)), typeof(PushPlayerLeftNotWarpingCommand).GetConstructors()[0] },

                { (typeof(SmallPowerUpState), typeof(MediumVerticalGreenPipe), typeof(TopCollision)), typeof(PushPlayerUpNotWarpingCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(MediumVerticalGreenPipe), typeof(BottomCollision)), typeof(PushPlayerDownNotWarpingCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(MediumVerticalGreenPipe), typeof(LeftCollision)), typeof(PushPlayerRightNotWarpingCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(MediumVerticalGreenPipe), typeof(RightCollision)), typeof(PushPlayerLeftNotWarpingCommand).GetConstructors()[0] },

                { (typeof(SmallPowerUpState), typeof(LargeVerticalGreenPipe), typeof(TopCollision)), typeof(PushPlayerUpNotWarpingCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(LargeVerticalGreenPipe), typeof(BottomCollision)), typeof(PushPlayerDownNotWarpingCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(LargeVerticalGreenPipe), typeof(LeftCollision)), typeof(PushPlayerRightNotWarpingCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(LargeVerticalGreenPipe), typeof(RightCollision)), typeof(PushPlayerLeftNotWarpingCommand).GetConstructors()[0] },

                { (typeof(SmallPowerUpState), typeof(HorizontalGreenPipe), typeof(TopCollision)), typeof(PushPlayerUpNotWarpingCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(HorizontalGreenPipe), typeof(BottomCollision)), typeof(PushPlayerDownNotWarpingCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(HorizontalGreenPipe), typeof(LeftCollision)), typeof(PushPlayerRightNotWarpingCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(HorizontalGreenPipe), typeof(RightCollision)), typeof(PushPlayerLeftNotWarpingCommand).GetConstructors()[0] },

                { (typeof(SmallPowerUpState), typeof(LargeGreenPipeShaft), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(LargeGreenPipeShaft), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(LargeGreenPipeShaft), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(SmallPowerUpState), typeof(LargeGreenPipeShaft), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(BigPowerUpState), typeof(ItemBrickBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(ItemBrickBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(ItemBrickBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(ItemBrickBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(BigPowerUpState), typeof(BrickBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(BrickBlock), typeof(BottomCollision)), typeof(PushPlayerDownDestroyBlockCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(BrickBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(BrickBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(BigPowerUpState), typeof(BrickCollectionBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(BrickCollectionBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(BrickCollectionBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(BrickCollectionBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(BigPowerUpState), typeof(HiddenBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpRevealedBlockCommand).GetConstructors()[0] },

                { (typeof(BigPowerUpState), typeof(NonPowerUpQuestionBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(NonPowerUpQuestionBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(NonPowerUpQuestionBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(NonPowerUpQuestionBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(BigPowerUpState), typeof(PowerUpQuestionBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(PowerUpQuestionBlock), typeof(BottomCollision)), typeof(PushPlayerDownSpawnFireFlowerCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(PowerUpQuestionBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(PowerUpQuestionBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(BigPowerUpState), typeof(FloorBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(FloorBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(FloorBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(FloorBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(BigPowerUpState), typeof(StairBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(StairBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(StairBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(StairBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(BigPowerUpState), typeof(UsedBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(UsedBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(UsedBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(UsedBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(BigPowerUpState), typeof(SmallVerticalGreenPipe), typeof(TopCollision)), typeof(PushPlayerUpNotWarpingCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(SmallVerticalGreenPipe), typeof(BottomCollision)), typeof(PushPlayerDownNotWarpingCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(SmallVerticalGreenPipe), typeof(LeftCollision)), typeof(PushPlayerRightNotWarpingCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(SmallVerticalGreenPipe), typeof(RightCollision)), typeof(PushPlayerLeftNotWarpingCommand).GetConstructors()[0] },

                { (typeof(BigPowerUpState), typeof(MediumVerticalGreenPipe), typeof(TopCollision)), typeof(PushPlayerUpNotWarpingCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(MediumVerticalGreenPipe), typeof(BottomCollision)), typeof(PushPlayerDownNotWarpingCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(MediumVerticalGreenPipe), typeof(LeftCollision)), typeof(PushPlayerRightNotWarpingCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(MediumVerticalGreenPipe), typeof(RightCollision)), typeof(PushPlayerLeftNotWarpingCommand).GetConstructors()[0] },

                { (typeof(BigPowerUpState), typeof(LargeVerticalGreenPipe), typeof(TopCollision)), typeof(PushPlayerUpNotWarpingCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(LargeVerticalGreenPipe), typeof(BottomCollision)), typeof(PushPlayerDownNotWarpingCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(LargeVerticalGreenPipe), typeof(LeftCollision)), typeof(PushPlayerRightNotWarpingCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(LargeVerticalGreenPipe), typeof(RightCollision)), typeof(PushPlayerLeftNotWarpingCommand).GetConstructors()[0] },

                { (typeof(BigPowerUpState), typeof(HorizontalGreenPipe), typeof(TopCollision)), typeof(PushPlayerUpNotWarpingCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(HorizontalGreenPipe), typeof(BottomCollision)), typeof(PushPlayerDownNotWarpingCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(HorizontalGreenPipe), typeof(LeftCollision)), typeof(PushPlayerRightNotWarpingCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(HorizontalGreenPipe), typeof(RightCollision)), typeof(PushPlayerLeftNotWarpingCommand).GetConstructors()[0] },

                { (typeof(BigPowerUpState), typeof(LargeGreenPipeShaft), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(LargeGreenPipeShaft), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(LargeGreenPipeShaft), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(BigPowerUpState), typeof(LargeGreenPipeShaft), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(FirePowerUpState), typeof(ItemBrickBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(ItemBrickBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(ItemBrickBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(ItemBrickBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(FirePowerUpState), typeof(BrickBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(BrickBlock), typeof(BottomCollision)), typeof(PushPlayerDownDestroyBlockCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(BrickBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(BrickBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(FirePowerUpState), typeof(BrickCollectionBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(BrickCollectionBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(BrickCollectionBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(BrickCollectionBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(FirePowerUpState), typeof(HiddenBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpRevealedBlockCommand).GetConstructors()[0] },

                { (typeof(FirePowerUpState), typeof(NonPowerUpQuestionBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(NonPowerUpQuestionBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(NonPowerUpQuestionBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(NonPowerUpQuestionBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(FirePowerUpState), typeof(PowerUpQuestionBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(PowerUpQuestionBlock), typeof(BottomCollision)), typeof(PushPlayerDownSpawnFireFlowerCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(PowerUpQuestionBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(PowerUpQuestionBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(FirePowerUpState), typeof(FloorBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(FloorBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(FloorBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(FloorBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(FirePowerUpState), typeof(StairBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(StairBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(StairBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(StairBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(FirePowerUpState), typeof(UsedBlock), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(UsedBlock), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(UsedBlock), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(UsedBlock), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] },

                { (typeof(FirePowerUpState), typeof(SmallVerticalGreenPipe), typeof(TopCollision)), typeof(PushPlayerUpNotWarpingCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(SmallVerticalGreenPipe), typeof(BottomCollision)), typeof(PushPlayerDownNotWarpingCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(SmallVerticalGreenPipe), typeof(LeftCollision)), typeof(PushPlayerRightNotWarpingCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(SmallVerticalGreenPipe), typeof(RightCollision)), typeof(PushPlayerLeftNotWarpingCommand).GetConstructors()[0] },

                { (typeof(FirePowerUpState), typeof(MediumVerticalGreenPipe), typeof(TopCollision)), typeof(PushPlayerUpNotWarpingCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(MediumVerticalGreenPipe), typeof(BottomCollision)), typeof(PushPlayerDownNotWarpingCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(MediumVerticalGreenPipe), typeof(LeftCollision)), typeof(PushPlayerRightNotWarpingCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(MediumVerticalGreenPipe), typeof(RightCollision)), typeof(PushPlayerLeftNotWarpingCommand).GetConstructors()[0] },

                { (typeof(FirePowerUpState), typeof(LargeVerticalGreenPipe), typeof(TopCollision)), typeof(PushPlayerUpNotWarpingCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(LargeVerticalGreenPipe), typeof(BottomCollision)), typeof(PushPlayerDownNotWarpingCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(LargeVerticalGreenPipe), typeof(LeftCollision)), typeof(PushPlayerRightNotWarpingCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(LargeVerticalGreenPipe), typeof(RightCollision)), typeof(PushPlayerLeftNotWarpingCommand).GetConstructors()[0] },

                { (typeof(FirePowerUpState), typeof(HorizontalGreenPipe), typeof(TopCollision)), typeof(PushPlayerUpNotWarpingCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(HorizontalGreenPipe), typeof(BottomCollision)), typeof(PushPlayerDownNotWarpingCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(HorizontalGreenPipe), typeof(LeftCollision)), typeof(PushPlayerRightNotWarpingCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(HorizontalGreenPipe), typeof(RightCollision)), typeof(PushPlayerLeftNotWarpingCommand).GetConstructors()[0] },

                { (typeof(FirePowerUpState), typeof(LargeGreenPipeShaft), typeof(TopCollision)), typeof(PushPlayerUpCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(LargeGreenPipeShaft), typeof(BottomCollision)), typeof(PushPlayerDownBumpBlockCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(LargeGreenPipeShaft), typeof(LeftCollision)), typeof(PushPlayerRightCommand).GetConstructors()[0] },
                { (typeof(FirePowerUpState), typeof(LargeGreenPipeShaft), typeof(RightCollision)), typeof(PushPlayerLeftCommand).GetConstructors()[0] }
            };
        }
    }
}
