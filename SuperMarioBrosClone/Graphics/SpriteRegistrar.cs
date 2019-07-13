using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SuperMarioBrosClone.Graphics
{
    internal class SpriteRegistrar
    {
        public Dictionary<string, Rectangle[]> SourceFrames { get; set; }
        public Point[] Sizes { get; set; }
        public float Scale { get; set; }
        public string TextureName { get; set; }
        public float LayerDepth { get; set; }
        public int FrameDelay { get; set; }
        public int ColorTintDelay { get; set; }
    }
}
