using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarioBrosClone.Graphics
{
    internal class Sprite : ISprite
    {
        private readonly Dictionary<string, Rectangle[]> sourceFrames;
        private readonly Texture2D spriteSheet;
        private readonly List<Point> spriteSizes;
        private readonly float spriteScale;
        private readonly float spriteDepth;
        private readonly int totalColorTints;
        private readonly int colorTintDelay;
        private readonly int totalFrames;
        private readonly int frameDelay;

        private int currentColorTint;
        private int colorTintDelayTimer;
        private int currentFrame;
        private int frameDelayTimer;

        private Vector2 SpriteOrigin => new Vector2(sourceFrames[currentColorTint.ToString()][currentFrame].Width / 2f,
            sourceFrames[currentColorTint.ToString()][currentFrame].Height);

        private int CurrentFrame
        {
            get => currentFrame;
            set
            {
                if (frameDelayTimer % frameDelay == 0)
                {
                    currentFrame = value == totalFrames ? 0 : value;
                }
                frameDelayTimer++;
            }
        }

        private int CurrentColorTint
        {
            get => currentColorTint;
            set
            {
                if (colorTintDelayTimer % colorTintDelay == 0)
                {
                    currentColorTint = value == totalColorTints ? 0 : value;
                }
                colorTintDelayTimer++;
            }
        }

        public Point Size => new Point(spriteSizes[currentFrame].X * (int)spriteScale, spriteSizes[currentFrame].Y * (int)spriteScale);

        public Sprite(Texture2D texture, SpriteRegistrar spriteRegistrar)
        {
            this.spriteSheet = texture;
            this.sourceFrames = spriteRegistrar.SourceFrames;
            this.spriteSizes = spriteRegistrar.Sizes.ToList();
            this.spriteScale = spriteRegistrar.Scale;
            this.spriteDepth = spriteRegistrar.LayerDepth;
            this.totalFrames = sourceFrames["0"].Length;
            this.frameDelay = spriteRegistrar.FrameDelay;
            this.totalColorTints = sourceFrames.Keys.Count;
            this.colorTintDelay = spriteRegistrar.ColorTintDelay;
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame++;
            CurrentColorTint++;
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            spriteBatch.Draw(spriteSheet, location, sourceFrames[currentColorTint.ToString()][currentFrame],
                color, 0, SpriteOrigin, spriteScale, SpriteEffects.None, spriteDepth);

            if (Game1.Instance.IsShowingRectangles)
            {
                const int lineWidth = 3;
                location -= new Vector2(Size.X / 2f, Size.Y);

                spriteBatch.Draw(SpriteFactory.Instance.BlankTexture, location,
                    new Rectangle(0, 0, lineWidth, Size.Y + lineWidth), Color.Red, 0f, Vector2.Zero, 1f,
                    SpriteEffects.None, 1f);
                spriteBatch.Draw(SpriteFactory.Instance.BlankTexture, location,
                    new Rectangle(0, 0, Size.X + lineWidth, lineWidth), Color.Red, 0f, Vector2.Zero, 1f,
                    SpriteEffects.None, 1f);
                spriteBatch.Draw(SpriteFactory.Instance.BlankTexture, location + new Vector2(Size.X, 0),
                    new Rectangle(0, 0, lineWidth, Size.Y + lineWidth), Color.Red, 0f, Vector2.Zero, 1f,
                    SpriteEffects.None, 1f);
                spriteBatch.Draw(SpriteFactory.Instance.BlankTexture, location + new Vector2(0, Size.Y),
                    new Rectangle(0, 0, Size.X + lineWidth, lineWidth), Color.Red, 0f, Vector2.Zero, 1f,
                    SpriteEffects.None, 1f);
            }
        }
    }
}
