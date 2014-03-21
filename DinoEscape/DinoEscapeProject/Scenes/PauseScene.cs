#region Using Statements
using DinoEscapeProject.Behaviors;
using DinoEscapeProject.Resources;
using FlyingKiteProject.Behaviors;
using System;
using WaveEngine.Common.Graphics;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Components.Transitions;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;
#endregion

namespace DinoEscapeProject.Scenes
{
    class PauseScene : Scene
    {
        protected override void CreateScene()
        {
            //Indicamos que no limpie la pantalla al pintar
            RenderManager.ClearFlags = ClearFlags.DepthAndStencil;

            WrapPanel container = new WrapPanel()
            {
                Width = 400,
                Height = 200,
                BackgroundColor = Color.Red,
                Opacity = 0.05f
            };
            EntityManager.Add(container.Entity);

            this.AddSceneBehavior(new PauseSceneBehavior(), SceneBehavior.Order.PreUpdate);

#if DEBUG
            this.AddSceneBehavior(new DebugSceneBehavior(), SceneBehavior.Order.PreUpdate);
#endif
        }
    }
}
