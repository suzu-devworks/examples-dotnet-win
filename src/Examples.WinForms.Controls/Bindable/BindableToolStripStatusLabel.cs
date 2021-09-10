using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Examples.WinForms.Controls.Bindable
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip)]
    public class BindableToolStripStatusLabel : ToolStripStatusLabel, IBindableComponent
    {
        public BindingContext BindingContext
        {
            get
            {
                _context ??= new();
                return _context;
            }
            set { _context = value; }
        }
        private BindingContext _context;

        public ControlBindingsCollection DataBindings
        {
            get
            {
                _bindings ??= new(this);
                return _bindings;
            }
            set { _bindings = value; }
        }
        private ControlBindingsCollection _bindings;

    }
}
