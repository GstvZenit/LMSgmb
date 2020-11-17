using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.API.Responses
{
    public class APIResponse<T>
    {
        public T Data { get; set; }
        public APIResponse(T data)
        {
            Data = data;
        }
    }
}
