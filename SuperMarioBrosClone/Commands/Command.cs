namespace SuperMarioBrosClone
{
    internal abstract class Command<T> : ICommand
    {
        protected T Receiver { get; }

        protected Command(T receiver)
        {
            this.Receiver = receiver;
        }

        public abstract void Execute();
    }
}
