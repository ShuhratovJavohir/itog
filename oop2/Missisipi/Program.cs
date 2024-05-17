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
        this.Text = "Флаг штата Миссисипи";
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
        Color blue = Color.FromArgb(0, 40, 104);

        // Define brushes
        Brush redBrush = new SolidBrush(red);
        Brush whiteBrush = new SolidBrush(white);
        Brush blueBrush = new SolidBrush(blue);

        // Define dimensions
        int stripeHeight = height / 3;
        int cantonWidth = width / 3;
        int cantonHeight = stripeHeight * 2;

        // Draw stripes
        g.FillRectangle(redBrush, 0, 0, width, stripeHeight); // top red stripe
        g.FillRectangle(whiteBrush, 0, stripeHeight, width, stripeHeight); // middle white stripe
        g.FillRectangle(redBrush, 0, 2 * stripeHeight, width, stripeHeight); // bottom red stripe

        // Draw canton (blue rectangle with red cross)
        g.FillRectangle(blueBrush, 0, 0, cantonWidth, cantonHeight);

        // Draw red diagonal cross on canton
        float diagonalWidth = cantonWidth * 0.2f;
        DrawDiagonalCross(g, redBrush, cantonWidth, cantonHeight, diagonalWidth);

        // Draw white stars on canton
        DrawStars(g, cantonWidth, cantonHeight);

        // Dispose brushes
        redBrush.Dispose();
        whiteBrush.Dispose();
        blueBrush.Dispose();
    }

    private void DrawDiagonalCross(Graphics g, Brush brush, int width, int height, float stripeWidth)
    {
        // Draw top-left to bottom-right
        g.FillPolygon(brush, new PointF[]
        {
            new PointF(0, stripeWidth / 2),
            new PointF(stripeWidth / 2, 0),
            new PointF(width, height - stripeWidth / 2),
            new PointF(width - stripeWidth / 2, height)
        });

        g.FillPolygon(brush, new PointF[]
        {
            new PointF(width, stripeWidth / 2),
            new PointF(width - stripeWidth / 2, 0),
            new PointF(0, height - stripeWidth / 2),
            new PointF(stripeWidth / 2, height)
        });

        // Draw top-right to bottom-left
        g.FillPolygon(brush, new PointF[]
        {
            new PointF(width - stripeWidth / 2, 0),
            new PointF(width, stripeWidth / 2),
            new PointF(stripeWidth / 2, height),
            new PointF(0, height - stripeWidth / 2)
        });

        g.FillPolygon(brush, new PointF[]
        {
            new PointF(stripeWidth / 2, 0),
            new PointF(0, stripeWidth / 2),
            new PointF(width - stripeWidth / 2, height),
            new PointF(width, height - stripeWidth / 2)
        });
    }

    private void DrawStars(Graphics g, int width, int height)
    {
        Brush whiteBrush = new SolidBrush(Color.White);
        int starRadius = (int)(width * 0.05);
        int numStars = 13; // Number of stars in the cross
        float angleIncrement = (float)(Math.PI * 2 / numStars);

        for (int i = 0; i < numStars; i++)
        {
            float angle = i * angleIncrement - (float)(Math.PI / 2);
            float x = (float)(width / 2 + Math.Cos(angle) * width / 3);
            float y = (float)(height / 2 + Math.Sin(angle) * height / 3);
            DrawStar(g, whiteBrush, x, y, starRadius);
        }

        whiteBrush.Dispose();
    }

    private void DrawStar(Graphics g, Brush brush, float x, float y, int radius)
    {
        PointF[] points = new PointF[10];
        double angle = Math.PI / 2;

        for (int i = 0; i < 10; i++)
        {
            int r = (i % 2 == 0) ? radius : radius / 2;
            points[i] = new PointF(
                x + (float)(Math.Cos(angle) * r),
                y - (float)(Math.Sin(angle) * r));
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
