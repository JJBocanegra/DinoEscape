using DinoEscapeProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;

namespace DinoEscapeProject.Behaviors
{
    class ScrollBehavior : Behavior
    {
        [RequiredComponent]
        private Transform2D transform2D;

        private int speed;

        protected override void Initialize()
        {
            base.Initialize();

            speed = Rocket.speed;
        }

        protected override void Update(TimeSpan gameTime)
        {
            transform2D.Y += speed * (float)gameTime.TotalSeconds;
        }
    }
}
