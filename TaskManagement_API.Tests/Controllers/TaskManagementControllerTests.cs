using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManagement_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement_API.Models;
using System.Net.Http;

namespace TaskManagement_API.Controllers.Tests
{
    [TestClass()]
    public class TaskManagementControllerTests
    {
        [TestMethod()]
        public void SearchTaskTest()
        {
            TaskManagementController controller = new TaskManagementController();
            
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            HttpResponseMessage searchResultResponse = new HttpResponseMessage();
            searchResultResponse = controller.SearchTask();
            Assert.AreEqual(System.Net.HttpStatusCode.OK, searchResultResponse.StatusCode);
        }

        [TestMethod()]
        public void GetParentListTest()
        {
            TaskManagementController controller = new TaskManagementController();

            controller.Request = new HttpRequestMessage();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            HttpResponseMessage searchResultResponse = new HttpResponseMessage();
            searchResultResponse = controller.GetParentList();
            Assert.AreEqual(System.Net.HttpStatusCode.OK, searchResultResponse.StatusCode);
        }

        [TestMethod()]
        public void UpdateTaskTest()
        {
            TaskManagementController controller = new TaskManagementController();
            TaskModel task = new TaskModel();
            task.TaskID = 1;
            task.TaskName = "Task 1";
            task.StartDate = DateTime.Now.ToString("dd-MMMM-yyyy");
            task.EndDate = DateTime.Now.AddDays(2).ToString("dd-MMMM-yyyy");
            task.IsCompleted = false;
            task.Priority = 10;
            task.ParentTaskID = 1;
            task.ParentTaskName = "Paretn Task1";
            
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            HttpResponseMessage searchResultResponse = new HttpResponseMessage();
            searchResultResponse = controller.UpdateTask(task);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, searchResultResponse.StatusCode);
        }

        [TestMethod()]
        public void AddTaskTest()
        {
            TaskManagementController controller = new TaskManagementController();
            Random random = new Random();
            int randomNumber = random.Next(1, 10000);

            TaskModel task = new TaskModel();            
            task.TaskName = "Task " + randomNumber;
            task.StartDate = DateTime.Now.ToString("dd-MMMM-yyyy");
            task.EndDate = DateTime.Now.AddDays(2).ToString("dd-MMMM-yyyy");
            task.IsCompleted = false;
            task.Priority = 10;
            task.ParentTaskID = 1;
            task.ParentTaskName = "Paretn Task1";

            controller.Request = new HttpRequestMessage();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            HttpResponseMessage searchResultResponse = new HttpResponseMessage();
            searchResultResponse = controller.AddTask(task);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, searchResultResponse.StatusCode);
        }
    }
}