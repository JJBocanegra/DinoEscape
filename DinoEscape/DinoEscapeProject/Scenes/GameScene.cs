#region Using Statements
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Framework;

#endregion

namespace DinoEscapeProject
{
    public class GameScene : Scene
    {
        protected override void CreateScene()
        {
            RenderManager.BackgroundColor = Color.FloralWhite;

            FixedCamera camera = new FixedCamera("Camera", new Vector3(0, 0, -50f), new Vector3(0,0,0));
            EntityManager.Add(camera);

            EntityManager.Add(EntitiesFactory.CreateRocket());

            for (int i = 0; i < 10; i++)
                EntityManager.Add(EntitiesFactory.CreateBird());
        }
    }
}
