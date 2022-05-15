using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    class EmailError : Exception

    {

        public override string Message { get; }
        public EmailError(string mes)
        {
            Message = $"Незадовільний формат імейлу: {mes}";
        }


    }
}
