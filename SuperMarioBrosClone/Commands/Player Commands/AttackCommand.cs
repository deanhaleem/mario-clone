namespace SuperMarioBrosClone
{
    internal class AttackCommand : Command<IPlayer>
    {
        public AttackCommand(IPlayer player) : base(player)
        {

        }

        public override void Execute()
        {
            Receiver.Attack();
        }
    }
}
