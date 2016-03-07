namespace VegetableNinja.GameObjects.Vegetables
{
    using Interfaces;

    public class VegetableInteractionEffect : IInteractionEffect
    {
        public VegetableInteractionEffect(int power, int stamina)
        {
            this.Power = power;
            this.Stamina = stamina;
        }

        public int Power { get; private set; }

        public int Stamina { get; private set; }
    }
}
