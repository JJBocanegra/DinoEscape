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

        /// <summary>
        /// Initialize a new instance of the Rocket class
        /// </summary>
        public Rocket()
        {
            speed = 100;

            this.entity = new Entity()
                .AddComponent(new Transform2D(){
                    X = WaveServices.ViewportManager.VirtualWidth / 2,
                    XScale = 0.8f,
                    YScale = 0.8f,
                    Origin = Vector2.Center
                })
                .AddComponent(new Sprite(Textures.ROCKET))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider())
                .AddComponent(new RocketBehavior());
        }
    }
}
