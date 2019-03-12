using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorTrackerStatelessService.Model
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ResponseModel
    {

        public bool IsSuccess { get; set; }
        public string Message { get; set; }

    }
}
