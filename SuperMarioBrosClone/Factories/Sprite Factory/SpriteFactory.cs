using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Microsoft.Xna.Framework;
using static System.IO.File;

namespace SuperMarioBrosClone
{
    internal class SpriteFactory
    {
        public static SpriteFactory Instance { get; } = new SpriteFactory();

        public Texture2D BlankTexture { get; } = new Texture2D(Game1.Instance.GraphicsDevice, 1, 1);
        public SpriteFont Font { get; private set; }

        private readonly Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        private Dictionary<string, SpriteRegistrar> spriteRegistrars;
        private Dictionary<string, string> spriteNames;

        private SpriteFactory()
        {

        }

        public void LoadContent(string texturesFile, string spriteRegistrarsFile, string spriteNamesFile, string fontFileName)
        {
            Font = Game1.Instance.Content.Load<SpriteFont>(fontFileName);
            spriteNames = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(ReadAllText(spriteNamesFile));
            spriteRegistrars = new JavaScriptSerializer().Deserialize<Dictionary<string, SpriteRegistrar>>(ReadAllText(spriteRegistrarsFile));

            var textureFiles = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(ReadAllText(texturesFile));
            foreach (string textureName in textureFiles.Keys)
            {
                textures.Add(textureName, Game1.Instance.Content.Load<Texture2D>(textureFiles[textureName]));
            }

            BlankTexture.SetData(new[] { Color.White });
        }

        public ISprite CreateSprite(string objectName)
        {
            var spriteRegistrar = spriteRegistrars[spriteNames[objectName]];
            return new Sprite(textures[spriteRegistrar.TextureName], spriteRegistrar);
        }
    }
}
