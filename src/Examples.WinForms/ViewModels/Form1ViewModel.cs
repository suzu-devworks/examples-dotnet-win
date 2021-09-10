using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Examples.WinForms.Abstractions.ComponentModel;
using Examples.WinForms.Abstractions.Input;
using Examples.WinForms.Abstractions.Messaging;

namespace Examples.WinForms.ViewModels
{
    public class Form1ViewModel : BindableObject, IDataErrorInfo
    {
        public Form1ViewModel(DefaultMessenger messenger)
        {
            _Messenger = messenger;

            OccurredAt = DateTimeOffset.Now.DateTime;

            ButtonCommand = new ActionCommand(ButtonCommandAction);
            ShowMessageCommand = new ActionCommand(ShowMessageCommandAction);
            CloseCommand = new ActionCommand(CloseCommandAction);
            Directory = new DirectoryViewModel(null, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        }

        private readonly DefaultMessenger _Messenger;

        #region Propety - OccurredAt <Standard>
        public DateTime OccurredAt
        {
            get => _occurredAt.DateTime;
            set
            {
                if (_occurredAt == value)
                {
                    return;
                }
                _occurredAt = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(OccurredLabel));
            }
        }
        private DateTimeOffset _occurredAt;

        public string OccurredLabel => this.OccurredAt.ToString();
        #endregion

        #region Propety - Enabled <BindableObject>
        public bool Enabled
        {
            get => _Enabled;
            set => SetProperty(ref _Enabled, value);
        }
        private bool _Enabled;

        #endregion

        #region Propety - Value <BindableObject>
        public decimal Value
        {
            get => _Value;
            set => SetProperty(ref _Value, value, () => RaisePropertyChanged(nameof(ValueLabel)));
        }
        private decimal _Value;

        public string ValueLabel => Value.ToString("#,##0.00");

        #endregion


        #region Property - Name <BindableProeprty>
        [Required(ErrorMessage = "名前を入力してね")]
        public BindableProeprty<string> Name { get; } = new BindableProeprty<string>()
            .AddPropertyChangedAction(vm => vm.RaisePropertyChanged(nameof(Name)))
            .AddPropertyChangedAction(vm => vm.RaisePropertyChanged(nameof(UpperName)))
            ;

        public string UpperName => Name.Value?.ToUpper();

        #endregion




        #region Property - Items

        #endregion

        public BindableProeprty<decimal> NewField { get; set; } = new BindableProeprty<decimal>();



        #region ICommand - ButtonCommand
        public ICommand ButtonCommand { get; }

        private async void ButtonCommandAction(ActionCommand command)
        {
            await Task.Delay(1000);
            OccurredAt = DateTimeOffset.Now.DateTime;
            Value = DateTimeOffset.Now.Millisecond;
            Enabled = true;
        }
        #endregion

        #region ICommand - ShowMessageCommand
        public ICommand ShowMessageCommand { get; }

        private async void ShowMessageCommandAction(ActionCommand command)
        {
            await _Messenger.SendAsync();
        }
        #endregion

        #region ICommand - CloseCommand
        public ICommand CloseCommand { get; }

        private async void CloseCommandAction(ActionCommand command)
        {
            await _Messenger.SendAsync();

        }
        #endregion


        // TODO Want to delegate

        #region <IDataErrorInfo>
        public string this[string columnName]
        {
            get
            {
                var results = new List<ValidationResult>();
                if (Validator.TryValidateProperty(
                    this.GetType().GetProperty(columnName).GetValue(this, null),
                    new ValidationContext(this, null, null) { MemberName = columnName },
                    results))
                {
                    return null;
                }
                // エラーがあれば最初のエラーを返す
                return results.First().ErrorMessage;
            }
        }

        public string Error
        {
            get
            {
                var results = new List<ValidationResult>();
                if (Validator.TryValidateObject(
                    this,
                    new ValidationContext(this, null, null),
                    results))
                {
                    return string.Empty;
                }

                if (results.Count() == 1)
                {
                    return results[0].ErrorMessage;
                }

                return "たくさんエラーがあります。";
                //return string.Join(Environment.NewLine, results.Select(r => r.ErrorMessage));
            }
        }

        #endregion

        public DirectoryViewModel Directory { get; }
    }
}
