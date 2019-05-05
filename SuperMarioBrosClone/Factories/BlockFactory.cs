using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace SuperMarioBrosClone
{
    internal class BlockFactory
    {
        public static BlockFactory Instance { get; } = new BlockFactory();

        private readonly Dictionary<Type, Func<object[], object>> blockCreators = new Dictionary<Type, Func<object[], object>>
        {
            { typeof(HiddenBlock), typeof(UsedBlock).GetConstructors()[0].Invoke}
        };

        private BlockFactory()
        {

        }

        public void CreateBlock(Type blockType, Vector2 location)
        {
            Game1.Instance.RegisterGameObject(blockCreators[blockType](new object[] {location, Color.White}) as IBlock);
        }

        public static void CreateDebris(Vector2 location)
        {
            Game1.Instance.UnregisterGameObject(new DebrisBlock(location + Offsets.TopRightDebrisSpawnOffset, Color.White, Physics.TopRightDebrisVelocity));
            Game1.Instance.UnregisterGameObject(new DebrisBlock(location + Offsets.TopLeftDebrisSpawnOffset, Color.White, Physics.TopLeftDebrisVelocity));
            Game1.Instance.UnregisterGameObject(new DebrisBlock(location + Offsets.BottomRightDebrisSpawnOffset, Color.White, Physics.BottomRightDebrisVelocity));
            Game1.Instance.UnregisterGameObject(new DebrisBlock(location + Offsets.BottomLeftDebrisSpawnOffset, Color.White, Physics.BottomLeftDebrisVelocity));
        }
    }
}
