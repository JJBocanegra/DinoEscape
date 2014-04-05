using DinoEscapeProject.Behaviors;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;

namespace DinoEscapeProject.Entities
{
    public class Enemy : BaseDecorator
    {
        public Entity entity;

        public Enemy()
        {
            var scrollBehavior = new ScrollBehavior();
            this.entity = new Entity()
                .AddComponent(scrollBehavior);

            scrollBehavior.EntityOutOfScreen += (entity) =>
            {
                entity.Enabled = false;
            };

        }
    }
}
