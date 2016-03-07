namespace VegetableNinja.Core.Grid.Ninja
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class NinjaGrid<TAny, TSpecial> : IGrid<TAny, TSpecial> 
        where TSpecial : IAggressor, TAny
        where TAny : IInteractable
    {
        private readonly TAny[,] layout;
        private readonly IDictionary<TSpecial, Position> specials;
        private readonly TSpecial[,] specialsLookup;

        public NinjaGrid(int rows, int cols)
        {
            this.layout = new TAny[rows, cols];
            this.specials = new Dictionary<TSpecial, Position>();
            this.specialsLookup = new TSpecial[rows, cols];
        }

        public void Add(TAny element, int row, int col)
        {
            this.layout[row, col] = element;
        }

        public void Add(TSpecial special, int row, int col)
        {
            this.specials.Add(special, new Position(row, col));
            this.specialsLookup[row, col] = special;
        }

        public TAny GetNeighbour(TSpecial special, GridDirection to)
        {
            int direction = (int) to;
            int rows = direction/10;
            int cols = direction%10;

            Position position = this.specials[special];

            try
            {
                if (this.specialsLookup[position.Row + rows, position.Col + cols] == null)
                {
                    return this.layout[position.Row + rows, position.Col + cols];
                }

                return this.specialsLookup[position.Row + rows, position.Col + cols];
            }
            catch (IndexOutOfRangeException)
            {
                return default(TAny);
            }
        }

        public void Update()
        {
            for (int row = 0; row < this.layout.GetLength(0); row++)
            {
                for (int col = 0; col < this.layout.GetLength(1); col++)
                {
                    if (this.specialsLookup[row, col] == null 
                        && this.layout[row, col] != null)
                    {
                        this.layout[row, col].Update();
                    }
                }
            }
        }

        public void Move(TSpecial special, GridDirection direction)
        {
            Position position = this.specials[special];
            Position positionBackup = new Position(position.Row, position.Col);
            int positionTokens = (int) direction;
            int rows = positionTokens/10;
            int cols = positionTokens%10;
            try
            {
                this.specialsLookup[position.Row, position.Col] = default(TSpecial);
                position.Row += rows;
                position.Col += cols;
                this.specialsLookup[position.Row, position.Col] = special;
            }
            catch (IndexOutOfRangeException)
            {
                this.specialsLookup[positionBackup.Row, positionBackup.Col] = special;
                this.specials[special] = positionBackup;
            }
        }
    }
}
