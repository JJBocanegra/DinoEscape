﻿#region Using Statements
using DinoEscapeProject.Behaviors;
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
        public Rocket()
        {
            this.entity = new Entity()
                .AddComponent(new Transform2D()
                {
                    X = WaveServices.ViewportManager.VirtualWidth / 2,
                    Y = WaveServices.ViewportManager.VirtualHeight - 250                  
                })
                .AddComponent(new Sprite("Content/Rocket/Rocket.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new RectangleCollider())
                .AddComponent(new RocketBehavior());
        }
    }
}
