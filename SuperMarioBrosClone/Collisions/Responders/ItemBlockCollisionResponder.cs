using System;
using System.Collections.Generic;
using System.Reflection;
using SuperMarioBrosClone.Collisions.Commands.Item;
using SuperMarioBrosClone.Input;

namespace SuperMarioBrosClone.Collisions.Responders
{
    internal class ItemBlockCollisionResponder : ICollisionResponder
    {
        private readonly Dictionary<Type, ConstructorInfo> itemBlockCollisionCommands;

        public void RespondToCollision(ICollidable item, ICollidable block, ICollision collision)
        {
            (itemBlockCollisionCommands[collision.GetType()].Invoke(new object[] { item, block, collision }) as ICommand)?.Execute();
        }

        public ItemBlockCollisionResponder()
        {
            this.itemBlockCollisionCommands = new Dictionary<Type, ConstructorInfo>
            {
                { typeof(TopCollision), typeof(PushItemUpCommand).GetConstructors()[0] },
                { typeof(BottomCollision), typeof(PushItemDownCommand).GetConstructors()[0] },
                { typeof(LeftCollision), typeof(PushItemRightCommand).GetConstructors()[0] },
                { typeof(RightCollision), typeof(PushItemLeftCommand).GetConstructors()[0] }
            };
        }
    }
}
