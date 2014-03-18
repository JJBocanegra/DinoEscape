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
    public class Bird : Enemy
    {
        

        public Bird()
        {
            this.entity = new Entity()
                .AddComponent(new Transform2D()
                {
                    XScale = 0.5f,
                    YScale = 0.5f,
                    Origin = Vector2.Center
                })
                .AddComponent(new Sprite(Textures.BIRD))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider())
                .AddComponent(new BirdBehavior())
                .AddComponent(new ScrollBehavior());
        }
    }
}
