using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web.Script.Serialization;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.Levels
{
    internal class GameObjectGenerator
    {
        private readonly ILevel level;
        private Dictionary<string, GameObjectRegistrar> gameObjectRegistrars;

        public GameObjectGenerator(ILevel level)
        {
            this.gameObjectRegistrars = new Dictionary<string, GameObjectRegistrar>();
            this.level = level;
        }

        public void LoadContent(string levelFile)
        {
            gameObjectRegistrars =
                new JavaScriptSerializer().Deserialize<Dictionary<string, GameObjectRegistrar>>(File.ReadAllText(levelFile));
        }

        public void GenerateGameObjects()
        {
            foreach (string gameObjectType in gameObjectRegistrars.Keys)
            {
                GameObjectRegistrar gameObjectRegistrar = gameObjectRegistrars[gameObjectType];
                GetType().GetMethod(gameObjectRegistrar.Type)?.Invoke(this, new object[] {gameObjectRegistrar, gameObjectType});
            }
        }

        public void CreateSingleGameObjects(GameObjectRegistrar gameObjectRegistrar, string gameObjectType)
        {
            for (int i = 0; i < gameObjectRegistrar.Locations.Length; i++)
            {
                ConstructorInfo gameObjectConstructor = typeof(IGameObject).Assembly.GetType(gameObjectRegistrar.Namespace + "." + gameObjectType).GetConstructors()[0];
                level.RegisterGameObject(gameObjectConstructor.Invoke(new object[] { gameObjectRegistrar.Locations[i], gameObjectRegistrar.Colors[i] }) as IGameObject);
            }
        }

        public void CreateCollectionGameObjects(GameObjectRegistrar gameObjectRegistrar, string gameObjectType)
        {
            for (int i = 0; i < gameObjectRegistrar.Locations.Length; i++)
            {
                Vector2 gameObjectLocation = gameObjectRegistrar.Locations[i];
                ConstructorInfo gameObjectConstructor = typeof(IGameObject).Assembly.GetType(gameObjectRegistrar.Namespace + "." + gameObjectType).GetConstructors()[0];
                level.RegisterGameObject(gameObjectConstructor.Invoke(new object[]
                    {gameObjectLocation, gameObjectRegistrar.Colors[i], gameObjectRegistrar.Lengths[i]}) as IGameObject);
            }
        }

        public void CreateItemContainerGameObjects(GameObjectRegistrar gameObjectRegistrar, string gameObjectType)
        {
            for (int i = 0; i < gameObjectRegistrar.Locations.Length; i++)
            {
                Vector2 gameObjectLocation = gameObjectRegistrar.Locations[i];
                ConstructorInfo gameObjectConstructor = typeof(IGameObject).Assembly.GetType(gameObjectRegistrar.Namespace + "." + gameObjectType).GetConstructors()[0];
                Type itemType = typeof(IItem).Assembly.GetType("SuperMarioBrosClone.GameObjects.Items." + gameObjectRegistrar.ItemTypes[i]);
                level.RegisterGameObject(gameObjectConstructor.Invoke(new object[] { gameObjectLocation, gameObjectRegistrar.Colors[i], itemType }) as IGameObject);
            }
        }

        public void CreateNonCollidableGameObjects(GameObjectRegistrar gameObjectRegistrar, string gameObjectType)
        {
            for (int i = 0; i < gameObjectRegistrar.Locations.Length; i++)
            {
                ConstructorInfo gameObjectConstructor = typeof(IGameObject).Assembly.GetType(gameObjectRegistrar.Namespace + "." + gameObjectType).GetConstructors()[0];
                level.UnregisterGameObject(gameObjectConstructor.Invoke(new object[] { gameObjectRegistrar.Locations[i], gameObjectRegistrar.Colors[i] }) as IGameObject);
            }
        }

        public void CreatePipeGameObject(GameObjectRegistrar gameObjectRegistrar, string gameObjectType)
        {
            for (int i = 0; i < gameObjectRegistrar.Locations.Length; i++)
            {
                ConstructorInfo gameObjectConstructor = typeof(IGameObject).Assembly.GetType(gameObjectRegistrar.Namespace + "." + gameObjectType).GetConstructors()[0];
                level.RegisterGameObject(gameObjectConstructor.Invoke(new object[] { gameObjectRegistrar.Locations[i], gameObjectRegistrar.Colors[i], gameObjectRegistrar.WarpLocations[i] }) as IGameObject);
            }
        }

        public class GameObjectRegistrar
        {
            public string Type { get; set; }
            public string Namespace { get; set; }
            public Vector2[] Locations { get; set; }
            public Vector2[] WarpLocations { get; set; }
            public Point[] Lengths { get; set; }
            public string[] ItemTypes { get; set; }
            public Color[] Colors { get; set; }
        }
    }
}
