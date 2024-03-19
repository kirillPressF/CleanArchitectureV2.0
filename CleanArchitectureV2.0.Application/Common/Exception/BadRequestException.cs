using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureV2._0.Application.Common.Exception
{
    public class BadRequestException : System.Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string[] errors) : base("Multiple errrors occured. See error details.")
        {
            Errors = errors;
        }
        public string[] Errors { get; set; }
    }
}

