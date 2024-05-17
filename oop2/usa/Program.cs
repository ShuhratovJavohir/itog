using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private PictureBox pictureBox;

    public Form1()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.pictureBox = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
        this.SuspendLayout();

        // pictureBox
        this.pictureBox.Dock = DockStyle.Fill;
        this.pictureBox.Paint += new PaintEventHandler(this.DrawFlag);
        this.Controls.Add(this.pictureBox);

        // Form1
        this.AutoScaleDimensions = new SizeF(8F, 16F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1000, 500);
        this.Name = "Form1";
        this.Text = "Исторический флаг США";
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
        this.ResumeLayout(false);
    }

    private void DrawFlag(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        int width = pictureBox.Width;
        int height = pictureBox.Height;

        // Define colors
        Color red = Color.FromArgb(179, 25, 66);
        Color white = Color.White;
        Color blue = Color.FromArgb(10, 49, 97);

        // Define brushes
        Brush redBrush = new SolidBrush(red);
        Brush whiteBrush = new SolidBrush(white);
        Brush blueBrush = new SolidBrush(blue);

        // Stripe height
        int stripeHeight = height / 13;

        // Draw stripes
        for (int i = 0; i < 13; i++)
        {
            Brush brush = (i % 2 == 0) ? redBrush : whiteBrush;
            g.FillRectangle(brush, 0, i * stripeHeight, width, stripeHeight);
        }

        // Union dimensions
        int unionWidth = width * 2 / 5;
        int unionHeight = stripeHeight * 7;

        // Draw the union (blue rectangle)
        g.FillRectangle(blueBrush, 0, 0, unionWidth, unionHeight);

        // Draw the stars
        DrawStars(g, unionWidth, unionHeight);

        // Dispose brushes
        redBrush.Dispose();
        whiteBrush.Dispose();
        blueBrush.Dispose();
    }

    private void DrawStars(Graphics g, int unionWidth, int unionHeight)
    {
        Brush whiteBrush = new SolidBrush(Color.White);

        // Define star parameters
        int numStars = 13;
        double angleStep = 2 * Math.PI / numStars;
        int starRadiusOuter = unionHeight / 10;
        int starRadiusInner = starRadiusOuter / 2;
        PointF center = new PointF(unionWidth / 2, unionHeight / 2);

        // Draw stars in a circle
        for (int i = 0; i < numStars; i++)
        {
            double angle = i * angleStep;
            float x = (float)(center.X + Math.Cos(angle) * unionHeight / 3.5);
            float y = (float)(center.Y + Math.Sin(angle) * unionHeight / 3.5);
            DrawStar(g, whiteBrush, x, y, starRadiusOuter, starRadiusInner);
        }

        whiteBrush.Dispose();
    }

    private void DrawStar(Graphics g, Brush brush, float x, float y, int outerRadius, int innerRadius)
    {
        PointF[] points = new PointF[10];
        double angle = Math.PI / 2;

        for (int i = 0; i < 10; i++)
        {
            int radius = (i % 2 == 0) ? outerRadius : innerRadius;
            points[i] = new PointF(
                x + (float)(Math.Cos(angle) * radius),
                y - (float)(Math.Sin(angle) * radius));
            angle += Math.PI / 5;
        }

        g.FillPolygon(brush, points);
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
}
