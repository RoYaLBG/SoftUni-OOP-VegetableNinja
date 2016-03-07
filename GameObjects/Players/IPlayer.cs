namespace VegetableNinja.GameObjects.Players
{
    using Interfaces;

    public interface IPlayer : IAggressor, IInteractable
    {
        string Name { get; }

        int Stamina { get; set; }

        int Power { get; set; }

        FightPosition FightPosition { get; }
    }
}
