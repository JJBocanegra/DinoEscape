using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;

namespace DinoEscapeProject.Entities
{
    public class EnemiesEmitter : BaseDecorator
    {
        private int[] positions = { 0, (int)WaveServices.ViewportManager.VirtualWidth / 2, (int)WaveServices.ViewportManager.VirtualWidth };
        private Entity[] enemies = new Entity[3];

        public EnemiesEmitter()
        {
        }
    }
}
