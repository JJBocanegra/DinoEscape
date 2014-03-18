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
    class Aircraft : Enemy
    {
        public Aircraft()
        {
            this.entity = new Entity()
                .AddComponent(new Transform2D(){
                    Origin = Vector2.Center
                })
                .AddComponent(new Sprite(Textures.AIRCRAFT))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider())
                .AddComponent(new AircraftBehavior());
        }
    }
}
