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
        private Transform2D transform;

        private int speed;
        private int offset;
        private string direction;
        private int[] position;

        protected override void Initialize()
        {
            base.Initialize();

            speed = 100;
            offset = (int)this.transform.Rectangle.Width / 2;
            position = new int[] { -offset, (int)WaveServices.ViewportManager.VirtualWidth + offset };
            this.transform.X = this.position[WaveServices.Random.Next(0, 2)];

            if (this.transform.X <= 0)
                direction = "Right";
            else
            {
                direction = "Left";
                this.transform.Effect = SpriteEffects.FlipHorizontally;
            }
        }

        protected override void Update(TimeSpan gameTime)
        {
            Movement(gameTime);
        }

        private void Movement(TimeSpan gameTime)
        {
            Labels.Add("BirdX", this.transform.X.ToString());
            Labels.Add("BirdY", this.transform.Y.ToString());

            if (this.transform.X < -offset - 10 || this.transform.X > WaveServices.ViewportManager.VirtualWidth + offset + 10)
                this.EntityManager.Remove(this.Owner);

            if (direction == "Right")
                this.transform.X += speed * (float)gameTime.TotalSeconds;
            else
                this.transform.X -= speed * (float)gameTime.TotalSeconds;
        }
    }
}
