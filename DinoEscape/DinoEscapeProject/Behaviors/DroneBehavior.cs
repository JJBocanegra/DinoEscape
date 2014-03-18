﻿using System;
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
            offset  = (this.transform2D.Rectangle.Width / 2) * this.transform2D.XScale;

            if (this.transform2D.X <= offset)
                direction = "Right";
            else
            {
                direction = "Left";
                this.transform2D.Effect = SpriteEffects.FlipHorizontally;
            }
        }

        protected override void Update(TimeSpan gameTime)
        {
            Move(gameTime);
        }

        private void Move(TimeSpan gameTime)
        {
            float X = this.transform2D.X;

            if (direction == "Right")
            {
                if (X > WaveServices.ViewportManager.VirtualWidth - offset)
                    direction = "Left";
                else
                    X += speed * (float)gameTime.TotalSeconds;
            }
            else
            {
                if (X < offset)
                    direction = "Right";
                else
                    X -= speed * (float)gameTime.TotalSeconds;
            }

            this.transform2D.X = X;
        }
    }
}
