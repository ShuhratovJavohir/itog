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
        this.Text = "Флаг Великобритании";
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
        this.ResumeLayout(false);
    }

    private void DrawFlag(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        int width = pictureBox.Width;
        int height = pictureBox.Height;

        // Define colors
        Color red = Color.FromArgb(200, 16, 46);
        Color white = Color.White;
        Color blue = Color.FromArgb(1, 33, 105);

        // Define brushes
        Brush redBrush = new SolidBrush(red);
        Brush whiteBrush = new SolidBrush(white);
        Brush blueBrush = new SolidBrush(blue);

        // Fill background with blue
        g.FillRectangle(blueBrush, 0, 0, width, height);

        // Dimensions for crosses
        float diagonalWidth = width * 0.06f;
        float crossWidth = width * 0.2f;
        float crossHeight = height * 0.2f;

        // Draw diagonal white stripes (St Andrew's Cross)
        DrawDiagonalStripes(g, whiteBrush, width, height, diagonalWidth, true);

        // Draw diagonal red stripes (St Patrick's Cross)
        DrawDiagonalStripes(g, redBrush, width, height, diagonalWidth / 2, false);

        // Draw central white cross (St George's Cross)
        g.FillRectangle(whiteBrush, width * 0.4f, 0, width * 0.2f, height);
        g.FillRectangle(whiteBrush, 0, height * 0.4f, width, height * 0.2f);

        // Draw central red cross (St George's Cross)
        g.FillRectangle(redBrush, width * 0.45f, 0, width * 0.1f, height);
        g.FillRectangle(redBrush, 0, height * 0.45f, width, height * 0.1f);

        // Dispose brushes
        redBrush.Dispose();
        whiteBrush.Dispose();
        blueBrush.Dispose();
    }

    private void DrawDiagonalStripes(Graphics g, Brush brush, int width, int height, float stripeWidth, bool isWhite)
    {
        float offset = isWhite ? 0 : stripeWidth;

        // Draw top-left to bottom-right
        g.FillPolygon(brush, new PointF[]
        {
            new PointF(-offset, 0),
            new PointF(0, -offset),
            new PointF(width + offset, height),
            new PointF(width, height + offset)
        });

        // Draw top-right to bottom-left
        g.FillPolygon(brush, new PointF[]
        {
            new PointF(width + offset, 0),
            new PointF(width, -offset),
            new PointF(-offset, height),
            new PointF(0, height + offset)
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
