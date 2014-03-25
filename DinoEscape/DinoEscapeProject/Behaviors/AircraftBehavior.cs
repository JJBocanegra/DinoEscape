using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Common.Graphics;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;

namespace DinoEscapeProject.Behaviors
{
    class AircraftBehavior : Behavior
    {

        [RequiredComponent]
        private Transform2D transform2D;

        private int speed;
        private float offset;
        private string direction;
        private float[] position;

        protected override void Initialize()
        {
            base.Initialize();

            speed       = 100;
            offset      = (transform2D.Rectangle.Width / 2) * transform2D.XScale;
            position    = new float[] { -offset, (int)WaveServices.ViewportManager.RightEdge + offset };

            transform2D.X = this.position[WaveServices.Random.Next(0, 2)];

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
            float movement  = speed * (float)gameTime.TotalSeconds;
            float X         = transform2D.X;

            if (X < -offset
            || X > WaveServices.ViewportManager.RightEdge + offset)
                this.EntityManager.Remove(this.Owner);

            if (direction == "Right")
                X += movement;
            else
                X -= movement;

            transform2D.X = X;
        }
    }
}

