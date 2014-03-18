#region Using Statements
using DinoEscapeProject.Scenes;
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;
#endregion

namespace DinoEscapeProject
{
    public class Game : WaveEngine.Framework.Game
    {
        public override void Initialize(IApplication application)
        {
            base.Initialize(application);

            WaveServices.ScreenContextManager.To(new ScreenContext(new MenuScene()));

            WaveServices.ViewportManager.Activate(
                480,
                800,
                ViewportManager.StretchMode.Uniform);
        }
    }
}
