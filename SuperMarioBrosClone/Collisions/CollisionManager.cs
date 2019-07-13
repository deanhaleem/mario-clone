using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SuperMarioBrosClone.Display;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Levels;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.Collisions
{
    internal class CollisionManager : ICollisionManager
    {
        private readonly Dictionary<(Type, Type), ICollisionResponder> collisionResponders;
        private readonly CollisionSecretary collisionSecretary;
        private readonly ILevel level;

        public CollisionManager(ILevel level)
        {
            this.collisionResponders = CollisionSecretary.LoadCollisionResponders();
            this.collisionSecretary = new CollisionSecretary(this);
            this.level = level;
        }

        public void Update(ICamera camera)
        {
            collisionSecretary.SchedulePotentialCollisions(level.GetObjectsOnScreen(camera.HitBox));
            collisionSecretary.ManageCollisions(camera);
        }

        public void ManageCollisions(IRigidBody collisionInstigator, ICollidable collisionReceiver)
        {
            var collision = Collisions.DetectCollision(collisionInstigator, collisionReceiver.HitBox);
            var collisionType = (Collisions.GetCollidableType(collisionInstigator), Collisions.GetCollidableType(collisionReceiver));
            if (collisionResponders.ContainsKey(collisionType))
            {
                collisionResponders[collisionType]?.RespondToCollision(collisionInstigator, collisionReceiver, collision);
            }
        }

        public void ManageCameraCollisions(IRigidBody collisionInstigator, ICollidable camera)
        {
            var leftCameraHitBox = new Rectangle(camera.HitBox.X - Offsets.TileOffset, camera.HitBox.Y, Offsets.TileOffset, camera.HitBox.Height);
            var rightCameraHitBox = new Rectangle(camera.HitBox.X + camera.HitBox.Width, camera.HitBox.Y, Offsets.TileOffset, camera.HitBox.Height);

            ICollision collision = new BottomCollision(Rectangle.Empty);
            if (collisionInstigator.HitBox.Intersects(leftCameraHitBox) || collisionInstigator.HitBox.Intersects(rightCameraHitBox))
            {
                collision = Collisions.DetectCollision(collisionInstigator,
                    collisionInstigator.HitBox.Intersects(leftCameraHitBox) ? leftCameraHitBox : rightCameraHitBox);
            }

            var collisionType = (Collisions.GetCollidableType(collisionInstigator), typeof(ICamera));
            if (collisionResponders.ContainsKey(collisionType))
            {
                collisionResponders[collisionType].RespondToCollision(collisionInstigator, camera, collision);
            }
        }

        public void ManageBlockCollisions(IRigidBody collisionInstigator, Collection<IGameObject> blocks)
        {
            if (Collisions.CollidablesAreSideBySide(blocks[0].HitBox, blocks[1].HitBox))
            {
                var firstCollision = Collisions.DetectIfTopOrBottomCollision(collisionInstigator.HitBox, blocks[0].HitBox);
                var secondCollision = Collisions.DetectIfTopOrBottomCollision(collisionInstigator.HitBox, blocks[1].HitBox);
                ManageCollisions(collisionInstigator, firstCollision.Intersection.Height > secondCollision.Intersection.Height
                        ? blocks[0]
                        : blocks[1]);
            }
            else if (Collisions.CollidablesAreStacked(blocks[0].HitBox, blocks[1].HitBox))
            {
                var firstCollision = Collisions.DetectIfLeftOrRightCollision(collisionInstigator.HitBox, blocks[0].HitBox);
                var secondCollision = Collisions.DetectIfLeftOrRightCollision(collisionInstigator.HitBox, blocks[1].HitBox);
                ManageCollisions(collisionInstigator, firstCollision.Intersection.Width > secondCollision.Intersection.Width
                        ? blocks[0]
                        : blocks[1]);
            }
            else
            {
                ManageCollisions(collisionInstigator, blocks[0]);
                ManageCollisions(collisionInstigator, blocks[1]);
            }
        }

        public void ManagePlayerPipeCollisions(IPlayer player, IPipe pipe)
        {
            if (pipe.WarpLocation != Vector2.Zero)
            {
                if (player.ExtendedHitBox.Intersects(pipe.WarpHitBox))
                {
                    var collisionType = (Collisions.GetCollidableType(player), typeof(IPipe));
                    if (collisionResponders.ContainsKey(collisionType))
                    {
                        collisionResponders[collisionType].RespondToCollision(player, pipe, Collisions.DetectCollision(player, pipe.HitBox));
                    }
                }
            }
            else
            {
                if (pipe.HitBox.Contains(player.HitBox.Center))
                {
                    var collisionType = (Collisions.GetCollidableType(player), typeof(IPipe));
                    if (collisionResponders.ContainsKey(collisionType))
                    {
                        collisionResponders[collisionType].RespondToCollision(player, pipe, new BottomCollision(Rectangle.Empty));
                    }
                }
            }
        }
    }
}
