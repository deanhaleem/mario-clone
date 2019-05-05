namespace SuperMarioBrosClone
{
    internal class CoinKeeper
    {
        public int Coins { get; private set; }

        public void PickUpCoin()
        {
            Coins++;
        }

        public void Reset()
        {
            Coins = 0;
        }
    }
}
