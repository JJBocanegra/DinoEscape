using DinoEscapeProject.Scenes;
using System;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;

namespace DinoEscapeProject.Behaviors
{
    class PauseSceneBehavior : SceneBehavior
    {
        private bool tapPressed;    //Controla que solo se reconozca una sola pulsación de tecla

        public PauseSceneBehavior()
        {
            tapPressed = true;
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
                        Console.WriteLine("Se ha hecho POP");
                        WaveServices.ScreenContextManager.Pop();
                        tapPressed = true;
                    }
                }
                else
                    tapPressed = false;
            }
        }
    }
}
