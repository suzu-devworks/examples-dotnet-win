using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Examples.WinForms.Abstractions.Messaging;
using Examples.WinForms.Controls.Bindable;
using Examples.WinForms.Controls.Extensions;
using Examples.WinForms.Extensions;
using Examples.WinForms.Themes;
using Examples.WinForms.ViewModels;

namespace Examples.WinForms.Views
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _Messenger = new DefaultMessenger();
            _Vm = new Form1ViewModel(_Messenger);

            _Messenger.Register(this, Callback);

            this.errorProvider1.DataSource = _Vm;

            // Tab page Simple
            this.button1.Bind(_Vm.ButtonCommand);
            this.label1.AddTextBinding(_Vm, nameof(_Vm.OccurredLabel));
            this.textBox1.AddTextBinding(_Vm, nameof(_Vm.OccurredLabel));
            this.maskedTextBox1.AddTextBinding(_Vm, nameof(_Vm.OccurredAt));
            this.dateTimePicker1.AddDataBinding(nameof(this.dateTimePicker1.Value), _Vm, nameof(_Vm.OccurredAt));

            this.checkBox1.AddTextBinding(_Vm, nameof(_Vm.Enabled), true, DataSourceUpdateMode.OnPropertyChanged);
            this.checkBox1.DataBindings.Add(new InvertedBinding(nameof(this.checkBox1.Checked), _Vm, nameof(_Vm.Enabled), true, DataSourceUpdateMode.OnPropertyChanged));

            this.numericUpDown1.DataBindings.Add(nameof(this.numericUpDown1.Value), _Vm, nameof(_Vm.Value), true, DataSourceUpdateMode.OnPropertyChanged);
            this.label2.AddTextBinding(_Vm, nameof(_Vm.ValueLabel));

            this.textBox2.AddTextBinding(_Vm.Name, nameof(_Vm.Name.Value));
            this.label3.AddTextBinding(_Vm, nameof(_Vm.UpperName));

            // Tab Page ICommand
            //this.button2.Bind(_Vm.ShowMessageCommand);
            this.button3.Bind(_Vm.CloseCommand);

            ToolStripProfessionalRenderer renderer = new VS2019Renderer(Color.FromArgb(241, 241, 241), new VS2019ColorTable());
            renderer.RoundedEdges = false;
            ToolStripManager.Renderer = renderer;
            ToolStripManager.VisualStylesEnabled = true;

        }

        private void FormClosingHandler(object sernder, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                return;
            }

            if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                return;
            }

            System.Diagnostics.Debug.WriteLine("Close Cancel.");
            e.Cancel = true;
        }

        //vm.
        private readonly DefaultMessenger _Messenger;
        private readonly Form1ViewModel _Vm;

        private void Callback()
        {
            System.Diagnostics.Debug.WriteLine("Called.");
            MessageBox.Show(this, "Called.");

            // NotifyMessage.
            // ConfirmMessage.
            // OpenFile(or Directory)Dialog => ConfirmMessage.
            // Popup View => (Model State?) => NotifyMessage.
        }

        //TODO Messgenger.Notify();
        //      - MessageBox.Show()
        //      - SetForcus()
        //      - Form.Close()

        //TODO GridView Error.

    }
}
