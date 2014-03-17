#region Using Statements
using DinoEscapeProject.Entities;
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;
#endregion

namespace DinoEscapeProject
{
    public class MyScene : Scene
    {
        protected override void CreateScene()
        {
            RenderManager.BackgroundColor = Color.CornflowerBlue;

            EntityManager.Add(new Rocket());
            //Insert your code here
        }
    }
}
