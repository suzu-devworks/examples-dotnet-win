using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Examples.WpfPrism.ViewModels
{
    internal class SampleViewModel : BindableBase
    {
        public IDialogService _dialogService { get; set; }

        private string _resultMessage = "";
        public string ResultMessage
        {
            get { return _resultMessage; }
            set { SetProperty(ref _resultMessage, value); }
        }

        public DelegateCommand OpenDialogCommand { get; private set; }
        public DelegateCommand OpenDefaultWindowCommand { get; private set; }
        public DelegateCommand OpenGreenWindowCommand { get; private set; }
        public DelegateCommand OpenBlueWindowCommand { get; private set; }

        public SampleViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            this.OpenDialogCommand = new DelegateCommand(OpenDialog);
            this.OpenDefaultWindowCommand = new DelegateCommand(OpenDefaultWindow);
            this.OpenGreenWindowCommand = new DelegateCommand(OpenGreenWindow);
            this.OpenBlueWindowCommand = new DelegateCommand(OpenBlueWindow);
        }

        private void OpenDialog()
        {
            IDialogParameters param = new DialogParameters();
            param.Add("msg", "親画面からの引数：" + DateTime.Now.ToLongTimeString());

            this._dialogService.ShowDialog("SampleDialog", param, x =>
            {
                this.ResultMessage = "";

                if (x.Result == ButtonResult.OK)
                {
                    if (x.Parameters != null && x.Parameters.ContainsKey("result"))
                    {
                        this.ResultMessage = "ダイアログからの実行結果：" + x.Parameters.GetValue<string>("result");
                    }
                }
            });
        }

        private void OpenDefaultWindow()
        {
            IDialogParameters param = new DialogParameters();
            param.Add("msg", "デフォルトのウィンドウ");
            this._dialogService.ShowDialog("SampleDialog", param, x =>
            {
                this.ResultMessage = "デフォルトのウィンドウを閉じました。";
            });
        }

        private void OpenGreenWindow()
        {
            IDialogParameters param = new DialogParameters();
            param.Add("msg", "緑色のウィンドウ");
            this._dialogService.ShowDialog("SampleDialog", param, x =>
            {
                this.ResultMessage = "緑色のウィンドウを閉じました。";
            }, "greenWindow");
        }

        private void OpenBlueWindow()
        {
            IDialogParameters param = new DialogParameters();
            param.Add("msg", "青色のウィンドウ");
            this._dialogService.ShowDialog("SampleDialog", param, x =>
            {
                this.ResultMessage = "青色のウィンドウを閉じました。";
            }, "blueWindow");
        }

    }
}
