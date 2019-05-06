using System;
using System.Collections.Generic;
using System.Reflection;

namespace SuperMarioBrosClone
{
    internal class PlayerEnemyCollisionResponder : ICollisionResponder
    {
        private readonly Dictionary<(Type, Type, Type, Type), ConstructorInfo> playerEnemyCollisionCommands;

        public void RespondToCollision(ICollidable collisionInstigator, ICollidable collisionReceiver, ICollision collisionSide)
        {
            (Type, Type, Type, Type) collisionType;
            if (collisionInstigator is IPlayer)
            {
                collisionType = (collisionInstigator.GetType(), collisionReceiver.GetType(),
                    (collisionReceiver as IEnemy)?.EnemyState.GetType(), collisionSide.GetType());
                if (playerEnemyCollisionCommands.ContainsKey(collisionType))
                {
                    (playerEnemyCollisionCommands[collisionType].Invoke(new object[]
                        {collisionInstigator, collisionReceiver, collisionSide}) as ICommand)?.Execute();
                }
            }
            else
            {
                collisionType = (collisionInstigator.GetType(), collisionReceiver.GetType(),
                    (collisionInstigator as IEnemy)?.EnemyState.GetType(), collisionSide.GetType());
                if (playerEnemyCollisionCommands.ContainsKey(collisionType))
                {
                    (playerEnemyCollisionCommands[collisionType].Invoke(new object[]
                        {collisionReceiver, collisionInstigator, collisionSide}) as ICommand)?.Execute();
                }
            }
        }

