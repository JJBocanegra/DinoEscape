#region Using Statements
using DinoEscapeProject.Behaviors;
using DinoEscapeProject.Entities;
using FlyingKiteProject.Behaviors;
using System.Diagnostics;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.UI;
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

            //Hacemos que el motor siga dibujando los objetos aunque estén fuera de la pantalla (QUITAR)
            this.RenderManager.Culling2DEnabled = false;

            EntityManager.Add(EntitiesFactory.CreateRocket());
            EntityManager.Add(EntitiesFactory.CreateEnemiesEmitter());

            this.AddSceneBehavior(new GameSceneBehavior(), SceneBehavior.Order.PreUpdate);

#if DEBUG
            this.AddSceneBehavior(new DebugSceneBehavior(), SceneBehavior.Order.PreUpdate);
#endif
        }
    }
}
