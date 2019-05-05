using System;
using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class RightActionState : ActionState
    {
        public RightActionState(IPlayer player) : base(player)
        {

        }

        public override void Stand()
        {
            Player.ActionState = new RightStandingActionState(Player);
        }

        public override void Attack(Type projectileType)
        {
            ProjectileFactory.Instance.CreateRightProjectile(projectileType, Player.HitBox);
        }

        public override void Upgrade()
        {
            Player.ActionState = new RightUpgradingActionState(Player);
        }

        public override void Downgrade()
        {
            Player.ActionState = new RightDowngradingActionState(Player);
        }

        public override void WinLevel()
        {
            Player.ActionState = new RightVictoryActionState(Player);
        }

        public override void Warp(Vector2 location, Vector2 velocity)
        {
            Player.ActionState = new RightWarpingActionState(Player, location, velocity);
        }
    }
}
