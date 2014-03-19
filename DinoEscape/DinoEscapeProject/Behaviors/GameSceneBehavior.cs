using DinoEscapeProject.Scenes;
using System;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;

namespace DinoEscapeProject.Behaviors
{
    class GameSceneBehavior : SceneBehavior
    {
        private bool tapPressed;    //Controla que solo se reconozca una sola pulsación de tecla

        public GameSceneBehavior()
        {
        }

        protected override void ResolveDependencies()
        {
        }

        protected override void Update(TimeSpan gameTime)
        {
            if (WaveServices.Input.KeyboardState.IsConnected)
            {
                if (WaveServices.Input.KeyboardState.Escape == WaveEngine.Common.Input.ButtonState.Pressed)
                {
                    if (!tapPressed) 
                    {
                        Console.WriteLine("Presiona ESC");
                        WaveServices.ScreenContextManager.Push(new ScreenContext("PauseScene", new PauseScene()));
                        tapPressed = true;
                    }
                }
                else
                    tapPressed = false;
            }
        }
    }
}
