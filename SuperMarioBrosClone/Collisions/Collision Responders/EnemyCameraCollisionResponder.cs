using System;
using System.Collections.Generic;
using System.Reflection;

namespace SuperMarioBrosClone
{
    internal class EnemyCameraCollisionResponder : ICollisionResponder
    {
        private readonly Dictionary<Type, ConstructorInfo> enemyCameraCollisionCommands;

        public void RespondToCollision(ICollidable enemy, ICollidable camera, ICollision collision)
        {
            if (enemyCameraCollisionCommands.ContainsKey(collision.GetType()))
            {
                (enemyCameraCollisionCommands[collision.GetType()].Invoke(new object[] { enemy }) as ICommand)?.Execute();
            }
        }

        public EnemyCameraCollisionResponder()
        {
            this.enemyCameraCollisionCommands = new Dictionary<Type, ConstructorInfo>
            {
                { typeof(RightCollision), typeof(RightEnemyCameraCollisionCommand).GetConstructors()[0] }
            };
        }
    }
}
