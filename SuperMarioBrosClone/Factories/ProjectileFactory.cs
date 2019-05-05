using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SuperMarioBrosClone
{
    internal class ProjectileFactory
    {
        public static ProjectileFactory Instance { get; } = new ProjectileFactory();

        private readonly Dictionary<Type, Func<object[], object>> projectileCreators = new Dictionary<Type, Func<object[], object>>
        {
            { typeof(Fireball), typeof(Fireball).GetConstructors()[0].Invoke }
        };

        private ProjectileFactory()
        {

        }

        public void CreateRightProjectile(Type projectileType, Rectangle spawnArea)
        {
            Game1.Instance.RegisterGameObject(projectileCreators[projectileType](new object[]
                {new Vector2(spawnArea.Right, spawnArea.Top + spawnArea.Height / 2), Color.White, Physics.RightProjectileVelocity}) as IProjectile);

            SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
        }

        public void CreateLeftProjectile(Type projectileType, Rectangle spawnArea)
        {
            Game1.Instance.RegisterGameObject(projectileCreators[projectileType](new object[]
                {new Vector2(spawnArea.Left, spawnArea.Top + spawnArea.Height / 2), Color.White, Physics.LeftProjectileVelocity}) as IProjectile);

            SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
        }
    }
}
