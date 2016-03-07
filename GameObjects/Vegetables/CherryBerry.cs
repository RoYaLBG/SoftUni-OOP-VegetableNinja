namespace VegetableNinja.GameObjects.Vegetables
{
    public class CherryBerry : Vegetable
    {
        private const int RegrowCooldown = 5;

        private const int PowerEffect = 0;
        private const int StaminaEffect = 10;

        public CherryBerry()
            : base(RegrowCooldown, new VegetableInteractionEffect(PowerEffect, StaminaEffect))
        {
        }
    }
}
