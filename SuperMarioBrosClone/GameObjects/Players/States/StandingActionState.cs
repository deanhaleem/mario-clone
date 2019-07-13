namespace SuperMarioBrosClone.GameObjects.Players.States
{
    internal class StandingActionState : ActionState
    {
        public StandingActionState(IPlayer player) : base(player)
        {
            base.Player.CutXVelocity();
            base.Player.CutYVelocity();
        }

        public override void Jump()
        {
            Player.ActionState = new JumpingActionState(Player);
        }

        public override void WalkRight()
        {
            if (Player.Direction == Directions.Right)
            {
                Player.ActionState = new WalkingActionState(Player);
            }
            else
            {
                Player.Direction = Directions.Right;
            }
        }

        public override void WalkLeft()
        {
            if (Player.Direction == Directions.Left)
            {
                Player.ActionState = new WalkingActionState(Player);
            }
            else
            {
                Player.Direction = Directions.Left;
            }
        }

        public override void Crouch()
        {
            Player.ActionState = new CrouchingActionState(Player);
        }

        public override void Fall()
        {
            Player.ActionState = new FallingActionState(Player);
        }
    }
}