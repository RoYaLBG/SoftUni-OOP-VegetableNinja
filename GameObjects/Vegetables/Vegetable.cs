namespace VegetableNinja.GameObjects.Vegetables
{
    using Interfaces;

    public abstract class Vegetable : IVegetable
    {
        protected readonly int regrowCooldown;
        protected readonly IInteractionEffect effect;

        protected int regrowLeft;
        protected bool IsEaten;

        protected Vegetable(int regrowCooldown, IInteractionEffect effect)
        {
            this.regrowCooldown = regrowCooldown;
            this.IsEaten = false;
            this.regrowLeft = 0;
            this.effect = effect;
        }

        public void Update()
        {
            if (!this.IsEaten)
            {
                return;
            }

            this.regrowLeft++;
            if (this.regrowLeft >= this.regrowCooldown)
            {
                this.IsEaten = false;
                this.regrowLeft = 0;
            }
        }

        public virtual IInteractionEffect InteractWith(IInteractionEffect effect)
        {
            if (this.IsEaten)
            {
                return new VegetableInteractionEffect(0, 0);
            }

            this.IsEaten = true;

            return this.effect;
        }
    }
}
