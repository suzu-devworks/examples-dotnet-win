using System;
using System.Windows.Forms;

namespace Examples.WinForms.Controls.Bindable
{
    public class InvertedBinding : Binding
    {
        public InvertedBinding(string propertyName, object dataSource, string dataMember)
            : base(propertyName, dataSource, dataMember)
        {
        }

        public InvertedBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled)
            : base(propertyName, dataSource, dataMember, formattingEnabled)
        {
        }

        public InvertedBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode dataSourceUpdateMode)
            : base(propertyName, dataSource, dataMember, formattingEnabled, dataSourceUpdateMode)
        {
        }

        public InvertedBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode dataSourceUpdateMode, object nullValue)
            : base(propertyName, dataSource, dataMember, formattingEnabled, dataSourceUpdateMode, nullValue)
        {
        }

        public InvertedBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode dataSourceUpdateMode, object nullValue, string formatString)
            : base(propertyName, dataSource, dataMember, formattingEnabled, dataSourceUpdateMode, nullValue, formatString)
        {
        }

        public InvertedBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode dataSourceUpdateMode, object nullValue, string formatString, IFormatProvider formatInfo)
            : base(propertyName, dataSource, dataMember, formattingEnabled, dataSourceUpdateMode, nullValue, formatString, formatInfo)
        {
        }

        protected override void OnFormat(ConvertEventArgs cevent)
        {
            cevent.Value = Inverse((bool?)cevent.Value);
            base.OnFormat(cevent);
        }

        protected override void OnParse(ConvertEventArgs cevent)
        {
            cevent.Value = Inverse((bool?)cevent.Value);
            base.OnParse(cevent);
        }

        private static bool? Inverse(bool? value) => !value;

    }
}
