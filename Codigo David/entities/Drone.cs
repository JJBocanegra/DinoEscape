using DinoEscapeProject.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;

namespace DinoEscapeProject.Entities
{
    class Drone : BaseDecorator
    {

        public Drone()
        {
            this.entity = new Entity()
            .AddComponent(new Transform2D(){
                Origin = Vector2.Center,
                X = 0,
                Y = 50
            })

            .AddComponent(new Sprite("Content/Enemies/aircraft.wpk"))
            .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
            .AddComponent(new RectangleCollider())
            .AddComponent(new DroneBehavior());
        }

       

    }
}
