using System;
using System.Windows.Forms;

namespace TruckRace
{
    public abstract class Racer
    {
        public string Name;
        public Bet bet;
        public int Cash;
        public bool busted;
        public Label statusLabel, MaximumBet;

        public Racer(Bet bet, Label MaximumBet, int Cash, Label statusLabel)
        {
            this.bet = bet;
            this.Cash = Cash;
            this.MaximumBet = MaximumBet;
            this.statusLabel = statusLabel;
            if (this.statusLabel != null)
                this.statusLabel.ForeColor = System.Drawing.Color.Black;

        }

        public void UpdateLabels()
        {
            if (bet == null)
            {
                statusLabel.Text = String.Format("{0} hasn't placed any bets", Name);
            }

            else
            {
                statusLabel.Text = bet.Descr();
            }
            if (Cash == 0)
            {
                busted = true;
                statusLabel.Text = String.Format("BUSTED!");
                statusLabel.ForeColor = System.Drawing.Color.Red;

            }
            MaximumBet.Text = String.Format("Maximum Bet: ${0}", Cash);
        }


        public void ClearBet()
        {
            bet.Amount = 0;
        }

        public bool PlaceBet(int Amount, int Trucks)
        {
            if (Amount <= Cash)
            {
                bet = new Bet(Amount, Trucks, this);
                return true;
            }
            return false;
        }

        public void Collect(int Winner)
        {
            Cash += bet.Pay(Winner);
        }

        public abstract void setRacerName();
    }


    public class Rajdeep : Racer
    {
        public Rajdeep(Bet MyBet, Label MaximumBet, int Cash, Label MyLabel) : base(MyBet, MaximumBet, Cash, MyLabel)
        {
        }

        public override void setRacerName()
        {
            Name = "Rajdeep";
        }
    }

    public class Lovedeep : Racer
    {
        public Lovedeep(Bet bet, Label MaximumBet, int Cash, Label label) : base(bet, MaximumBet, Cash, label)
        {
        }

        public override void setRacerName()
        {
            Name = "Lovedeep";
        }
    }

    public class Raman : Racer
    {
        public Raman(Bet bet, Label MaximumBet, int Cash, Label label) : base(bet, MaximumBet, Cash, label)
        {
        }

        public override void setRacerName()
        {
            Name = "Raman";
        }
    }

    //coding is for  factory
    public class Factory
    {
        public Racer getRacer(String Name, Label MaximumBet, Label bet)
        {
            Racer Obj_race;
            switch (Name.ToLower())
            {
                case "rajdeep":
                    Obj_race = new Rajdeep(null, MaximumBet, 50, bet);
                    break;

                case "raman":
                    Obj_race = new Raman(null, MaximumBet, 50, bet);
                    break;

                case "lovedeep":
                    Obj_race = new Lovedeep(null, MaximumBet, 50, bet);
                    break;

                default:
                    Obj_race = null;
                    break;
            }
            Obj_race.setRacerName();
            return Obj_race;
        }
    }

}
