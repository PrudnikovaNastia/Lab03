using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace WpfApp1
{
    class DateError:Exception
    {
        public override string Message { get; }
        public DateError(DateTime dateError, string mes)
        {
            DateTime? getDate = dateError;
            Message = mes;
        }
        public DateError(DateTime dateError)
        {
            Message = $"{dateError.ToString(CultureInfo.InvariantCulture)}? (незадовільна дата)";
        }

    }
}
