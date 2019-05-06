using System;
using System.Collections.Generic;
using System.Reflection;

namespace SuperMarioBrosClone
{
    internal class EnemyEnemyCollisionResponder : ICollisionResponder
    {
        private readonly Dictionary<(Type, Type, Type), ConstructorInfo> enemyEnemyCollisionCommands;

        public void RespondToCollision(ICollidable instigatingEnemy, ICollidable receivingEnemy, ICollision collision)
        {
            var collisionType = ((instigatingEnemy as IEnemy)?.EnemyState.GetType(),
                (receivingEnemy as IEnemy)?.EnemyState.GetType(), collision.GetType());
            if (enemyEnemyCollisionCommands.ContainsKey(collisionType))
            {
                (enemyEnemyCollisionCommands[collisionType]
                    .Invoke(new object[] {instigatingEnemy, receivingEnemy, collision}) as ICommand)?.Execute();
            }
        }

        public EnemyEnemyCollisionResponder()
        {
            this.enemyEnemyCollisionCommands = new Dictionary<(Type, Type, Type), ConstructorInfo>
            {
                { (typeof(WalkingEnemyState), typeof(WalkingEnemyState), typeof(TopCollision)), typeof(PushEnemyDownOtherUpCommand).GetConstructors()[0] },
                { (typeof(WalkingEnemyState), typeof(WalkingEnemyState), typeof(BottomCollision)), typeof(PushEnemyUpOtherDownCommand).GetConstructors()[0] },
                { (typeof(WalkingEnemyState), typeof(WalkingEnemyState), typeof(LeftCollision)), typeof(PushEnemyRightOtherLeftCommand).GetConstructors()[0] },
                { (typeof(WalkingEnemyState), typeof(WalkingEnemyState), typeof(RightCollision)), typeof(PushEnemyLeftOtherRightCommand).GetConstructors()[0] },

                { (typeof(WalkingEnemyState), typeof(ShellEnemyState), typeof(TopCollision)), typeof(PushEnemyDownOtherUpCommand).GetConstructors()[0] },
                { (typeof(WalkingEnemyState), typeof(ShellEnemyState), typeof(BottomCollision)), typeof(PushEnemyUpOtherDownCommand).GetConstructors()[0] },
                { (typeof(WalkingEnemyState), typeof(ShellEnemyState), typeof(LeftCollision)), typeof(PushRightOrKillEnemyCommand).GetConstructors()[0] },
                { (typeof(WalkingEnemyState), typeof(ShellEnemyState), typeof(RightCollision)), typeof(PushLeftOrKillEnemyCommand).GetConstructors()[0] },

                { (typeof(SleepingEnemyState), typeof(ShellEnemyState), typeof(TopCollision)), typeof(PushEnemyDownOtherUpCommand).GetConstructors()[0] },
                { (typeof(SleepingEnemyState), typeof(ShellEnemyState), typeof(BottomCollision)), typeof(PushEnemyUpOtherDownCommand).GetConstructors()[0] },
                { (typeof(SleepingEnemyState), typeof(ShellEnemyState), typeof(LeftCollision)), typeof(PushRightOrKillEnemyCommand).GetConstructors()[0] },
                { (typeof(SleepingEnemyState), typeof(ShellEnemyState), typeof(RightCollision)), typeof(PushLeftOrKillEnemyCommand).GetConstructors()[0] }
            };
        }
    }
}
