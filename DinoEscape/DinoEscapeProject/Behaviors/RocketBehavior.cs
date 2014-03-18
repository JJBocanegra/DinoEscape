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
        private Transform2D transform;

        private int speed;
        private int offset;

        protected override void Initialize()
        {
            base.Initialize();

            speed = 500;
            offset = (int)this.transform.Rectangle.Width / 2;
            this.transform.Y = WaveServices.ViewportManager.VirtualHeight - this.transform.Rectangle.Height / 2;
        }

        protected override void Update(TimeSpan gameTime)
        {
            Movement(gameTime);
        }

        private void Movement(TimeSpan gameTime)
        {
            if (WaveServices.Input.KeyboardState.IsConnected)
            {
                if ((WaveServices.Input.KeyboardState.Left == WaveEngine.Common.Input.ButtonState.Pressed
                || WaveServices.Input.KeyboardState.A == WaveEngine.Common.Input.ButtonState.Pressed)
                && this.transform.X > offset)
                {
                    this.transform.X -= speed * (float)gameTime.TotalSeconds;
                }
                else if ((WaveServices.Input.KeyboardState.Right == WaveEngine.Common.Input.ButtonState.Pressed
                || WaveServices.Input.KeyboardState.D == WaveEngine.Common.Input.ButtonState.Pressed)
                && this.transform.X < WaveServices.ViewportManager.VirtualWidth - offset)
                {
                    this.transform.X += speed * (float)gameTime.TotalSeconds;
                }
            }
        }
    }
}
