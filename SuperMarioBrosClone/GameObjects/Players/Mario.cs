﻿using Microsoft.Xna.Framework;
using SuperMarioBrosClone.GameObjects.Players.States;

namespace SuperMarioBrosClone.GameObjects.Players
{
    internal class Mario : Player
    {
        public Mario(Vector2 location, Color color) : base(location, color)
        {
            base.PowerUpState = new SmallPowerUpState(this);
            base.ActionState = new StandingActionState(this);
            base.Direction = Directions.Right;
        }
    }
}
