using System;
using System.Drawing;
using System.Windows.Forms;

public class Popup : Form
{
    private Label lblMessage;
    private Button btnOK;
    private PictureBox picIcon;

    public Popup(string message, string title = "Message", MessageBoxIcon icon = MessageBoxIcon.None)
    {
        this.Text = title;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.ClientSize = new Size(320, 140);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.ShowInTaskbar = false;
        this.BackColor = ColorTranslator.FromHtml("#FAFBFC");
        this.Font = new Font("Manrope", 12, FontStyle.Bold);

        int iconWidth = 0;
        int iconPadding = 16;
        int leftMargin = 40;
        int topMargin = 24;

        // Icon (optional)
        picIcon = new PictureBox
        {
            Size = new Size(32, 32),
            Location = new Point(leftMargin, topMargin),
            Visible = false,
            BackColor = Color.Transparent
        };
        if (icon != MessageBoxIcon.None)
        {
            picIcon.Image = GetSystemIcon(icon);
            picIcon.Visible = true;
            iconWidth = picIcon.Width + iconPadding;
        }
        this.Controls.Add(picIcon);

        // Message label
        lblMessage = new Label
        {
            Text = message,
            AutoSize = false,
            Height = 60,
            // Dynamically set location and width based on icon
            Location = new Point(leftMargin + iconWidth, topMargin),
            Width = this.ClientSize.Width - (leftMargin + iconWidth) - leftMargin,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Manrope", 12, FontStyle.Bold),
            BackColor = Color.Transparent
        };
        this.Controls.Add(lblMessage);

        // OK button
        btnOK = new Button
        {
            Text = "OK",
            DialogResult = DialogResult.OK,
            Width = 80,
            Height = 32,
            Location = new Point((this.ClientSize.Width - 80) / 2, this.ClientSize.Height - 56),
            Anchor = AnchorStyles.Bottom,
            Font = new Font("Manrope", 12, FontStyle.Bold)
        };
        btnOK.Click += (s, e) => this.Close();
        this.Controls.Add(btnOK);

        this.AcceptButton = btnOK;
    }

    public static void Show(string message, MessageBoxIcon icon)
    {
        Show(message, "Message", icon);
    }

    public static void Show(string message, string title = "Message", MessageBoxIcon icon = MessageBoxIcon.None, IWin32Window owner = null)
    {
        using (var popup = new Popup(message, title, icon))
        {
            if (owner == null)
                popup.ShowDialog();
            else
                popup.ShowDialog(owner);
        }
    }

    private static Image GetSystemIcon(MessageBoxIcon icon)
    {
        switch (icon)
        {
            case MessageBoxIcon.Information:
                return SystemIcons.Information.ToBitmap();
            case MessageBoxIcon.Warning:
                return SystemIcons.Warning.ToBitmap();
            case MessageBoxIcon.Error:
                return SystemIcons.Error.ToBitmap();
            case MessageBoxIcon.Question:
                return SystemIcons.Question.ToBitmap();
            default:
                return null;
        }
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // Popup
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Popup";
            this.Load += new System.EventHandler(this.Popup_Load);
            this.ResumeLayout(false);

    }

    private void Popup_Load(object sender, EventArgs e)
    {

    }
    public static DialogResult ShowConfirm(string message, string title = "Confirm", MessageBoxIcon icon = MessageBoxIcon.Question, IWin32Window owner = null)
{
    using (var popup = new Popup(message, title, icon))
    {
        // Remove OK button, add Yes/No
        popup.Controls.Remove(popup.btnOK);

        var btnYes = new Button
        {
            Text = "Yes",
            DialogResult = DialogResult.Yes,
            Width = 80,
            Height = 32,
            Location = new Point(popup.ClientSize.Width / 2 - 90, popup.ClientSize.Height - 56),
            Font = popup.Font
        };
        var btnNo = new Button
        {
            Text = "No",
            DialogResult = DialogResult.No,
            Width = 80,
            Height = 32,
            Location = new Point(popup.ClientSize.Width / 2 + 10, popup.ClientSize.Height - 56),
            Font = popup.Font
        };
        btnYes.Click += (s, e) => popup.Close();
        btnNo.Click += (s, e) => popup.Close();
        popup.Controls.Add(btnYes);
        popup.Controls.Add(btnNo);
        popup.AcceptButton = btnYes;
        popup.CancelButton = btnNo;

        return owner == null ? popup.ShowDialog() : popup.ShowDialog(owner);
    }
}

}