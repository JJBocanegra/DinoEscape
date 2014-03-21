#region Using Statements
using DinoEscapeProject.Resources;
using System;
using WaveEngine.Common.Graphics;
using WaveEngine.Components.Transitions;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Managers;
using WaveEngine.Framework.Services;
#endregion

namespace DinoEscapeProject.Scenes
{
    class MenuScene : Scene
    {
        protected override void CreateScene()
        {
            RenderManager.BackgroundColor = Color.FloralWhite;

            Button startGameButton = new Button()
            {
                HorizontalAlignment = WaveEngine.Framework.UI.HorizontalAlignment.Center,
                VerticalAlignment = WaveEngine.Framework.UI.VerticalAlignment.Center,
                Text = string.Empty,
                IsBorder = false,
                BackgroundImage = Textures.PLAY_BUTTON,
                PressedBackgroundImage = Textures.PLAY_BUTTON_PRESSED
            };
            startGameButton.Click += (o, e) =>
            {
                TimeSpan timeSpan = new TimeSpan(0, 0, 0, 1, 500);
                CurtainsTransition transition = new CurtainsTransition(timeSpan);
                ScreenContext gameContext = new ScreenContext("GameScene", new GameScene())
                {
                    Behavior = ScreenContextBehaviors.DrawInBackground //Hacemos que se renderize cuando esté apilado en background (Paused)
                };
                WaveServices.ScreenContextManager.Push(gameContext, transition);
            };

            EntityManager.Add(startGameButton);
        }
    }
}
