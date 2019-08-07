using CommonType.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonType.Classes
{
    public class ServiceResult
    {
        public ServiceResult(string message,ResultState state)
        {
            Message = message;
            State = state;
        }
        public string  Message { get; set; }
        public ResultState State { get; set; }
    }

    public class ServiceResult<T>:ServiceResult
    {
        public ServiceResult(string message, ResultState state, T data):base(message,state)
        {
            Data = data;
        }
        public T Data;
    }
}
