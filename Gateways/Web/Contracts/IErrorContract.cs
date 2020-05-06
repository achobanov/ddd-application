using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Gateways.Web.Contracts
{
    public interface IErrorContract
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
    }
}
