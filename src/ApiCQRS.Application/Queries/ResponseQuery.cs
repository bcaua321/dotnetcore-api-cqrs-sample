using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiCQRS.Application
{
    public class ResponseQuery<T> 
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; }
        
        public T Result { get; set; }

        public bool Sucess { get; set; } = true;
    }
}