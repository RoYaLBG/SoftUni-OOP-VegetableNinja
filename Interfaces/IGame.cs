namespace VegetableNinja.Interfaces
{
    using GameObjects.Players;

    public interface IGame
    {
        IPlayer Winner { get; }

        void Start();
    }
}
