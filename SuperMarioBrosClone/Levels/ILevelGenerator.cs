namespace SuperMarioBrosClone.Levels
{
    public interface ILevelGenerator
    {
        void LoadContent(string levelFile);
        void GenerateLevel();
    }
}
