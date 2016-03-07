namespace VegetableNinja.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Controls;
    using GameObjects.Players;
    using Grid;
    using Interfaces;

    public class NinjaGame : IGame
    {
        private readonly IPlayer playerOne;
        private readonly IPlayer playerTwo;
        private readonly IGrid<IInteractable, IPlayer> layout;
        private readonly IKeyReader keyReader;
        private readonly IList<IPlayer> players;
        private readonly IEnumerator<IPlayer> playerEnumerator; 

        private IPlayer currentPlayer;

        public NinjaGame(IPlayer playerOne, IPlayer playerTwo, IGrid<IInteractable, IPlayer> layout, IKeyReader keyReader)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            this.keyReader = keyReader;
            this.currentPlayer = this.playerOne;
            this.layout = layout;
            this.Winner = null;

            this.players = new List<IPlayer>() {this.playerTwo, this.playerOne};
            this.playerEnumerator = this.players.GetEnumerator();
        }

        public IPlayer Winner { get; private set; }

        public void Start()
        {
            Key key;
            IList<IInteractionEffect> effects = new List<IInteractionEffect>();
            
            while ((key = this.keyReader.ReadKey()) != Key.None)
            {
                if (this.currentPlayer.Stamina <= 0)
                {
                    this.ApplyEffects(effects);   
                    effects = new List<IInteractionEffect>();

                    this.ToggleCurrentPlayer();
                }

                GridDirection direction = (GridDirection)Enum.Parse(typeof(GridDirection), key.ToString());
                IInteractable neighbour = this.layout.GetNeighbour(this.currentPlayer, direction);
                if (neighbour != null)
                {
                    effects.Add(neighbour.InteractWith(this.currentPlayer.LaunchEffect()));
                }
                this.layout.Move(this.currentPlayer, direction);

                this.currentPlayer.Stamina--;
                this.layout.Update();

                IPlayer foughtPlayer = this.players.FirstOrDefault(p => p.FightPosition != FightPosition.Neutral);
                if (foughtPlayer != null)
                {
                    this.Winner = foughtPlayer.FightPosition == FightPosition.Won 
                        ? foughtPlayer 
                        : this.players.FirstOrDefault(p => p != foughtPlayer);

                    break;
                }
            }

            if (this.Winner == null)
            {
                this.ApplyEffects(effects);
                this.Winner = this.players.FirstOrDefault(p => p.Power == this.players.Max(ip => ip.Power));
            }

        }

        private void ToggleCurrentPlayer()
        {
            var enumerator = this.playerEnumerator;

            if (!enumerator.MoveNext())
            {
                enumerator.Reset();
                enumerator.MoveNext();
            }

            this.currentPlayer = enumerator.Current;
        }

        private void ApplyEffects(IList<IInteractionEffect> effects)
        {
            foreach (IInteractionEffect effect in effects)
            {
                this.currentPlayer.Power += effect.Power;
                this.currentPlayer.Stamina += effect.Stamina;
            }
        }
    }
}
