using System.Windows.Forms;

namespace Examples.WinForms.Controls.Extensions
{
    public static class MaskedTextBoxExtensions
    {
        public static bool IsEmpty(this MaskedTextBox source)
        {
            source.SuspendLayout();
            var mask = source.Mask;
            source.Mask = null;
            var isEmpty = string.IsNullOrWhiteSpace(source.Text);
            source.Mask = mask;
            source.ResumeLayout();

            return isEmpty;
        }

    }
}
