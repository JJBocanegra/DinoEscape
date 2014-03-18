#region Using Statements
using DinoEscapeProject.Behaviors;
using DinoEscapeProject.Entities;
using FlyingKiteProject.Behaviors;
using System.Diagnostics;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Framework;
using WaveEngine.Framework.Diagnostic;
using WaveEngine.Framework.Graphics;

#endregion

namespace DinoEscapeProject
{
    public class GameScene : Scene
    {
        protected override void CreateScene()
        {
            RenderManager.BackgroundColor = Color.FloralWhite;

            EntityManager.Add(EntitiesFactory.CreateRocket());
            //EntityManager.Add(EntitiesFactory.CreateEnemiesEmitter());
            EntityManager.Add(EntitiesFactory.CreateDrone().entity);

#if DEBUG
            //Labels.Add("Prueba", "valor");
            this.AddSceneBehavior(new DebugSceneBehavior(), SceneBehavior.Order.PreUpdate);
#endif
        }
    }
}
