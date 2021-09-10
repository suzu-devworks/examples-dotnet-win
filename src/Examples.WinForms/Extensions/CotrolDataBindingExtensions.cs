using System.Windows.Forms;

namespace Examples.WinForms.Extensions
{
    public static class CotrolDataBindingExtensions
    {
        public static TControl AddDataBinding<TControl>(this TControl @this, Binding binding)
            where TControl : Control
        {
            @this.DataBindings.Add(binding);
            return @this;
        }

        public static TControl AddDataBinding<TControl>(this TControl @this, string propertyName, object source, string memberName)
            where TControl : Control
        {
            @this.DataBindings.Add(propertyName, source, memberName);
            return @this;
        }

        public static Label AddTextBinding(this Label @this, object source, string memberName)
            => @this.AddDataBinding(nameof(@this.Text), source, memberName);

        public static CheckBox AddTextBinding(this CheckBox @this, object source, string memberName, bool v, DataSourceUpdateMode m)
        {
            @this.DataBindings.Add(nameof(@this.Text), source, memberName, v, m);
            return @this;
        }

        public static TControl AddTextBinding<TControl>(this TControl @this, object source, string memberName)
            where TControl : TextBoxBase
            => @this.AddDataBinding(nameof(@this.Text), source, memberName);

    }
}
