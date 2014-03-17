using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;

namespace DinoEscapeProject.Entities
{
    class Rocket : BaseDecorator
    {
        public Rocket()
        {
            this.entity = new Entity()

                .AddComponent(new Transform2D() {
                    X = WaveServices.ViewportManager.VirtualWidth / 2,
                    Y = WaveServices.ViewportManager.VirtualHeight - 100,
                    XScale = 0.5f,
                    YScale = 0.5f
                    })
                .AddComponent(new Sprite("Content/Rocket/Rocket.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new MyBehavior());
        }
    }

    class MyBehavior : Behavior
    {
        [RequiredComponent]
        private Transform2D transform;

        protected override void Update(TimeSpan gameTime)
        {
            this.transform.Y -= 100 * (float)gameTime.TotalSeconds;

            if (WaveServices.Input.KeyboardState.Right == WaveEngine.Common.Input.ButtonState.Pressed)
            {
                this.transform.X += 100 * (float)gameTime.TotalSeconds;
            }
            else if (WaveServices.Input.KeyboardState.Left == WaveEngine.Common.Input.ButtonState.Pressed)
            {
                this.transform.X -= 100 * (float)gameTime.TotalSeconds;
            }
        }
    }
}
