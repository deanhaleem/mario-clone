namespace SuperMarioBrosClone
{
    public interface ILevelGenerator
    {
        void LoadContent(string levelFile);
        void GenerateLevel();
    }
}
