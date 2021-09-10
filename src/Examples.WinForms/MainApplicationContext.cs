using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examples.WinForms
{
    internal class MainApplicationContext : ApplicationContext
    {
        public MainApplicationContext()
        {
            this.MainForm = new Views.Form1();
            InitializeNotifyArea();
        }

        protected override void Dispose(bool disposing)
        {
            this.NotifyAreaIcon?.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeNotifyArea()
        {
            var exitMenuItem = new ToolStripMenuItem() { Text = "終了(&X)" };
            exitMenuItem.Click += (sender, e) => { ExitThread(); };

            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add(exitMenuItem);

            NotifyAreaIcon = new NotifyIcon
            {
                Icon = Properties.Resources.Icon1,
                ContextMenuStrip = contextMenu,
                Text = "Sample NotifyIcon Tooltip",
                Visible = true
            };

            return;

        }

        private NotifyIcon NotifyAreaIcon { get; set; }

    }
}
