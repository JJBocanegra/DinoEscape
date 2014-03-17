using DinoEscapeProject.Entities;

namespace DinoEscapeProject
{
    public static class EntitiesFactory
    {
        public static Rocket CreateRocket()
        {
            return new Rocket();
        }

        public static Bird CreateBird()
        {
            return new Bird();
        }
    }
}
