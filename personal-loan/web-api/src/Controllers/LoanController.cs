using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace loanapi.Controllers
{
    public class LoanController : ApiController
    {
        /*
         * redirect root path to swagger UI for testing
         */
        [Route("")]
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();
            var root = HttpContext.Current.Request.Url.AbsoluteUri;
            response.Content = new StringContent($"<html><body><h1>WebAPI Project<h1><br/><a title=\"\" href=\"swagger/ui/index#!/Loan/Loan_Get\">Check swagger UI for testing</a></body></html>");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
        
        /*
         * get list of loans for given user
         */
        [HttpGet]
        public HttpResponseMessage Get(string userId)
        {
            var response = new HttpResponseMessage();
            return response;
        }
    }
}
