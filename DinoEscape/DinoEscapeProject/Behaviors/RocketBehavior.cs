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
                && this.transform.X > 0)
                {
                    this.transform.X -= 500 * (float)gameTime.TotalSeconds;
                }
                else if ((WaveServices.Input.KeyboardState.Right == WaveEngine.Common.Input.ButtonState.Pressed
                || WaveServices.Input.KeyboardState.D == WaveEngine.Common.Input.ButtonState.Pressed)
                && this.transform.X < WaveServices.ViewportManager.VirtualWidth)
                {
                    this.transform.X += 500 * (float)gameTime.TotalSeconds;
                }
            }
        }
    }
}
