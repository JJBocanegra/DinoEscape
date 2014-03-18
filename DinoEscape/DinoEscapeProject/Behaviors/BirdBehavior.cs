#region Using Statements
using System;
using WaveEngine.Common.Graphics;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Diagnostic;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;

#endregion

namespace DinoEscapeProject.Behaviors
{
    class BirdBehavior : Behavior
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

            speed               = 100;
            offset              = (this.transform2D.Rectangle.Width / 2) * this.transform2D.XScale;
            position            = new float[] { -offset, (int)WaveServices.ViewportManager.VirtualWidth + offset };

            this.transform2D.X = this.position[WaveServices.Random.Next(0, 2)];

            if (this.transform2D.X <= 0)
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
            Labels.Add("BirdX", this.transform2D.X.ToString());
            Labels.Add("BirdY", this.transform2D.Y.ToString());

            float X = this.transform2D.X;

            if (X < -offset 
            || X > WaveServices.ViewportManager.VirtualWidth + offset)
                this.EntityManager.Remove(this.Owner);

            if (direction == "Right")
                X += speed * (float)gameTime.TotalSeconds;
            else
                X -= speed * (float)gameTime.TotalSeconds;

            this.transform2D.X = X;
        }
    }
}
