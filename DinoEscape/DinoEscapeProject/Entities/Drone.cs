#region Using Statements
using DinoEscapeProject.Behaviors;
using DinoEscapeProject.Resources;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
#endregion

namespace DinoEscapeProject.Entities
{
    public class Drone : Enemy
    {
        public Drone()
        {
            this.entity = new Entity()
                .AddComponent(new Transform2D(){
                    XScale = 0.3f,
                    YScale = 0.3f,
                    Y = 50,
                    Origin = Vector2.Center
                })
                .AddComponent(new Sprite(Textures.DRONE))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider())
                .AddComponent(new DroneBehavior());
        }
    }
}
