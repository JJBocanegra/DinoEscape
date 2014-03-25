using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Common.Graphics;
using WaveEngine.Framework;
using WaveEngine.Framework.Diagnostic;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;

namespace DinoEscapeProject.Behaviors
{
    class DroneBehavior : Behavior
    {

        [RequiredComponent]
        private Transform2D transform2D;

        private int speed;
        private float offset;
        private string direction;
        
        protected override void Initialize()
        {
            base.Initialize();

            speed   = 300;
            offset  = (transform2D.Rectangle.Width / 2) * transform2D.XScale;

            if (transform2D.X <= offset)
                direction = "Right";
            else
            {
                direction = "Left";
                transform2D.Effect = SpriteEffects.FlipHorizontally;
            }
        }

        protected override void Update(TimeSpan gameTime)
        {
            Move(gameTime);
        }

        private void Move(TimeSpan gameTime)
        {
            if (direction == "Right")
            {
                if (transform2D.X > WaveServices.ViewportManager.RightEdge - offset)
                    direction = "Left";
                else
                    transform2D.X += speed * (float)gameTime.TotalSeconds;
            }
            else
            {
                if (transform2D.X < offset)
                    direction = "Right";
                else
                    transform2D.X -= speed * (float)gameTime.TotalSeconds;
            }
        }
    }
}
