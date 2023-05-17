using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCQRS.Api.HttpResult.Abstraction
{
    public abstract class Next<T> where T : class
    {
        public T NextResult { get; set; } = (T)Activator.CreateInstance(typeof(T));
    }
}