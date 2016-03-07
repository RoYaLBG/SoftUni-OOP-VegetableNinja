namespace VegetableNinja.GameObjects.Vegetables
{
    public class Asparagus : Vegetable
    {
        private const int RegrowCooldown = 2;

        private const int PowerEffect = 5;
        private const int StaminaEffect = -5;

        public Asparagus()
            : base(RegrowCooldown, new VegetableInteractionEffect(PowerEffect, StaminaEffect))
        {
        }
    }
}
