using System;
using System.Windows.Forms;

public abstract class CustomTextBox : TextBox
{
    private bool updating = false;

    protected override void OnTextChanged(EventArgs e)
    {
        if (updating) return;
        updating = true;

        base.OnTextChanged(e);

        if (Text.Length > 50)
        {
            Text = Text.Substring(0, 50);  // Обрезаем строку до 50 символов
            SelectionStart = Text.Length;
        }
        else
        {
            HandleInput();
        }

        updating = false;
    }

    protected abstract void HandleInput();
}

public class LatinTextBox : CustomTextBox
{
    protected override void HandleInput()
    {
        if (!string.IsNullOrEmpty(Text) && char.IsLetter(Text[Text.Length - 1]) && Text[Text.Length - 1] <= 'z')
        {
            // В этом месте не требуется повторное добавление символа.
        }
    }
}

public class DigitTextBox : CustomTextBox
{
    private static readonly string[] CyrillicNumbers = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };

    protected override void HandleInput()
    {
        if (!string.IsNullOrEmpty(Text) && char.IsDigit(Text[Text.Length - 1]))
        {
            int lastDigit = Text[Text.Length - 1] - '0';
            string cyrillicNumber = CyrillicNumbers[lastDigit];

            Text = Text.Substring(0, Text.Length - 1) + " " + cyrillicNumber;
            SelectionStart = Text.Length;
        }
    }
}

public class MainForm : Form
{
    public MainForm()
    {
        Controls.Add(new LatinTextBox { Location = new System.Drawing.Point(10, 10), Width = 200 });
        Controls.Add(new DigitTextBox { Location = new System.Drawing.Point(10, 70), Width = 200 });
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}
