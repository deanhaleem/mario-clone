using System;
using System.Reflection;

namespace SuperMarioBrosClone
{
    internal class SpawningItemState : ItemState
    {
        private readonly ConstructorInfo itemStateAfterSpawn;

        public SpawningItemState(IItem item, Type itemStateType) : base(item)
        {
            this.itemStateAfterSpawn = itemStateType.GetConstructors()[0];
            base.Item.ApplyImpulse(Physics.SpawningItemImpulse);

            TimedActionManager.Instance.RegisterTimedAction(null, SetStateAfterSpawn, Timers.ItemSpawnTimer);

            SoundManager.Instance.PlaySoundEffect(GetType().Name);
        }

        private void SetStateAfterSpawn()
        {
            Item.ItemState = itemStateAfterSpawn.Invoke(new object[] { Item }) as IItemState;
            Game1.Instance.RegisterGameObject(Item);
        }
    }
}
