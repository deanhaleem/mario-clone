﻿namespace SuperMarioBrosClone
{
    internal class RightRunningActionState : RightActionState
    {
        public RightRunningActionState(IPlayer player) : base(player)
        {
            base.Player.ApplyForce(Physics.PlayerHorizontalAcceleration);
            base.Player.SetMaxVelocity(Physics.PlayerMaxRunningVelocity);
        }

        public override void Jump()
        {
            Player.ActionState = new RightJumpingActionState(Player);
        }

        public override void WalkLeft()
        {
            Player.ActionState = new LeftSlidingActionState(Player);
        }

        public override void Crouch()
        {
            Player.ActionState = new RightCrouchingActionState(Player);
        }

        public override void Fall()
        {
            Player.ActionState = new RightFallingActionState(Player);
        }

        public override void StopMovingRight()
        {
            Player.ActionState = new LeftSlidingActionState(Player);
        }

        public override void StopRunning()
        {
            Player.ActionState = new RightWalkingActionState(Player);
        }
    }
}