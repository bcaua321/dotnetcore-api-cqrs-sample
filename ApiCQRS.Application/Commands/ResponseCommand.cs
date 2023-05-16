using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCQRS.Application
{
    public class ResponseCommand 
    {
        public string Message { get; set; }       
        
        public bool Sucess { get; set; }

        public ResponseCommand(string message, bool sucess) 
        {
            this.Message = message;
            this.Sucess = sucess;
        }     
    }
}