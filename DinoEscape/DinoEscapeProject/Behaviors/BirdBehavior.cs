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

            speed               = WaveServices.Random.Next(20, 100);
            offset              = (transform2D.Rectangle.Width / 2) * transform2D.XScale;
            position            = new float[] { -offset, (int)WaveServices.ViewportManager.RightEdge + offset };

            transform2D.X = this.position[WaveServices.Random.Next(0, 2)];

            direction = "Left"; //Forzamos que vaya a la izquierda para probar
           /* if (transform2D.X <= 0)
                direction = "Right";
            else
            {
                direction = "Left";
                transform2D.Effect = SpriteEffects.FlipHorizontally;
            }*/
        }

        protected override void Update(TimeSpan gameTime)
        {
            Move(gameTime);
        }

        private void Move(TimeSpan gameTime)
        {
            Labels.Add("BirdX", transform2D.X.ToString());
            Labels.Add("BirdY", transform2D.Y.ToString());
            Labels.Add("OriginX", transform2D.Origin.X.ToString());
            Labels.Add("OriginY", transform2D.Origin.Y.ToString());

            float X = transform2D.X;

            if (direction == "Right")
                X += speed * (float)gameTime.TotalSeconds;
            else
                X -= speed * (float)gameTime.TotalSeconds;

            transform2D.X = X;
        }
    }
}
