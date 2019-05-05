using System;
using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class LeftActionState : ActionState
    {
        public LeftActionState(IPlayer player) : base(player)
        {

        }

        public override void Stand()
        {
            Player.ActionState = new LeftStandingActionState(Player);
        }

        public override void Attack(Type projectileType)
        {
            ProjectileFactory.Instance.CreateLeftProjectile(projectileType, Player.HitBox);
        }

        public override void Upgrade()
        {
            Player.ActionState = new LeftUpgradingActionState(Player);
        }

        public override void Downgrade()
        {
            Player.ActionState = new LeftDowngradingActionState(Player);
        }

        public override void WinLevel()
        {
            Player.ActionState = new LeftVictoryActionState(Player);
        }

        public override void Warp(Vector2 location, Vector2 velocity)
        {
            Player.ActionState = new LeftWarpingActionState(Player, location, velocity);
        }
    }
}
