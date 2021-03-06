﻿using SuperMarioBrosClone.GameObjects;

namespace SuperMarioBrosClone.Input.Commands
{
    internal class StopRunningCommand : Command<IPlayer>
    {
        public StopRunningCommand(IPlayer player) : base(player)
        {

        }

        public override void Execute()
        {
            Receiver.StopRunning();
        }
    }
}
