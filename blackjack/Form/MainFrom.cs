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
        private Deck deck;

        public MainForm()
        {
            InitializeComponent();
        }

        private void StartGame()
        {
            deck = new CardsDeck();

            player = new Player();
            dealer = new Player(isDealer: true);

            player.AddCardToHand(deck.GetCardFromStart());
            dealer.AddCardToHand(deck.GetCardFromStart());
            player.AddCardToHand(deck.GetCardFromStart());
            dealer.AddCardToHand(deck.GetCardFromStart());

            UpdateCardDisplay(player);
            UpdateCardDisplay(dealer);
        }

        private void UpdateCardDisplay(Player player)
        {
            FlowLayoutPanel panel = player.IsDealer ? flowLayoutPanel1 : flowLayoutPanel2;
            panel.Controls.Clear();

            foreach (var card in player.Hand.GetAllCards())
            {
                Image_Card cardImage = new Image_Card();
                cardImage.Image = (Image)Properties.Resources.ResourceManager.GetObject(card.ImageName);
                panel.Controls.Add(cardImage);
            }
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
            player.AddCardToHand(deck.GetCardFromStart());
            UpdateCardDisplay(player);
        }

        private void button_NewGame1_Click(object sender, EventArgs e)
        {
            UpdateCardDisplay(player);
            UpdateCardDisplay(dealer);
        }
    }
}
