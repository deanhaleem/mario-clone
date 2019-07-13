using System;
using System.Collections.Generic;
using System.Reflection;
using SuperMarioBrosClone.Collisions.Commands.Player;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.GameObjects.Items;
using SuperMarioBrosClone.GameObjects.Players;
using SuperMarioBrosClone.GameObjects.Players.States;
using SuperMarioBrosClone.Input;

namespace SuperMarioBrosClone.Collisions.Responders
{
    internal class PlayerItemCollisionResponder : ICollisionResponder
    {
        private readonly Dictionary<(Type, Type, Type), ConstructorInfo> playerItemCollisionCommands;

        public void RespondToCollision(ICollidable collisionInstigator, ICollidable collisionReceiver, ICollision collision)
        {
            (Type, Type, Type) collisionType;
            if (collisionInstigator is IPlayer player)
            {
                collisionType = (player.GetType(), player.PowerUpState.GetType(), collisionReceiver.GetType());
                if (playerItemCollisionCommands.ContainsKey(collisionType))
                {
                    (playerItemCollisionCommands[collisionType].Invoke(new object[] { collisionInstigator, collisionReceiver, collision }) as ICommand)?.Execute();
                }
            }
            else
            {
                collisionType = (collisionReceiver.GetType(), (collisionReceiver as IPlayer)?.PowerUpState.GetType(), collisionInstigator.GetType());
                if (playerItemCollisionCommands.ContainsKey(collisionType))
                {
                    (playerItemCollisionCommands[collisionType].Invoke(new object[] { collisionReceiver, collisionInstigator, collision }) as ICommand)?.Execute();
                }
            }
        }

        public PlayerItemCollisionResponder()
        {
            this.playerItemCollisionCommands = new Dictionary<(Type, Type, Type), ConstructorInfo>
            {
                { (typeof(Mario), typeof(SmallPowerUpState), typeof(FireFlower)), typeof(TurnPlayerBigCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(BigPowerUpState), typeof(FireFlower)), typeof(TurnPlayerFireCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(FirePowerUpState), typeof(FireFlower)), typeof(PickUpPowerUpCommand).GetConstructors()[0] },

                { (typeof(Mario), typeof(SmallPowerUpState), typeof(GreenMushroom)), typeof(GainLifeCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(BigPowerUpState), typeof(GreenMushroom)), typeof(GainLifeCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(FirePowerUpState), typeof(GreenMushroom)), typeof(GainLifeCommand).GetConstructors()[0] },

                { (typeof(Mario), typeof(SmallPowerUpState), typeof(RedMushroom)), typeof(TurnPlayerBigCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(BigPowerUpState), typeof(RedMushroom)), typeof(PickUpPowerUpCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(FirePowerUpState), typeof(RedMushroom)), typeof(PickUpPowerUpCommand).GetConstructors()[0] },

                { (typeof(Mario), typeof(SmallPowerUpState), typeof(NonSpinningCoin)), typeof(PickUpCoinCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(BigPowerUpState), typeof(NonSpinningCoin)), typeof(PickUpCoinCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(FirePowerUpState), typeof(NonSpinningCoin)), typeof(PickUpCoinCommand).GetConstructors()[0] },

                { (typeof(Mario), typeof(SmallPowerUpState), typeof(Star)), typeof(TurnPlayerStarCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(BigPowerUpState), typeof(Star)), typeof(TurnPlayerStarCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(FirePowerUpState), typeof(Star)), typeof(TurnPlayerStarCommand).GetConstructors()[0] },

                { (typeof(Mario), typeof(SmallPowerUpState), typeof(Flagpole)), typeof(WinLevelCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(BigPowerUpState), typeof(Flagpole)), typeof(WinLevelCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(FirePowerUpState), typeof(Flagpole)), typeof(WinLevelCommand).GetConstructors()[0] },

                { (typeof(Mario), typeof(SmallPowerUpState), typeof(CastleDoor)), typeof(RemovePlayerFromScreenCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(BigPowerUpState), typeof(CastleDoor)), typeof(RemovePlayerFromScreenCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(FirePowerUpState), typeof(CastleDoor)), typeof(RemovePlayerFromScreenCommand).GetConstructors()[0] },


                { (typeof(StarMario), typeof(SmallPowerUpState), typeof(FireFlower)), typeof(TurnPlayerBigCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(BigPowerUpState), typeof(FireFlower)), typeof(TurnPlayerFireCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(FirePowerUpState), typeof(FireFlower)), typeof(PickUpPowerUpCommand).GetConstructors()[0] },

                { (typeof(StarMario), typeof(SmallPowerUpState), typeof(GreenMushroom)), typeof(GainLifeCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(BigPowerUpState), typeof(GreenMushroom)), typeof(GainLifeCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(FirePowerUpState), typeof(GreenMushroom)), typeof(GainLifeCommand).GetConstructors()[0] },

                { (typeof(StarMario), typeof(SmallPowerUpState), typeof(RedMushroom)), typeof(TurnPlayerBigCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(BigPowerUpState), typeof(RedMushroom)), typeof(PickUpPowerUpCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(FirePowerUpState), typeof(RedMushroom)), typeof(PickUpPowerUpCommand).GetConstructors()[0] },

                { (typeof(StarMario), typeof(SmallPowerUpState), typeof(NonSpinningCoin)), typeof(PickUpCoinCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(BigPowerUpState), typeof(NonSpinningCoin)), typeof(PickUpCoinCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(FirePowerUpState), typeof(NonSpinningCoin)), typeof(PickUpCoinCommand).GetConstructors()[0] },

                { (typeof(StarMario), typeof(SmallPowerUpState), typeof(Star)), typeof(TurnPlayerStarCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(BigPowerUpState), typeof(Star)), typeof(TurnPlayerStarCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(FirePowerUpState), typeof(Star)), typeof(TurnPlayerStarCommand).GetConstructors()[0] },

                { (typeof(StarMario), typeof(SmallPowerUpState), typeof(Flagpole)), typeof(WinLevelCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(BigPowerUpState), typeof(Flagpole)), typeof(WinLevelCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(FirePowerUpState), typeof(Flagpole)), typeof(WinLevelCommand).GetConstructors()[0] },


                { (typeof(BlinkingMario), typeof(SmallPowerUpState), typeof(FireFlower)), typeof(TurnBlinkingMarioBigCommand).GetConstructors()[0] },
                { (typeof(BlinkingMario), typeof(SmallPowerUpState), typeof(GreenMushroom)), typeof(GainLifeCommand).GetConstructors()[0] },
                { (typeof(BlinkingMario), typeof(SmallPowerUpState), typeof(RedMushroom)), typeof(TurnBlinkingMarioBigCommand).GetConstructors()[0] },
                { (typeof(BlinkingMario), typeof(SmallPowerUpState), typeof(NonSpinningCoin)), typeof(PickUpCoinCommand).GetConstructors()[0] },
                { (typeof(BlinkingMario), typeof(SmallPowerUpState), typeof(Star)), typeof(TurnBlinkingMarioStarCommand).GetConstructors()[0] },
                { (typeof(BlinkingMario), typeof(SmallPowerUpState), typeof(Flagpole)), typeof(WinLevelCommand).GetConstructors()[0] }
            };
        }
    }
}
