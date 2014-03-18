using DinoEscapeProject.Entities;

namespace DinoEscapeProject
{
    public static class EntitiesFactory
    {
        public static Rocket CreateRocket()
        {
            return new Rocket();
        }

        public static EnemiesEmitter CreateEnemiesEmitter()
        {
            return new EnemiesEmitter();
        }

        public static Enemy CreateBird()
        {
            return new Bird();
        }
    }
}
