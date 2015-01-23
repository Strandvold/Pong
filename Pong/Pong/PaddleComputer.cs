using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pong
{
    class PaddleComputer : Paddle 
    {
        private int maxYChange;

        public PaddleComputer(Game game)
            : base(game) { }

        public override void Initialize()
        {
            base.Initialize();

            // Make sure base.Initialize() is called before this or handSprite will be null
            X = GraphicsDevice.Viewport.Width - Width;
            Y = GraphicsDevice.Viewport.Height / 2 - (Height / 2);
            maxYChange = 7;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            paddleSprite = contentManager.Load<Texture2D>(@"Content\Images\opponentHand");
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // Scale the movement based on time
            float moveDistance = Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Move paddle, but don't allow movement off the screen
            Ball ball = Game.Components[0] as Ball;

            if (ball.Y + ball.Height > Y && ball.Y + ball.Height < Y + Height)
            {
                //do nothing;
            }

            else if (ball.Y > Y && ball.Y < Y + Height)
            {
                //do nothing;
            }

            else if (ball.Y > Y)
            {
                Y = Y + maxYChange;
                if (Y > GraphicsDevice.Viewport.Height - Height)
                {
                    Y = GraphicsDevice.Viewport.Height - Height;
                }
            }
            else
            {
                Y = Y - maxYChange;
                if (Y < 0)
                {
                    Y = 0;
                }
            }

            base.Update(gameTime);
        }
    }
}
