using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SuperMarioBrosClone.Collisions.Responders;
using SuperMarioBrosClone.Display;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.GameObjects.Blocks;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.Collisions
{
    internal class CollisionSecretary
    {
        private readonly ICollisionManager collisionManager;
        private Collection<IRigidBody> movingGameObjects;
        private Collection<IGameObject> stationaryGameObjects;

        public CollisionSecretary(ICollisionManager collisionManager)
        {
            this.collisionManager = collisionManager;
        }

        public static Dictionary<(Type, Type), ICollisionResponder> LoadCollisionResponders()
        {
            return new Dictionary<(Type, Type), ICollisionResponder>
            {
                { (typeof(IPlayer), typeof(IBlock)), new PlayerBlockCollisionResponder() },
                { (typeof(IPlayer), typeof(IEnemy)), new PlayerEnemyCollisionResponder() },
                { (typeof(IPlayer), typeof(IItem)), new PlayerItemCollisionResponder() },
                { (typeof(IPlayer), typeof(IPipe)), new PlayerWarpPipeCollisionResponder() },

                { (typeof(IEnemy), typeof(IBlock)), new EnemyBlockCollisionResponder() },
                { (typeof(IEnemy), typeof(IEnemy)), new EnemyEnemyCollisionResponder() },
                { (typeof(IEnemy), typeof(IProjectile)), new EnemyProjectileCollisionResponder() },
                { (typeof(IEnemy), typeof(IPlayer)), new PlayerEnemyCollisionResponder() },

                { (typeof(IItem), typeof(IBlock)), new ItemBlockCollisionResponder() },
                { (typeof(IItem), typeof(IPlayer)), new PlayerItemCollisionResponder() },

                { (typeof(IPlayer), typeof(ICamera)),  new PlayerCameraCollisionResponder() },
                { (typeof(IEnemy), typeof(ICamera)),  new EnemyCameraCollisionResponder() },

                { (typeof(IProjectile), typeof(IBlock)), new ProjectileBlockCollisionResponder() },
                { (typeof(IProjectile), typeof(IEnemy)), new EnemyProjectileCollisionResponder() }
            };
        }

        public void SchedulePotentialCollisions(Collection<IGameObject> gameObjects)
        {
            movingGameObjects = new Collection<IRigidBody>();
            stationaryGameObjects = new Collection<IGameObject>();

            foreach (var gameObject in gameObjects)
            {
                if (gameObject is IRigidBody rigidBody)
                {
                    movingGameObjects.Add(rigidBody);
                }
                else
                {
                    stationaryGameObjects.Add(gameObject);
                }
            }
        }

        public void ManageCollisions(ICamera camera)
        {
            for (int i = 0; i < movingGameObjects.Count; i++)
            {
                for (int j = i + 1; j < movingGameObjects.Count; j++)
                {
                    if (movingGameObjects[i].HitBox.Intersects(movingGameObjects[j].HitBox))
                    {
                        collisionManager.ManageCollisions(movingGameObjects[i], movingGameObjects[j]);
                    }
                }

                var blocksIntersecting = new Collection<IGameObject>();
                var blocksOnTopOf = new Collection<IGameObject>();
                foreach (var stationaryGameObject in stationaryGameObjects)
                {
                    if (movingGameObjects[i].HitBox.Intersects(stationaryGameObject.HitBox))
                    {
                        blocksIntersecting.Add(stationaryGameObject);
                    }

                    if (movingGameObjects[i].ExtendedHitBox.Intersects(stationaryGameObject.HitBox) && !(stationaryGameObject is HiddenBlock))
                    {
                        blocksOnTopOf.Add(stationaryGameObject);
                    }
                }

                if (movingGameObjects[i] is IPlayer player)
                {
                    foreach (var gameObject in blocksIntersecting)
                    {
                        if (gameObject is IPipe pipe)
                        {
                            collisionManager.ManagePlayerPipeCollisions(player, pipe);
                        }
                    }

                    foreach (var gameObject in blocksOnTopOf)
                    {
                        if (gameObject is IPipe pipe)
                        {
                            collisionManager.ManagePlayerPipeCollisions(player, pipe);
                        }
                    }
                }

                if (blocksIntersecting.Count == Utilities.MaxIntersectingBlocks)
                {
                    collisionManager.ManageBlockCollisions(movingGameObjects[i], blocksIntersecting);
                }
                else if (blocksIntersecting.Count == Utilities.NormalIntersectingBlocks)
                {

                    collisionManager.ManageCollisions(movingGameObjects[i], blocksIntersecting[0]);
                }

                if (blocksOnTopOf.Count == 0)
                {
                    movingGameObjects[i].Fall();
                }

                if (movingGameObjects[i].HitBox.Intersects(camera.HitBox))
                {
                    collisionManager.ManageCameraCollisions(movingGameObjects[i], camera);
                }
            }
        }
    }
}
