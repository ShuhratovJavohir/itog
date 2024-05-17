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
        this.Text = "Флаг Великобритании с 13 полосами";
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
        Color blue = Color.FromArgb(1, 33, 105);

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

        // Draw the union (blue rectangle with red cross)
        g.FillRectangle(blueBrush, 0, 0, unionWidth, unionHeight);

        // Draw the cross of St George (central red cross)
        int crossWidth = unionWidth / 5;
        int crossOffset = crossWidth / 2;

        g.FillRectangle(redBrush, unionWidth / 2 - crossOffset, 0, crossWidth, unionHeight);
        g.FillRectangle(redBrush, 0, unionHeight / 2 - crossOffset, unionWidth, crossWidth);

        // Draw the cross of St Andrew (white diagonal cross)
        int diagonalWidth = crossWidth / 2;

        DrawDiagonalCross(g, whiteBrush, unionWidth, unionHeight, diagonalWidth);

        // Draw the cross of St Patrick (red diagonal cross)
        DrawDiagonalCross(g, redBrush, unionWidth, unionHeight, diagonalWidth / 2);

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

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
}
