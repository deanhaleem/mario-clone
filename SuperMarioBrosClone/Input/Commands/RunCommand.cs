using SuperMarioBrosClone.GameObjects;

namespace SuperMarioBrosClone.Input.Commands
{
    internal class RunCommand : Command<IPlayer>
    {
        public RunCommand(IPlayer player) : base(player)
        {

        }

        public override void Execute()
        {
            Receiver.Run();
        }
    }
}
