using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagement_API.Repository;
using TaskManagement_API.Models;

namespace TaskManagement_API.Controllers
{
    public class TaskManagementController : ApiController
    {
        [HttpGet]
        [ActionName("Search")]
        public HttpResponseMessage SearchTask(string taskName = null, string parentTaskName = null, DateTime? startDate = null,
            DateTime? endDate = null,int? priorityFrom = null, int? priorityTo = null)
        {            
            try
            {
                RepositoryContext repository = new RepositoryContext();
                return Request.CreateResponse(HttpStatusCode.OK, repository.SearchTask(taskName,startDate,endDate, parentTaskName, priorityFrom,priorityTo));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

        [ActionName("GetParentList")]
        public HttpResponseMessage GetParentList()
        {
            try
            {
                RepositoryContext repository = new RepositoryContext();
                return Request.CreateResponse(HttpStatusCode.OK, repository.GetParentList());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

        [HttpPost]
        [ActionName("UpdateTask")]
        public HttpResponseMessage UpdateTask([FromBody]TaskModel task)
        {
            try
            {
                RepositoryContext repository = new RepositoryContext();
                return Request.CreateResponse(HttpStatusCode.OK, repository.UpdateTask(task));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

        [HttpPost]
        [ActionName("AddTask")]
        public HttpResponseMessage AddTask([FromBody]TaskModel task)
        {
            try
            {
                RepositoryContext repository = new RepositoryContext();
                return Request.CreateResponse(HttpStatusCode.OK, repository.AddNewTask(task));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }
    }
}
