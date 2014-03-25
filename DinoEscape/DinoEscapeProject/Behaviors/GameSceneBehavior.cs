using DinoEscapeProject.Entities;
using DinoEscapeProject.Scenes;
using System;
using WaveEngine.Framework;
using WaveEngine.Framework.Diagnostic;
using WaveEngine.Framework.Managers;
using WaveEngine.Framework.Services;

namespace DinoEscapeProject.Behaviors
{
    class GameSceneBehavior : SceneBehavior
    {
        private bool tapPressed;    //Controla que solo se reconozca una sola pulsación de tecla
        private int meterCounter;   //Contador que cuando llega al maxMeterCounter, incrementa el indicador de altura en un metro
        private int maxMeterCounter;
        private int height;

        public GameSceneBehavior()
        {
            meterCounter = 0;
            maxMeterCounter = 20;
            height = 0;
        }

        protected override void ResolveDependencies()
        {
            for (int i = 0; i < EnemiesEmitter.enemies.Length; i++)
                this.Scene.EntityManager.Add(EnemiesEmitter.enemies[i]);
        }

        protected override void Update(TimeSpan gameTime)
        {
            Labels.Add("Height", height.ToString());
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

            if (height % 5 == 0 && meterCounter == 0) 
            {
                EnemiesEmitter.NewEnemy();
            }

            if (meterCounter < maxMeterCounter)
                meterCounter++;
            else
            {
                meterCounter = 0;
                height++;
            }
        }


    }
}
