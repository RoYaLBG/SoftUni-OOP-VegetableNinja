namespace VegetableNinja
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Controls;
    using Controls.IO;
    using Core;
    using Core.Grid;
    using Core.Grid.Ninja;
    using GameObjects.Players;
    using Interfaces;

    internal class Launcher
    {
        private static IInput input;
        private static IOutput output;
        private static IDictionary<char, IPlayer> players;

        private static void Main()
        {
            input = new StandardInput();
            IKeyReader keyReader = new InputArrowKeyReader(input);
            output = new StandardOutput();
            players = new Dictionary<char, IPlayer>();

            string p1name = input.ReadLine();
            players.Add(p1name[0], CreatePlayer(p1name));

            string p2name = input.ReadLine();
            players.Add(p2name[0], CreatePlayer(p2name));

            int[] dimensions = input.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            IGrid<IInteractable, IPlayer> grid = new NinjaGrid<IInteractable, IPlayer>(rows, cols);

            PopulateGrid(rows, cols, grid);

            IGame game = new NinjaGame(players[p1name[0]], players[p2name[0]], grid, keyReader);
            game.Start();

            PrintWinner(game.Winner);
        }

        private static IPlayer CreatePlayer(string playerName)
        {
            return new Player(playerName);
        }

        private static void PopulateGrid(int rows, int cols, IGrid<IInteractable, IPlayer> grid)
        {
            for (int row = 0; row < rows; row++)
            {
                string currentRow = input.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    char currentElement = currentRow[col];
                    if (currentElement == '-')
                    {
                        grid.Add(default(IInteractable), row, col);
                    } 
                    else if (players.ContainsKey(currentElement))
                    {
                        grid.Add(players[currentElement], row, col);
                    }
                    else if (currentElement == '*')
                    {
                        // TO DO
                    }
                    else
                    {
                        Type vegetableType = Assembly.GetExecutingAssembly().GetTypes()
                            .Where(t => !t.IsAbstract)
                            .Where(t => !t.IsInterface)
                            .Where(t => typeof(IVegetable).IsAssignableFrom(t))
                            .FirstOrDefault(t => t.Name[0] == currentElement);

                        IInteractable vegetable = (IInteractable)Activator.CreateInstance(vegetableType);

                        grid.Add(vegetable, row, col);
                    }
                }
            }
        }

        private static void PrintWinner(IPlayer winner)
        {
            output.WriteLine("Winner: {0}", winner.Name);
            output.WriteLine("Power: {0}", winner.Power);
            output.WriteLine("Stamina: {0}", winner.Stamina);
        }

    }
}
