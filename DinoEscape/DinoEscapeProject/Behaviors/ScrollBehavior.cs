using DinoEscapeProject.Entities;
using System;
using WaveEngine.Common.Math;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;

namespace DinoEscapeProject.Behaviors
{
    class ScrollBehavior : Behavior
    {
        [RequiredComponent]
        private Transform2D transform2D;

        private int speed;
        private float offsetWidth;
        private float offsetHeight;
        public Action<Entity> EntityOutOfScreen;

        protected override void Initialize()
        {
            base.Initialize();

            speed = Rocket.Speed;
            offsetWidth = (transform2D.Rectangle.Width / 2) * transform2D.XScale;
            offsetHeight = (transform2D.Rectangle.Height / 2) * transform2D.YScale;
        }

        protected override void Update(TimeSpan gameTime)
        {
            transform2D.Y += speed * (float)gameTime.TotalSeconds;

            if (transform2D.Y > WaveServices.ViewportManager.BottomEdge + offsetHeight
            || transform2D.X > WaveServices.ViewportManager.RightEdge + offsetWidth
            || transform2D.X < WaveServices.ViewportManager.LeftEdge - offsetWidth)
                EntityOutOfScreen(this.Owner);
        }

        private void OnEntityOutOfScreen(Entity entity)
        {
            if (this.EntityOutOfScreen != null)
                this.EntityOutOfScreen(entity);
        }

        public void EntityEnabled()
        {
            transform2D.Y = - offsetHeight;
            transform2D.X = WaveServices.Random.Next(
                (int)(WaveServices.ViewportManager.LeftEdge - offsetWidth), 
                (int)(WaveServices.ViewportManager.RightEdge + offsetWidth));
        }
    }
}
