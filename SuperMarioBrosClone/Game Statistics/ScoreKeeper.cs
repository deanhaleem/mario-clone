using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace SuperMarioBrosClone
{
    internal class ScoreKeeper
    {
        private readonly Dictionary<string, int> points;
        private readonly Dictionary<string, string> pointAllocatorNames;
        private int enemiesKilledConsecutively;

        public int Score { get; private set; }

        public ScoreKeeper(string pointsFile, string allocatorNamesFile)
        {
            points = new JavaScriptSerializer().Deserialize<Dictionary<string, int>>(ReadAllText(pointsFile));
            pointAllocatorNames = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(ReadAllText(allocatorNamesFile));
        }

        public void GainPoints(Rectangle pointEventIntersection, string pointEventName)
        {
            if (pointAllocatorNames.ContainsKey(pointEventName))
            {
                GetType().GetMethod(pointAllocatorNames[pointEventName])?.Invoke(this, new object[] { pointEventIntersection, pointEventName });
            }
            else
            {
                AllocatePoints(pointEventName);
            }
        }

        private void AllocatePoints(string pointEventName)
        {
            Score += points[pointEventName];
        }

        public void AllocatePointsWithIndicator(Rectangle pointEventIntersection, string pointEventName)
        {
            Score += points[pointEventName];
            IndicatorFactory.CreateIndicator(pointEventIntersection, points[pointEventName]);
        }

        public void AllocateConsecutivePoints(Rectangle pointEventIntersection, string pointEventName)
        {
            int pointsGained = points[pointEventName] + points[pointEventName] * enemiesKilledConsecutively++ / 2;
            Score += pointsGained;
            IndicatorFactory.CreateIndicator(pointEventIntersection, pointsGained);
        }

        public void AllocateFlagpolePoints(Rectangle pointEventIntersection, string pointEventName)
        {
            int pointsGained = (-pointEventIntersection.Top + Utilities.FlagpoleBonusPoints) * points[pointEventName];
            Score += pointsGained;
            IndicatorFactory.CreateIndicator(pointEventIntersection, pointsGained);
        }

        public void ResetConsecutivePointCount()
        {
            enemiesKilledConsecutively = 0;
        }

        public void Reset()
        {
            Score = 0;
            enemiesKilledConsecutively = 0;
        }
    }
}
