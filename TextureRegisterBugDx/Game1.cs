using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TextureRegisterBug
{
    public class Game1 : Game
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
 
        Texture2D texture;
        Effect effect;
        VertexPositionTexture[] vertices = {
            new VertexPositionTexture(new Vector3(-1, 1, 0),  new Vector2(0, 1)), 
            new VertexPositionTexture(new Vector3(1, 1, 0),   new Vector2(1, 1)), 
            new VertexPositionTexture(new Vector3(-1, -1, 0), new Vector2(0, 0)), 
        };

        public Game1()
        {
            new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            effect = Content.Load<Effect>("effect");
            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] {Color.Red.PackedValue});
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            effect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.Textures[0] = texture;

            GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 1);

            base.Draw(gameTime);
        }
    }
}
