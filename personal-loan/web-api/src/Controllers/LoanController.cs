using LoanApi.Models;
using LoanApi.Models.Definition;
using LoanApi.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace LoanApi.Controllers
{
    public class LoanController : ApiController
    {
        /*
         * redirect root path to swagger UI for testing
         */
        [Route("")]
        public HttpResponseMessage Get()
        {
            // redirect root to swagger UI view
            var response = new HttpResponseMessage(HttpStatusCode.Moved);
            var root = HttpContext.Current.Request.Url.AbsoluteUri;
            response.Headers.Location = new Uri($"{root}swagger/ui/index#!/Loan/Loan_Get_0");
            /*
            response.Content = new StringContent($"<html><body><h1>WebAPI Project<h1><br/><a title=\"\" href=\"swagger/ui/index#!/Loan/Loan_Get_0\">Check swagger UI for testing</a></body></html>");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            */
            return response;
        }
        
        /*
         * get list of loans for given user
         */
        [HttpGet]
        public HttpResponseMessage GetByUser(string userId)
        {
            // need validate userId before query
            // return new HttpResponseMessage(HttpStatusCode.NotFound);

            LoanStorageProvider.Init();
            var loans = LoanStorageProvider.GetLoansByUserId(userId);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ObjectContent<List<LoanDefinition>>(loans, HttpHelper.JsonFormatter, HttpHelper.SupportedMediaType);
            return response;
        }

        /*
         * get loan by id
         */
        [HttpGet]
        [Route("api/loan/{id}")]
        public HttpResponseMessage GetById(string id)
        {
            LoanStorageProvider.Init();
            var loan = LoanStorageProvider.GetLoanById(id);
            if (loan == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ObjectContent<LoanDefinition>(loan, HttpHelper.JsonFormatter, HttpHelper.SupportedMediaType);
            return response;
        }
    }
}
