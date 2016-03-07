namespace VegetableNinja.GameObjects.Vegetables
{
    public class Mushroom : Vegetable
    {
        private const int RegrowCooldown = 5;

        private const int PowerEffect = -10;
        private const int StaminaEffect = -10;

        public Mushroom()
            : base(RegrowCooldown, new VegetableInteractionEffect(PowerEffect, StaminaEffect))
        {
        }
    }
}
