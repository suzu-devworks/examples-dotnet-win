using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Examples.WpfPrism.ViewModels
{
    internal class SampleDialogViewModel : BindableBase, IDialogAware
    {

        private string? _message = "";
        public string? Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand CloseDialogCommand { get; private set; }

        private string _title = "Sample Dialog";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public event Action<IDialogResult>? RequestClose;

        public SampleDialogViewModel()
        {
            this.CloseDialogCommand = new DelegateCommand(CloseDialog);
        }


        public void OnDialogOpened(IDialogParameters? parameters)
        {
            this.Message = parameters?.GetValue<string>("msg");
        }

        private void CloseDialog()
        {
            IDialogParameters param = new DialogParameters();
            param.Add("result", DateTime.Now.ToLongTimeString());

            this.CloseDialog(new DialogResult(ButtonResult.OK, param));
        }

        protected void CloseDialog(IDialogResult result)
        {
            this.RequestClose?.Invoke(result);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }
    }
}
