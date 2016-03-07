namespace VegetableNinja.Interfaces
{
    public interface IInteractable
    {
        void Update();

        IInteractionEffect InteractWith(IInteractionEffect effect);
    }
}
