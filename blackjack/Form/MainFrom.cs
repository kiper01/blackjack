using blackjack.Entities.Design;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace blackjack
{
    public partial class MainForm : Form
    {
        private Player player;
        private Player dealer;
        private CardsDeck _deck;
        private bool _gameStatus;

        public MainForm(CardsDeck deck)
        {
            InitializeComponent();
            _deck = deck;
            _gameStatus = true;
        }

        private void StartGame()
        {
            _deck.ShuffleDeck();

            player = new Player();
            dealer = new Player(isDealer: true);

            player.AddCardToHand(_deck.GetCardFromStart());
            dealer.AddCardToHand(_deck.GetCardFromStart());
            player.AddCardToHand(_deck.GetCardFromStart());
            dealer.AddCardToHand(_deck.GetCardFromStart());

            UpdateCardDisplay(player);
            UpdateLabelScore(player);
            UpdateCardDisplay(dealer);
        }

        private void UpdateCardDisplay(Player player)
        {
            FlowLayoutPanel panel = player.IsDealer ? flowLayoutPanel1 : flowLayoutPanel2;
            panel.Controls.Clear();

            if (player.IsDealer && _gameStatus)
            {
                foreach (var card in player.Hand.GetAllCards())
                {
                    Image_Card cardImage = new Image_Card();
                    cardImage.Image = (Image)Properties.Resources.ResourceManager.GetObject("Back");
                    panel.Controls.Add(cardImage);
                }
            }
            else
            {
                foreach (var card in player.Hand.GetAllCards())
                {
                    Image_Card cardImage = new Image_Card();
                    cardImage.Image = (Image)Properties.Resources.ResourceManager.GetObject(card.ImageName);
                    panel.Controls.Add(cardImage);
                }
            }
        }

        private void UpdateLabelScore(Player player)
        {
            Label label = player.IsDealer ? label6 : label4;
            label.Text = player.Score.ToString();
        }

        private void DealerMove()
        {
            _gameStatus = false;

            while (dealer.Score < 17)
            {
                dealer.AddCardToHand(_deck.GetCardFromStart());
            }

            UpdateCardDisplay(dealer);
            UpdateLabelScore(dealer);
            FinishGame();
        }
        private void FinishGame()
        {
            string boxName;
            string boxDescription;

            if (player.Score > 21)
            {
                boxName = "Поражение";
                boxDescription = "Вы проиграли - перебор по очкам.";
            }
            else if (dealer.Score > 21)
            {
                boxName = "Победа";
                boxDescription = "Вы победили - перебор по очкам у дилера.";
            }
            else if (player.Score > dealer.Score)
            {
                boxName = "Победа";
                boxDescription = "Вы победили - у вас больше очков, чем у дилера.";
            }
            else if (player.Score < dealer.Score)
            {
                boxName = "Поражение";
                boxDescription = "Вы проиграли - у дилера больше очков, чем у вас.";
            }
            else
            {
                boxName = "Ничья";
                boxDescription = "Ничья - у вас и у дилера одинаковое количество очков.";
            }

            MessageBox.Show(boxDescription, boxName);

            SetApplicationToDefault();
        }

        private void SetApplicationToDefault()
        {
            player.ClearHand(_deck);
            dealer.ClearHand(_deck);

            UpdateCardDisplay(player);
            UpdateLabelScore(player);
            UpdateCardDisplay(dealer);
            label6.Text = "?";

            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = false;
            button_NewGame3.Visible = true;
            button_NewGame2.Visible = false;
            button_NewGame1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button_NewGame3_Click(object sender, EventArgs e)
        {
            StartGame();
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = true;
            button_NewGame3.Visible = false;
            button_NewGame2.Visible = true;
            button_NewGame1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
        }

        private void button_NewGame2_Click(object sender, EventArgs e)
        {
            player.AddCardToHand(_deck.GetCardFromStart());
            UpdateCardDisplay(player);
            UpdateLabelScore(player);
            if (player.Score >= 21) DealerMove();
        }

        private void button_NewGame1_Click(object sender, EventArgs e)
        {
            DealerMove();
        }
    }
}
