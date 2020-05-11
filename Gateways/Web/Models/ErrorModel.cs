using Blog.Gateways.Web.Contracts;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Gateways.Web.Models
{
    public class ErrorModel : IErrorContract
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
       
        public ErrorModel(string message = "Generic Error Message!")
        {
            this.IsError = true;
            this.Message = message;
        }
    }
}
