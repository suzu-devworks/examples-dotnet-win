using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Examples.WinForms.Abstractions.ComponentModel
{
    //https://blog.okazuki.jp/entry/20091227/1261930083
    //https://www.nuits.jp/entry/propertychanged-fody-for-vs4mac

    public static class PropertyChangedEventHandlerExtensions
    {
        public static void Raise<TResult>(this PropertyChangedEventHandler @this, Expression<Func<TResult>> propertyName)
        {
            if (@this is null) return;

            if (propertyName.Body is not MemberExpression memberEx)
                throw new ArgumentException(null, nameof(propertyName));

            if (memberEx.Expression is not ConstantExpression senderEx)
                throw new ArgumentException(null, nameof(propertyName));

            var sender = senderEx.Value;

            @this(sender, new PropertyChangedEventArgs(memberEx.Member.Name));
        }

        public static bool RaiseIfSet<TResult>(this PropertyChangedEventHandler @this, Expression<Func<TResult>> propertyName, ref TResult source, TResult value)
        {
            if (EqualityComparer<TResult>.Default.Equals(source, value))
            {
                return false;
            }

            source = value;
            Raise(@this, propertyName);
            return true;
        }


    }
}
