namespace VegetableNinja.GameObjects.Players
{
    using Interfaces;

    public class Player : IPlayer
    {
        private int stamina;
        private int power;

        public Player(string name)
        {
            this.FightPosition = FightPosition.Neutral;
            this.Name = name;
            this.Power = 1;
            this.Stamina = 1;
        }

        public string Name { get; private set; }

        public int Stamina
        {
            get { return this.stamina; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.stamina = value;
            }
        }

        public int Power
        {
            get { return this.power; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.power = value;
            }
        }

        public FightPosition FightPosition { get; private set; }

        public IInteractionEffect LaunchEffect()
        {
            return new PlayerInteractionEffect(this.Power, 0);
        }

        public void Update()
        {
        }

        public IInteractionEffect InteractWith(IInteractionEffect effect)
        {
            this.FightPosition = this.Power > effect.Power 
                ? FightPosition.Won 
                : FightPosition.Lost;

            return new PlayerInteractionEffect(0, 0);
        }
    }
}
