using System;
using System.Collections.Generic;
using System.Reflection;
using SuperMarioBrosClone.Collisions.Commands.Player;
using SuperMarioBrosClone.GameObjects.Blocks;
using SuperMarioBrosClone.Input;

namespace SuperMarioBrosClone.Collisions.Responders
{
    internal class PlayerWarpPipeCollisionResponder : ICollisionResponder
    {
        private readonly Dictionary<(Type, Type), ConstructorInfo> playerWarpPipeCollisionCommands;

        public void RespondToCollision(ICollidable player, ICollidable pipe, ICollision collision)
        {
            var collisionType = (pipe.GetType(), collision.GetType());
            if (playerWarpPipeCollisionCommands.ContainsKey(collisionType))
            {
                (playerWarpPipeCollisionCommands[collisionType].Invoke(new object[] { player, pipe }) as ICommand)?.Execute();
            }
        }

        public PlayerWarpPipeCollisionResponder()
        {
            this.playerWarpPipeCollisionCommands = new Dictionary<(Type, Type), ConstructorInfo>
            {
                { (typeof(LargeVerticalGreenPipe), typeof(TopCollision)), typeof(WarpDownCommand).GetConstructors()[0] },
                { (typeof(SmallVerticalGreenPipe), typeof(TopCollision)), typeof(WarpDownCommand).GetConstructors()[0] },
                { (typeof(SmallVerticalGreenPipe), typeof(BottomCollision)), typeof(WarpUpCommand).GetConstructors()[0] },
                { (typeof(HorizontalGreenPipe), typeof(RightCollision)), typeof(WarpRightCommand).GetConstructors()[0] }
            };
        }
    }
}
