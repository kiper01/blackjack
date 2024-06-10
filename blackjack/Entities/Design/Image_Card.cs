using System.Drawing;
using System.Windows.Forms;

namespace blackjack.Entities.Design
{
    public class Image_Card : PictureBox
    {
        public Image_Card()
        {
            this.Size = new Size(154, 191);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
