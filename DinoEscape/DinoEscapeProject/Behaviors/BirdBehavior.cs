#region Using Statements
using System;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;

#endregion

namespace DinoEscapeProject.Behaviors
{
    class BirdBehavior : Behavior
    {
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
                this.transform.XScale = -0.1f;
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
