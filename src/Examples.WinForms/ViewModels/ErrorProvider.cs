using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Examples.WinForms.ViewModels
{
    public class ErrorProvider : IDataErrorInfo, INotifyDataErrorInfo
    {
        #region <IDataErrorInfo>
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                var results = new List<ValidationResult>();
                if (Validator.TryValidateProperty(
                    GetType().GetProperty(columnName).GetValue(this, null),
                    new ValidationContext(this, null, null) { MemberName = columnName },
                    results))
                {
                    return null;
                }
                // エラーがあれば最初のエラーを返す
                return results.First().ErrorMessage;
            }
        }

        string IDataErrorInfo.Error
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

        #region <INotifyDataErrorInfo>

        bool INotifyDataErrorInfo.HasErrors => throw new NotImplementedException();

        event EventHandler<DataErrorsChangedEventArgs> INotifyDataErrorInfo.ErrorsChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable INotifyDataErrorInfo.GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
