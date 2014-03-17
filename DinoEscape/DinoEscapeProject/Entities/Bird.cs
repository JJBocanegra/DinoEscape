#region Using Statements
using DinoEscapeProject.Behaviors;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;
#endregion

namespace DinoEscapeProject.Entities
{
    public class Bird : BaseDecorator
    {
        private readonly int[] direction =
        {
            -20,
            (int)WaveServices.ViewportManager.VirtualWidth + 20
        };
        public Bird()
        {
            this.entity = new Entity()
                .AddComponent(new Transform2D()
                {
                    X = this.direction[WaveServices.Random.Next(0, 2)],
                    Y = 50,
                    XScale = 0.1f,
                    YScale = 0.1f
                })
                .AddComponent(new Sprite("Content/Enemies/bird.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider())
                .AddComponent(new BirdBehavior());
        }
    }
}
