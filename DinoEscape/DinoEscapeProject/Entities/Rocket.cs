#region Using Statements
using DinoEscapeProject.Behaviors;
using DinoEscapeProject.Resources;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;
#endregion

namespace DinoEscapeProject.Entities
{
    public class Rocket : BaseDecorator
    {
        public static int speed;

        public Rocket()
        {
            speed = 100;

            this.entity = new Entity()
                .AddComponent(new Transform2D()
                {
                    X = WaveServices.ViewportManager.VirtualWidth / 2,
                    Origin = Vector2.Center
                })
                .AddComponent(new Sprite(Textures.ROCKET))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider())
                .AddComponent(new RocketBehavior());
        }
    }
}
