namespace VegetableNinja.GameObjects.Players
{
    using Interfaces;

    public class PlayerInteractionEffect : IFightEffect
    {
        public PlayerInteractionEffect(int power, int stamina)
        {
            this.Power = power;
            this.Stamina = stamina;
        }

        public int Power { get; private set; }

        public int Stamina { get; private set; }
    }
}
