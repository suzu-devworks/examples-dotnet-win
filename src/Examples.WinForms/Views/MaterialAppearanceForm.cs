using System;
using System.Collections.Generic;
using System.Linq;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Examples.WinForms.Views
{
    public partial class MaterialAppearanceForm : MaterialSkin.Controls.MaterialForm
    {
        private readonly MaterialSkinManager _materialSkinManager;

        public MaterialAppearanceForm()
        {
            InitializeComponent();

            _materialSkinManager = MaterialSkinManager.Instance;
            _materialSkinManager.AddFormToManage(this);
            _materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            _materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue800,
                Primary.Blue900,
                Primary.Blue500,
                Accent.Pink200,
                TextShade.WHITE);

        }

        private void materialSwitch1_CheckedChanged(object sender, System.EventArgs e)
        {
            _materialSkinManager.Theme = (materialSwitch1.Checked)
                ? MaterialSkinManager.Themes.DARK
                : MaterialSkinManager.Themes.LIGHT;
        }
    }
}
