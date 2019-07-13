using Microsoft.Xna.Framework;
using System;
using SuperMarioBrosClone.GameObjects;

namespace SuperMarioBrosClone.Collisions
{
    internal static class Collisions
    {
        public static ICollision DetectCollision(IRigidBody rigidBody, Rectangle collisionReceiver)
        {
            var previousHitBox = new Rectangle
            {
                X = rigidBody.HitBox.X - (int)rigidBody.Velocity.X,
                Y = rigidBody.HitBox.Y - (int)rigidBody.Velocity.Y,
                Width = rigidBody.HitBox.Width,
                Height = rigidBody.HitBox.Height
            };

            float maxVelocity = Math.Abs(rigidBody.Velocity.X) > Math.Abs(rigidBody.Velocity.Y)
                ? Math.Abs(rigidBody.Velocity.X)
                : Math.Abs(rigidBody.Velocity.Y);

            var firstCollisionHitBox = Rectangle.Empty;
            for (float delta = 0; delta <= maxVelocity && firstCollisionHitBox.IsEmpty; delta += 1f)
            {
                previousHitBox.Offset(previousHitBox.X == rigidBody.HitBox.X
                        ? 0
                        : rigidBody.Velocity.X < 0 ? -delta : delta,
                    previousHitBox.Y == rigidBody.HitBox.Y
                        ? 0
                        : rigidBody.Velocity.Y < 0 ? -delta : delta);

                if (previousHitBox.Intersects(collisionReceiver))
                {
                    firstCollisionHitBox = previousHitBox;
                }
            }

            (_, _, int width, int height) = firstCollisionHitBox.IsEmpty
                ? Rectangle.Intersect(rigidBody.HitBox, collisionReceiver)
                : Rectangle.Intersect(firstCollisionHitBox, collisionReceiver);

            return width >= height
                ? DetectIfTopOrBottomCollision(firstCollisionHitBox, rigidBody.HitBox, collisionReceiver)
                : DetectIfLeftOrRightCollision(firstCollisionHitBox, rigidBody.HitBox, collisionReceiver);
        }

        private static ICollision DetectIfTopOrBottomCollision(Rectangle firstCollision, Rectangle collisionInstigator, Rectangle collisionReceiver)
        {
            var collisionIntersection = Rectangle.Intersect(collisionInstigator, collisionReceiver);
            return firstCollision.Center.Y < collisionReceiver.Center.Y
                ? (ICollision)new TopCollision(collisionIntersection)
                : new BottomCollision(collisionIntersection);
        }

        private static ICollision DetectIfLeftOrRightCollision(Rectangle firstCollision, Rectangle collisionInstigator, Rectangle collisionReceiver)
        {
            var collisionIntersection = Rectangle.Intersect(collisionInstigator, collisionReceiver);
            return firstCollision.Center.X > collisionReceiver.Center.X
                ? (ICollision)new LeftCollision(collisionIntersection)
                : new RightCollision(collisionIntersection);
        }

        public static ICollision DetectIfTopOrBottomCollision(Rectangle collisionInstigator, Rectangle collisionReceiver)
        {
            var collisionIntersection = Rectangle.Intersect(collisionInstigator, collisionReceiver);
            return collisionInstigator.Top < collisionReceiver.Top
                ? (ICollision)new TopCollision(collisionIntersection)
                : new BottomCollision(collisionIntersection);
        }

        public static ICollision DetectIfLeftOrRightCollision(Rectangle collisionInstigator, Rectangle collisionReceiver)
        {
            var collisionIntersection = Rectangle.Intersect(collisionInstigator, collisionReceiver);
            return collisionInstigator.Center.X > collisionReceiver.Center.X
                ? (ICollision)new LeftCollision(collisionIntersection)
                : new RightCollision(collisionIntersection);
        }

        public static Type GetCollidableType(ICollidable collidable)
        {
            var instigatorInterfaces = collidable.GetType().GetInterfaces();

            int indexOfInstigatorType = collidable is KinematicGameObject
                ? typeof(KinematicGameObject).GetInterfaces().Length
                : typeof(GameObject).GetInterfaces().Length;
            return instigatorInterfaces[indexOfInstigatorType];
        }

        public static bool CollidablesAreStacked(Rectangle bottomCollidable, Rectangle topCollidable)
        {
            return (Math.Abs(bottomCollidable.Top - topCollidable.Bottom) < 32 ||
                    Math.Abs(bottomCollidable.Bottom - topCollidable.Top) < 32) &&
                   Math.Abs(bottomCollidable.Right - topCollidable.Right) < 32 &&
                   Math.Abs(bottomCollidable.Left - topCollidable.Left) < 32;
        }

        public static bool CollidablesAreSideBySide(Rectangle leftCollidable, Rectangle rightCollidable)
        {
            return (Math.Abs(leftCollidable.Right - rightCollidable.Left) < 32 ||
                   Math.Abs(leftCollidable.Left - rightCollidable.Right) < 32) &&
                   Math.Abs(leftCollidable.Top - rightCollidable.Top) < 32 &&
                   Math.Abs(leftCollidable.Bottom - rightCollidable.Bottom) < 32;
        }
    }
}
