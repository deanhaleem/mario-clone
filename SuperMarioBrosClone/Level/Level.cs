using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SuperMarioBrosClone
{
    internal class Level : ILevel
    {
        private readonly ILevelGenerator levelGenerator;
        private Collection<IGameObject> nonCollidableGameObjects;
        private Collection<IGameObject> gameObjects;

        public string Name { get; private set; }

        public IPlayer Player
        {
            get
            {
                if (gameObjects.OfType<IPlayer>().Any())
                {
                    return gameObjects[gameObjects.IndexOf(gameObjects.OfType<IPlayer>().ElementAt(0))] as IPlayer;
                }
                return nonCollidableGameObjects[nonCollidableGameObjects.IndexOf(nonCollidableGameObjects.OfType<IPlayer>().ElementAt(0))] as IPlayer;
            }
            set
            {
                if (gameObjects.OfType<IPlayer>().Any())
                {
                    gameObjects[gameObjects.IndexOf(gameObjects.OfType<IPlayer>().ElementAt(0))] = value;
                }
                else
                {
                    nonCollidableGameObjects[nonCollidableGameObjects.IndexOf(nonCollidableGameObjects.OfType<IPlayer>().ElementAt(0))] = value;
                }
            }
        }

        public Level()
        {
            this.levelGenerator = new LevelGenerator(this);
        }

        public void LoadContent(string levelFile)
        {
            levelGenerator.LoadContent(levelFile);

            string levelNameWithoutDirectory = levelFile.Remove(levelFile.IndexOf("Content/", StringComparison.Ordinal), Utilities.LevelFileNameRemoval);
            Name = levelNameWithoutDirectory.Remove(levelNameWithoutDirectory.IndexOf(".json", StringComparison.Ordinal), Utilities.LevelFileTypeRemoval);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(gameTime);
            }

            for (int i = 0; i < nonCollidableGameObjects.Count; i++)
            {
                nonCollidableGameObjects[i].Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IGameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }

            foreach (IGameObject gameObject in nonCollidableGameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
        }

        public Collection<IGameObject> GetObjectsOnScreen(Rectangle levelBounds)
        {
            Collection<IGameObject> objectsOnScreen = new Collection<IGameObject>();
            foreach (IGameObject gameObject in gameObjects)
            {
                if (gameObject.HitBox.Right > levelBounds.X - Locations.WorldBoundary.X && gameObject.HitBox.X < levelBounds.Right + Locations.WorldBoundary.X)
                {
                    objectsOnScreen.Add(gameObject);
                }
            }
            return objectsOnScreen;
        }

        public void DisposeOfGameObject(IGameObject gameObject)
        {
            if (gameObjects.Contains(gameObject))
            {
                gameObjects.Remove(gameObject);
            }
            else
            {
                nonCollidableGameObjects.Remove(gameObject);
            }
        }

        public void RegisterGameObject(IGameObject gameObject)
        {
            if (nonCollidableGameObjects.Contains(gameObject))
            {
                nonCollidableGameObjects.Remove(gameObject);
            }
            gameObjects.Add(gameObject);
        }

        public void UnregisterGameObject(IGameObject gameObject)
        {
            if (gameObjects.Contains(gameObject))
            {
                gameObjects.Remove(gameObject);
            }
            nonCollidableGameObjects.Add(gameObject);
        }

        public void CleanUp(Rectangle levelBounds)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].HitBox.Right < levelBounds.Left - Offsets.OutOfLevelOffset || gameObjects[i].HitBox.Top > levelBounds.Bottom + Offsets.OutOfLevelOffset)
                {
                    gameObjects.Remove(gameObjects[i]);
                }
            }

            for (int i = 0; i < nonCollidableGameObjects.Count; i++)
            {
                if (nonCollidableGameObjects[i].Location.X < levelBounds.Left - Offsets.OutOfLevelOffset || nonCollidableGameObjects[i].Location.Y > levelBounds.Bottom + Offsets.OutOfLevelOffset)
                {
                    nonCollidableGameObjects.Remove(nonCollidableGameObjects[i]);
                }
            }
        }

        public void Reset()
        {
            gameObjects = new Collection<IGameObject>();
            nonCollidableGameObjects = new Collection<IGameObject>();
            levelGenerator.GenerateLevel();
        }
    }
}
