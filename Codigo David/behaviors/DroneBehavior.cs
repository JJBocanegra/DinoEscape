using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;

namespace DinoEscapeProject.Behaviors
{
    class DroneBehavior : Behavior
    {

        [RequiredComponent]
        private Transform2D transform;

        private int offset;
        private string direction;
        private int speed;
        
        protected override void Initialize()
        {
            base.Initialize();
            speed = 100;

            if (this.transform.X <= 0)
                direction = "Right";
            else
            {
                direction = "Left";
                this.transform.XScale = -this.transform.XScale;//ojo
            }
        }

        protected override void Update(TimeSpan gameTime)
        {
            Movement(gameTime);
        }

        private void Movement(TimeSpan gameTime)
        {
            offset = (int)this.transform.Rectangle.Width / 2;
            if (direction == "Right")
            {
                if (this.transform.X > WaveServices.ViewportManager.VirtualWidth - offset)
                {
                    direction = "Left";
                }
                else
                {
                    this.transform.X += speed * (float)gameTime.TotalSeconds;
                }
            }
            else
            {
                if (this.transform.X < offset)
                {
                    direction = "Right";
                }
                else
                {
                    this.transform.X -= speed * (float)gameTime.TotalSeconds;
                }


            }
                
        }

    }
}
