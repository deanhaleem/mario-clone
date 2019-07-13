using System;
using System.Collections.Generic;
using System.Reflection;
using SuperMarioBrosClone.Collisions.Commands.Enemy;
using SuperMarioBrosClone.Input;

namespace SuperMarioBrosClone.Collisions.Responders
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
