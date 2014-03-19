using DinoEscapeProject.Behaviors;
using WaveEngine.Common.Graphics;
using WaveEngine.Framework;
namespace DinoEscapeProject.Scenes
{
    class PauseScene : Scene
    {
        protected override void CreateScene()
        {
            RenderManager.BackgroundColor = Color.Transparent;

            this.AddSceneBehavior(new PauseSceneBehavior(), SceneBehavior.Order.PreUpdate);
        }
    }
}
