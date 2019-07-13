using System;
using System.Collections.Generic;
using System.Reflection;
using SuperMarioBrosClone.Collisions.Commands.Player;
using SuperMarioBrosClone.Input;

namespace SuperMarioBrosClone.Collisions.Responders
{
    internal class PlayerCameraCollisionResponder : ICollisionResponder
    {
        private readonly Dictionary<Type, ConstructorInfo> playerCameraCollisionCommands;

        public void RespondToCollision(ICollidable player, ICollidable camera, ICollision collision)
        {
            if (playerCameraCollisionCommands.ContainsKey(collision.GetType()))
            {
                (playerCameraCollisionCommands[collision.GetType()].Invoke(new object[] { player, collision }) as ICommand)?.Execute();
            }
        }

        public PlayerCameraCollisionResponder()
        {
            this.playerCameraCollisionCommands = new Dictionary<Type, ConstructorInfo>
            {
                { typeof(LeftCollision), typeof(LeftPlayerCameraCollisionCommand).GetConstructors()[0] },
                { typeof(RightCollision), typeof(RightPlayerCameraCollisionCommand).GetConstructors()[0] }
            };
        }
    }
}
