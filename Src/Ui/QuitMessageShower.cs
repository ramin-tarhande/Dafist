using System.Windows.Forms;

namespace Dafist.Ui
{
    public static class QuitMessageShower
    {
        public static void InitShow(string message)
        {
            InnerShow(message);
        }

        public static void Show(string message)
        {
            var text = string.Format("{0}\r\ncheck log file", message);
            InnerShow(text);
        }

        static void InnerShow(string text)
        {
            MessageBox.Show(text, "Fatal error",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
    }
}
