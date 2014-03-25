using DinoEscapeProject.Behaviors;
using DinoEscapeProject.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;

namespace DinoEscapeProject.Entities
{
    public class EnemiesEmitter : BaseDecorator
    {
        private int position;
        public static Entity[] enemies;

        public EnemiesEmitter()
        {
            this.entity = new Entity();

            //position = WaveServices.Random.Next(0, (int)WaveServices.ViewportManager.VirtualWidth);
            enemies = new Entity[1];

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = EntitiesFactory.CreateBird().entity;
                enemies[i].Enabled = false;
            }
        }

        public static void NewEnemy()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (!enemies[i].Enabled)
                {
                    enemies[i].Enabled = true;
                    enemies[i].FindComponent<ScrollBehavior>().EntityEnabled();
                    break;
                }
            }
        }
    }
}
