using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace SuperMarioBrosClone
{
    internal class TimedActionManager
    {
        private Queue<(Action<float>, Action, float)> timedActions = new Queue<(Action<float>, Action, float)>();

        public static TimedActionManager Instance { get; } = new TimedActionManager();

        private TimedActionManager()
        {

        }

        public void Update(GameTime gameTime)
        {
            int count = timedActions.Count;
            for (int i = 0; i < count && timedActions.Count > 0; i++)
            {
                (var timedAction, var postTimedAction, float time) = timedActions.Dequeue();

                float updatedTime = time - (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (updatedTime <= 0)
                {
                    postTimedAction();
                }
                else
                {
                    timedAction?.Invoke(updatedTime);
                    timedActions.Enqueue((timedAction, postTimedAction, updatedTime));
                }
            }
        }

        public void RegisterTimedAction(Action<float> timedAction, Action postTimedAction, float time)
        {
            timedActions.Enqueue((timedAction, postTimedAction, time));
        }

        public void Reset()
        {
            timedActions = new Queue<(Action<float>, Action, float)>();
        }
    }
}
