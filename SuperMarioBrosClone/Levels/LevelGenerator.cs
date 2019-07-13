namespace SuperMarioBrosClone.Levels
{
    internal class LevelGenerator : ILevelGenerator
    {
        private readonly GameObjectGenerator gameObjectGenerator;

        public LevelGenerator(ILevel level)
        {
            this.gameObjectGenerator = new GameObjectGenerator(level);
        }

        public void LoadContent(string levelFile)
        {
            gameObjectGenerator.LoadContent(levelFile);
        }

        public void GenerateLevel()
        {
            gameObjectGenerator.GenerateGameObjects();
        }
    }
}
