namespace VegetableNinja.GameObjects.Vegetables
{
    public class Royal : Vegetable
    {
        private const int RegrowCooldown = 10;

        private const int PowerEffect = 20;
        private const int StaminaEffect = 10;

        public Royal()
            : base(RegrowCooldown, new VegetableInteractionEffect(PowerEffect, StaminaEffect))
        {
        }
    }
}
