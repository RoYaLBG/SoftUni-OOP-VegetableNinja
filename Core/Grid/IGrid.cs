namespace VegetableNinja.Core.Grid
{
    using Interfaces;

    public interface IGrid<TAny, in TSpecial> 
        where TAny : IInteractable
        where TSpecial : IAggressor, TAny
    {
        void Add(TAny element, int row, int col);

        void Add(TSpecial special, int row, int col);

        void Move(TSpecial special, GridDirection direction);

        TAny GetNeighbour(TSpecial special, GridDirection to);

        void Update();
    }
}
