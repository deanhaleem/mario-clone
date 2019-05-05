using System;
using System.Collections.Generic;
using System.Reflection;

namespace SuperMarioBrosClone
{
    internal class ProjectileBlockCollisionResponder : ICollisionResponder
    {
        private readonly Dictionary<Type, ConstructorInfo> projectileBlockCollisionCommands;

        public void RespondToCollision(ICollidable projectile, ICollidable block, ICollision collision)
        {
            (projectileBlockCollisionCommands[collision.GetType()].Invoke(new object[] {projectile, collision}) as ICommand)?.Execute();
        }

        public ProjectileBlockCollisionResponder()
        {
            this.projectileBlockCollisionCommands = new Dictionary<Type, ConstructorInfo>
            {
                { typeof(TopCollision), typeof(PushProjectileUpCommand).GetConstructors()[0] },
                { typeof(BottomCollision), typeof(PushProjectileDownCommand).GetConstructors()[0] },
                { typeof(LeftCollision), typeof(PushRightExplodeProjectileCommand).GetConstructors()[0] },
                { typeof(RightCollision), typeof(PushLeftExplodeProjectileCommand).GetConstructors()[0] }
            };
        }
    }
}
