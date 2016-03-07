namespace VegetableNinja.GameObjects.Vegetables
{
    public class Broccoli : Vegetable
    {
        private const int RegrowCooldown = 3;

        private const int PowerEffect = 10;
        private const int StaminaEffect = 0;

        public Broccoli()
            : base(RegrowCooldown, new VegetableInteractionEffect(PowerEffect, StaminaEffect))
        {
        }
    }
}
