using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;

namespace DinoEscapeProject.Behaviors
{
    class PlaneBehavior : Behavior{

        [RequiredComponent]
        private Transform2D transform;

        private string direction;

        protected override void Initialize()
        {
            base.Initialize();

            if (this.transform.X <= 0)
                direction = "Right";
            else
            {
                direction = "Left";
                this.transform.XScale = -this.transform.XScale;               
            }
        }

        protected override void Update(TimeSpan gameTime)
        {
            Movement(gameTime);
        }

        private void Movement(TimeSpan gameTime)
        {
            if (direction == "Right")
                this.transform.X += 100 * (float)gameTime.TotalSeconds;
            else
                this.transform.X -= 100 * (float)gameTime.TotalSeconds;
        }
        
        


    


    }
}

