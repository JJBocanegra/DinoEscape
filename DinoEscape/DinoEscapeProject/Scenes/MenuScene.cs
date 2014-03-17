#region Using Statements
using DinoEscapeProject.Resources;
using WaveEngine.Common.Graphics;
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
                WaveServices.ScreenContextManager.Push(new ScreenContext("GameScene", new GameScene()));
            };

            EntityManager.Add(startGameButton);
        }
    }
}
