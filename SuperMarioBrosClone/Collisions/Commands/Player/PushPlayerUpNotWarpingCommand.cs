﻿using SuperMarioBrosClone.Collisions.Handlers;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Input.Commands;

namespace SuperMarioBrosClone.Collisions.Commands.Player
{
    internal class PushPlayerUpNotWarpingCommand : Command<PlayerBlockCollisionHandler>
    {
        public PushPlayerUpNotWarpingCommand(IPlayer player, IBlock block, ICollision collision) :
            base(new PlayerBlockCollisionHandler(player, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleTopPlayerPipeCollision();
        }
    }
}