        public PlayerEnemyCollisionResponder()
        {
            this.playerEnemyCollisionCommands = new Dictionary<(Type, Type, Type, Type), ConstructorInfo>
            {
                { (typeof(Mario), typeof(Goomba), typeof(LeftWalkingEnemyState), typeof(TopCollision)), typeof(PushPlayerUpStompEnemyCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Goomba), typeof(LeftWalkingEnemyState),typeof(BottomCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Goomba), typeof(LeftWalkingEnemyState), typeof(LeftCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Goomba), typeof(LeftWalkingEnemyState), typeof(RightCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },

                { (typeof(Mario), typeof(Goomba), typeof(RightWalkingEnemyState), typeof(TopCollision)), typeof(PushPlayerUpStompEnemyCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Goomba), typeof(RightWalkingEnemyState),typeof(BottomCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Goomba), typeof(RightWalkingEnemyState), typeof(LeftCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Goomba), typeof(RightWalkingEnemyState), typeof(RightCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },

                { (typeof(Mario), typeof(Koopa), typeof(LeftWalkingEnemyState), typeof(TopCollision)), typeof(PushPlayerUpDisarmEnemyCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Koopa), typeof(LeftWalkingEnemyState),typeof(BottomCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Koopa), typeof(LeftWalkingEnemyState), typeof(LeftCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Koopa), typeof(LeftWalkingEnemyState), typeof(RightCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },

                { (typeof(Mario), typeof(Koopa), typeof(RightWalkingEnemyState), typeof(TopCollision)), typeof(PushPlayerUpDisarmEnemyCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Koopa), typeof(RightWalkingEnemyState),typeof(BottomCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Koopa), typeof(RightWalkingEnemyState), typeof(LeftCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Koopa), typeof(RightWalkingEnemyState), typeof(RightCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },

                { (typeof(Mario), typeof(Koopa), typeof(ShellEnemyState), typeof(TopCollision)), typeof(PushPlayerUpStompOrMoveShellCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Koopa), typeof(ShellEnemyState),typeof(BottomCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Koopa), typeof(ShellEnemyState), typeof(LeftCollision)), typeof(PushRightOrDamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Mario), typeof(Koopa), typeof(ShellEnemyState), typeof(RightCollision)), typeof(PushLeftOrDamagePlayerCommand).GetConstructors()[0] },


                { (typeof(StarMario), typeof(Goomba), typeof(LeftWalkingEnemyState), typeof(TopCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Goomba), typeof(LeftWalkingEnemyState),typeof(BottomCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Goomba), typeof(LeftWalkingEnemyState), typeof(LeftCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Goomba), typeof(LeftWalkingEnemyState), typeof(RightCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },

                { (typeof(StarMario), typeof(Goomba), typeof(RightWalkingEnemyState), typeof(TopCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Goomba), typeof(RightWalkingEnemyState),typeof(BottomCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Goomba), typeof(RightWalkingEnemyState), typeof(LeftCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Goomba), typeof(RightWalkingEnemyState), typeof(RightCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },

                { (typeof(StarMario), typeof(Koopa), typeof(LeftWalkingEnemyState), typeof(TopCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Koopa), typeof(LeftWalkingEnemyState),typeof(BottomCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Koopa), typeof(LeftWalkingEnemyState), typeof(LeftCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Koopa), typeof(LeftWalkingEnemyState), typeof(RightCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },

                { (typeof(StarMario), typeof(Koopa), typeof(RightWalkingEnemyState), typeof(TopCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Koopa), typeof(RightWalkingEnemyState),typeof(BottomCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Koopa), typeof(RightWalkingEnemyState), typeof(LeftCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Koopa), typeof(RightWalkingEnemyState), typeof(RightCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },

                { (typeof(StarMario), typeof(Koopa), typeof(ShellEnemyState), typeof(TopCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Koopa), typeof(ShellEnemyState),typeof(BottomCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Koopa), typeof(ShellEnemyState), typeof(LeftCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(StarMario), typeof(Koopa), typeof(ShellEnemyState), typeof(RightCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },


                { (typeof(BlinkingMario), typeof(Goomba), typeof(LeftWalkingEnemyState), typeof(TopCollision)), typeof(PushPlayerUpStompEnemyCommand).GetConstructors()[0] },

                { (typeof(BlinkingMario), typeof(Goomba), typeof(RightWalkingEnemyState), typeof(TopCollision)), typeof(PushPlayerUpStompEnemyCommand).GetConstructors()[0] },

                { (typeof(BlinkingMario), typeof(Koopa), typeof(LeftWalkingEnemyState), typeof(TopCollision)), typeof(PushPlayerUpStompEnemyCommand).GetConstructors()[0] },

                { (typeof(BlinkingMario), typeof(Koopa), typeof(RightWalkingEnemyState), typeof(TopCollision)), typeof(PushPlayerUpStompEnemyCommand).GetConstructors()[0] },

                { (typeof(BlinkingMario), typeof(Koopa), typeof(ShellEnemyState), typeof(TopCollision)), typeof(PushPlayerUpDisarmEnemyCommand).GetConstructors()[0] },


                { (typeof(Goomba), typeof(Mario), typeof(LeftWalkingEnemyState), typeof(TopCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Goomba), typeof(Mario), typeof(LeftWalkingEnemyState),typeof(BottomCollision)), typeof(PushPlayerUpStompEnemyCommand).GetConstructors()[0] },
                { (typeof(Goomba), typeof(Mario), typeof(LeftWalkingEnemyState), typeof(LeftCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Goomba), typeof(Mario), typeof(LeftWalkingEnemyState), typeof(RightCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },

                { (typeof(Goomba), typeof(Mario), typeof(RightWalkingEnemyState), typeof(TopCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Goomba), typeof(Mario), typeof(RightWalkingEnemyState),typeof(BottomCollision)), typeof(PushPlayerUpStompEnemyCommand).GetConstructors()[0] },
                { (typeof(Goomba), typeof(Mario), typeof(RightWalkingEnemyState), typeof(LeftCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Goomba), typeof(Mario), typeof(RightWalkingEnemyState), typeof(RightCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },

                { (typeof(Koopa), typeof(Mario), typeof(LeftWalkingEnemyState), typeof(TopCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(Mario), typeof(LeftWalkingEnemyState),typeof(BottomCollision)), typeof(PushPlayerUpDisarmEnemyCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(Mario), typeof(LeftWalkingEnemyState), typeof(LeftCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(Mario), typeof(LeftWalkingEnemyState), typeof(RightCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },

                { (typeof(Koopa), typeof(Mario), typeof(RightWalkingEnemyState), typeof(TopCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(Mario), typeof(RightWalkingEnemyState),typeof(BottomCollision)), typeof(PushPlayerUpDisarmEnemyCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(Mario), typeof(RightWalkingEnemyState), typeof(LeftCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(Mario), typeof(RightWalkingEnemyState), typeof(RightCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },

                { (typeof(Koopa), typeof(Mario), typeof(ShellEnemyState), typeof(TopCollision)), typeof(DamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(Mario), typeof(ShellEnemyState),typeof(BottomCollision)), typeof(PushPlayerUpStompOrMoveShellCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(Mario), typeof(ShellEnemyState), typeof(LeftCollision)), typeof(PushLeftOrDamagePlayerCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(Mario), typeof(ShellEnemyState), typeof(RightCollision)), typeof(PushRightOrDamagePlayerCommand).GetConstructors()[0] },


                { (typeof(Goomba), typeof(StarMario), typeof(LeftWalkingEnemyState), typeof(TopCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Goomba), typeof(StarMario), typeof(LeftWalkingEnemyState),typeof(BottomCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Goomba), typeof(StarMario), typeof(LeftWalkingEnemyState), typeof(LeftCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Goomba), typeof(StarMario), typeof(LeftWalkingEnemyState), typeof(RightCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },

                { (typeof(Goomba), typeof(StarMario), typeof(RightWalkingEnemyState), typeof(TopCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Goomba), typeof(StarMario), typeof(RightWalkingEnemyState),typeof(BottomCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Goomba), typeof(StarMario), typeof(RightWalkingEnemyState), typeof(LeftCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Goomba), typeof(StarMario), typeof(RightWalkingEnemyState), typeof(RightCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },

                { (typeof(Koopa), typeof(StarMario), typeof(LeftWalkingEnemyState), typeof(TopCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(StarMario), typeof(LeftWalkingEnemyState),typeof(BottomCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(StarMario), typeof(LeftWalkingEnemyState), typeof(LeftCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(StarMario), typeof(LeftWalkingEnemyState), typeof(RightCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },

                { (typeof(Koopa), typeof(StarMario), typeof(RightWalkingEnemyState), typeof(TopCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(StarMario), typeof(RightWalkingEnemyState),typeof(BottomCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(StarMario), typeof(RightWalkingEnemyState), typeof(LeftCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(StarMario), typeof(RightWalkingEnemyState), typeof(RightCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },

                { (typeof(Koopa), typeof(StarMario), typeof(ShellEnemyState), typeof(TopCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(StarMario), typeof(ShellEnemyState),typeof(BottomCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(StarMario), typeof(ShellEnemyState), typeof(LeftCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },
                { (typeof(Koopa), typeof(StarMario), typeof(ShellEnemyState), typeof(RightCollision)), typeof(FlipEnemyCommand).GetConstructors()[0] },


                { (typeof(Goomba), typeof(BlinkingMario), typeof(LeftWalkingEnemyState), typeof(BottomCollision)), typeof(PushPlayerUpStompEnemyCommand).GetConstructors()[0] },

                { (typeof(Goomba), typeof(BlinkingMario), typeof(RightWalkingEnemyState), typeof(BottomCollision)), typeof(PushPlayerUpStompEnemyCommand).GetConstructors()[0] },

                { (typeof(Koopa), typeof(BlinkingMario), typeof(LeftWalkingEnemyState), typeof(BottomCollision)), typeof(PushPlayerUpStompEnemyCommand).GetConstructors()[0] },

                { (typeof(Koopa), typeof(BlinkingMario), typeof(RightWalkingEnemyState), typeof(BottomCollision)), typeof(PushPlayerUpStompEnemyCommand).GetConstructors()[0] },

                { (typeof(Koopa), typeof(BlinkingMario), typeof(ShellEnemyState), typeof(BottomCollision)), typeof(PushPlayerUpDisarmEnemyCommand).GetConstructors()[0] }
            };
        }
    }
}
