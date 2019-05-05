using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace SuperMarioBrosClone
{
    internal class ItemFactory
    {
        public static ItemFactory Instance { get; } = new ItemFactory();

        private readonly Dictionary<Type, Func<object[], object>> itemCreators = new Dictionary<Type, Func<object[], object>>
        {
            { typeof(SpinningCoin), typeof(SpinningCoin).GetConstructors()[0].Invoke },
            { typeof(FireFlower), typeof(FireFlower).GetConstructors()[0].Invoke },
            { typeof(GreenMushroom), typeof(GreenMushroom).GetConstructors()[0].Invoke },
            { typeof(RedMushroom), typeof(RedMushroom).GetConstructors()[0].Invoke },
            { typeof(Star), typeof(Star).GetConstructors()[0].Invoke }
        };

        private ItemFactory()
        {

        }

        public void CreateItem(Type itemType, Vector2 location)
        {
            Game1.Instance.UnregisterGameObject(itemCreators[itemType]( new object[] { location, Color.White }) as IItem);
        }
    }
}
