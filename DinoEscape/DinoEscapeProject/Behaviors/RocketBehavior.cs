#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;
#endregion

namespace DinoEscapeProject.Behaviors
{
    class RocketBehavior : Behavior
    {
        [RequiredComponent]
        private Transform2D transform2D;

        private int speed;
        private float offset;

        protected override void Initialize()
        {
            base.Initialize();

            speed   = 500;
            offset  = (transform2D.Rectangle.Width / 2) * transform2D.XScale;

            transform2D.Y = (float)(WaveServices.ViewportManager.VirtualHeight - (transform2D.Rectangle.Height * 0.75f) * transform2D.XScale);
        }

        protected override void Update(TimeSpan gameTime)
        {
            Move(gameTime);
        }

        private void Move(TimeSpan gameTime)
        {
            float movement  = speed * (float)gameTime.TotalSeconds;
            float X         = transform2D.X;

            if (WaveServices.Input.KeyboardState.IsConnected)
            {
                if ((WaveServices.Input.KeyboardState.Left == WaveEngine.Common.Input.ButtonState.Pressed
                || WaveServices.Input.KeyboardState.A == WaveEngine.Common.Input.ButtonState.Pressed)
                && X > offset)
                {
                    X -= movement;
                }
                else if ((WaveServices.Input.KeyboardState.Right == WaveEngine.Common.Input.ButtonState.Pressed
                || WaveServices.Input.KeyboardState.D == WaveEngine.Common.Input.ButtonState.Pressed)
                && X <= WaveServices.ViewportManager.VirtualWidth - offset)
                {
                    X += movement;
                }

                //Evitamos que sobresalga por los bordes
                if (X < offset)
                    X = offset;
                else if (X > WaveServices.ViewportManager.VirtualWidth - offset)
                    X = WaveServices.ViewportManager.VirtualWidth - offset;

                transform2D.X = X;
            }
        }
    }
}
