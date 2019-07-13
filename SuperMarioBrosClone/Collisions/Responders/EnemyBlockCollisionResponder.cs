using System;
using System.Collections.Generic;
using System.Reflection;
using SuperMarioBrosClone.Collisions.Commands.Enemy;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.GameObjects.Blocks;
using SuperMarioBrosClone.Input;

namespace SuperMarioBrosClone.Collisions.Responders
{
    internal class EnemyBlockCollisionResponder : ICollisionResponder
    {
        private readonly Dictionary<(Type, Type, Type), ConstructorInfo> enemyBlockCollisionCommands;

        public void RespondToCollision(ICollidable enemy, ICollidable block, ICollision collision)
        {
            int indexOfEnemyType = typeof(KinematicGameObject).GetInterfaces().Length;
            var collisionType = (enemy.GetType().GetInterfaces()[indexOfEnemyType], block.GetType(), collision.GetType());
            if (enemyBlockCollisionCommands.ContainsKey(collisionType))
            {
                (enemyBlockCollisionCommands[collisionType].Invoke(new object[] { enemy, block, collision }) as ICommand)?.Execute();
            }
        }

        public EnemyBlockCollisionResponder()
        {
            this.enemyBlockCollisionCommands = new Dictionary<(Type, Type, Type), ConstructorInfo>
            {
                { (typeof(IEnemy), typeof(ItemBrickBlock), typeof(TopCollision)), typeof(PushEnemyUpCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(ItemBrickBlock), typeof(BottomCollision)), typeof(PushEnemyDownCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(ItemBrickBlock), typeof(LeftCollision)), typeof(PushEnemyRightCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(ItemBrickBlock), typeof(RightCollision)), typeof(PushEnemyLeftCommand).GetConstructors()[0] },

                { (typeof(IEnemy), typeof(BrickBlock), typeof(TopCollision)), typeof(PushEnemyUpCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(BrickBlock), typeof(BottomCollision)), typeof(PushEnemyDownCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(BrickBlock), typeof(LeftCollision)), typeof(PushEnemyRightCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(BrickBlock), typeof(RightCollision)), typeof(PushEnemyLeftCommand).GetConstructors()[0] },

                { (typeof(IEnemy), typeof(NonPowerUpQuestionBlock), typeof(TopCollision)), typeof(PushEnemyUpCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(NonPowerUpQuestionBlock), typeof(BottomCollision)), typeof(PushEnemyDownCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(NonPowerUpQuestionBlock), typeof(LeftCollision)), typeof(PushEnemyRightCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(NonPowerUpQuestionBlock), typeof(RightCollision)), typeof(PushEnemyLeftCommand).GetConstructors()[0] },

                { (typeof(IEnemy), typeof(PowerUpQuestionBlock), typeof(TopCollision)), typeof(PushEnemyUpCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(PowerUpQuestionBlock), typeof(BottomCollision)), typeof(PushEnemyDownCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(PowerUpQuestionBlock), typeof(LeftCollision)), typeof(PushEnemyRightCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(PowerUpQuestionBlock), typeof(RightCollision)), typeof(PushEnemyLeftCommand).GetConstructors()[0] },

                { (typeof(IEnemy), typeof(FloorBlock), typeof(TopCollision)), typeof(PushEnemyUpCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(FloorBlock), typeof(BottomCollision)), typeof(PushEnemyDownCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(FloorBlock), typeof(LeftCollision)), typeof(PushEnemyRightCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(FloorBlock), typeof(RightCollision)), typeof(PushEnemyLeftCommand).GetConstructors()[0] },

                { (typeof(IEnemy), typeof(StairBlock), typeof(TopCollision)), typeof(PushEnemyUpCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(StairBlock), typeof(BottomCollision)), typeof(PushEnemyDownCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(StairBlock), typeof(LeftCollision)), typeof(PushEnemyRightCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(StairBlock), typeof(RightCollision)), typeof(PushEnemyLeftCommand).GetConstructors()[0] },

                { (typeof(IEnemy), typeof(UsedBlock), typeof(TopCollision)), typeof(PushEnemyUpCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(UsedBlock), typeof(BottomCollision)), typeof(PushEnemyDownCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(UsedBlock), typeof(LeftCollision)), typeof(PushEnemyRightCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(UsedBlock), typeof(RightCollision)), typeof(PushEnemyLeftCommand).GetConstructors()[0] },

                { (typeof(IEnemy), typeof(SmallVerticalGreenPipe), typeof(TopCollision)), typeof(PushEnemyUpCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(SmallVerticalGreenPipe), typeof(BottomCollision)), typeof(PushEnemyDownCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(SmallVerticalGreenPipe), typeof(LeftCollision)), typeof(PushEnemyRightCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(SmallVerticalGreenPipe), typeof(RightCollision)), typeof(PushEnemyLeftCommand).GetConstructors()[0] },

                { (typeof(IEnemy), typeof(MediumVerticalGreenPipe), typeof(TopCollision)), typeof(PushEnemyUpCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(MediumVerticalGreenPipe), typeof(BottomCollision)), typeof(PushEnemyDownCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(MediumVerticalGreenPipe), typeof(LeftCollision)), typeof(PushEnemyRightCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(MediumVerticalGreenPipe), typeof(RightCollision)), typeof(PushEnemyLeftCommand).GetConstructors()[0] },

                { (typeof(IEnemy), typeof(LargeVerticalGreenPipe), typeof(TopCollision)), typeof(PushEnemyUpCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(LargeVerticalGreenPipe), typeof(BottomCollision)), typeof(PushEnemyDownCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(LargeVerticalGreenPipe), typeof(LeftCollision)), typeof(PushEnemyRightCommand).GetConstructors()[0] },
                { (typeof(IEnemy), typeof(LargeVerticalGreenPipe), typeof(RightCollision)), typeof(PushEnemyLeftCommand).GetConstructors()[0] }
            };
        }
    }
}
