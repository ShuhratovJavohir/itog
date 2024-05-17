using System;
using System.Drawing;
using System.Windows.Forms;

public class UzbekistanFlagForm : Form
{
    private PictureBox pictureBox;

    public UzbekistanFlagForm()
    {
        this.Text = "Флаг Узбекистана";
        this.Size = new Size(1000, 500);

        pictureBox = new PictureBox();
        pictureBox.Dock = DockStyle.Fill;
        pictureBox.Paint += new PaintEventHandler(DrawUzbekistanFlag);
        this.Controls.Add(pictureBox);
    }

    private void DrawUzbekistanFlag(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        int width = pictureBox.Width;
        int height = pictureBox.Height;

        // Drawing the flag stripes
        Brush blueBrush = new SolidBrush(Color.FromArgb(0, 119, 189));
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush greenBrush = new SolidBrush(Color.FromArgb(0, 158, 96));
        Brush redBrush = new SolidBrush(Color.FromArgb(206, 17, 38));

        int stripeHeight = height / 3;

        g.FillRectangle(blueBrush, 0, 0, width, stripeHeight);
        g.FillRectangle(whiteBrush, 0, stripeHeight, width, stripeHeight);
        g.FillRectangle(greenBrush, 0, stripeHeight * 2, width, stripeHeight);

        // Drawing the red stripes
        int redStripeHeight = 10;
        g.FillRectangle(redBrush, 0, stripeHeight - redStripeHeight / 2, width, redStripeHeight);
        g.FillRectangle(redBrush, 0, stripeHeight * 2 - redStripeHeight / 2, width, redStripeHeight);

        // Drawing the crescent and stars
        DrawCrescentAndStars(g, width, stripeHeight);

        blueBrush.Dispose();
        whiteBrush.Dispose();
        greenBrush.Dispose();
        redBrush.Dispose();
    }

    private void DrawCrescentAndStars(Graphics g, int width, int stripeHeight)
    {
        // Drawing the crescent
        Brush whiteBrush = new SolidBrush(Color.White);
        int crescentRadius = stripeHeight / 4;
        int crescentX = crescentRadius;
        int crescentY = stripeHeight / 2 - crescentRadius / 2;

        g.FillEllipse(whiteBrush, crescentX, crescentY, crescentRadius, crescentRadius);
        Brush blueBrush = new SolidBrush(Color.FromArgb(0, 119, 189));
        int innerCrescentRadius = (int)(crescentRadius * 0.75);
        int innerCrescentX = crescentX + innerCrescentRadius / 2;
        int innerCrescentY = crescentY + innerCrescentRadius / 2;

        g.FillEllipse(blueBrush, innerCrescentX, innerCrescentY, innerCrescentRadius, innerCrescentRadius);

        // Drawing the stars
        int starRadius = crescentRadius / 5;
        int starSpacing = starRadius * 2;
        int starsRow1Y = crescentY - starSpacing;
        int starsRow2Y = crescentY - 2 * starSpacing;

        for (int i = 0; i < 5; i++)
        {
            int starX = crescentX + (i + 1) * starSpacing;
            g.FillEllipse(whiteBrush, starX, starsRow1Y, starRadius, starRadius);
        }
        for (int i = 0; i < 3; i++)
        {
            int starX = crescentX + (i + 1) * starSpacing + starSpacing / 2;
            g.FillEllipse(whiteBrush, starX, starsRow2Y, starRadius, starRadius);
        }

        whiteBrush.Dispose();
        blueBrush.Dispose();
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new UzbekistanFlagForm());
    }
}
