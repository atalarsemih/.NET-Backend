using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilittes.Results
{
    public class Result : IResult
    {


        public Result(bool success, string message):this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }


        public bool Success { get; }
        public string Message { get; }
        public object Data { get; set; }
        public int? InsertedItemId { get; private set; }


    }

}
