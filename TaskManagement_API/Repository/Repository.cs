using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagement_API.Models;

namespace TaskManagement_API.Repository
{
    public class RepositoryContext
    {
        private ExampleData_USInsuranceEntities _entity;
        public RepositoryContext()
        {
            _entity = new ExampleData_USInsuranceEntities();
        }

        public List<TaskModel> SearchTask(string taskName, DateTime? startDate, 
            DateTime? endDate, string parentTaskName, int? priorityFrom, int? priorityTo)
        {
            var query = (from t in _entity.Tasks
                         join p in _entity.ParentTasks on t.Parent_ID equals p.Parent_ID
                         select new TaskModel()
                         {
                             TaskID = t.Task_ID,
                             TaskName = t.Task1,
                             EndDate = t.End_Date,
                             StartDate = t.Start_Date,
                             IsCompleted = t.IsCompleted,
                             ParentTaskID = t.Parent_ID,
                             ParentTaskName = p.Parent_Task,
                             Priority = t.Priority
                         });
            if(!string.IsNullOrEmpty(taskName))
            {
                query = query.Where(i => i.TaskName.ToLower().Contains(taskName.ToLower()));
            } 
            if(startDate !=null)
            {
                query = query.Where(i => i.StartDate == startDate);
            }
            if (endDate != null)
            {
                query = query.Where(i => i.EndDate == endDate);
            }
            if (!string.IsNullOrEmpty(parentTaskName))
            {
                query = query.Where(i => i.ParentTaskName.ToLower() == parentTaskName.ToLower());
            }
            if(priorityFrom != null && priorityTo != null)
            {
                query = query.Where(i => (i.Priority >= priorityFrom && i.Priority <= priorityTo));
            }

            List<TaskModel> taskModelList = query.ToList();
            return taskModelList;
        }

        public List<ParentTaskModel> GetParentList()
        {
            List<ParentTaskModel> parentTasks = (from p in _entity.ParentTasks
                                                 select new ParentTaskModel
                                                 {
                                                     ParentTaskID = p.Parent_ID,
                                                     ParentTaskName = p.Parent_Task
                                                 }).ToList();
            return parentTasks;
        }

        public int AddNewTask(TaskModel taskModel)
        {
            Task task = new Task();
            task.Task1 = taskModel.TaskName;
            task.IsCompleted = taskModel.IsCompleted;
            task.Parent_ID = taskModel.ParentTaskID;
            task.Priority = taskModel.Priority;
            task.Start_Date = taskModel.StartDate;
            task.End_Date = taskModel.EndDate;
            _entity.Tasks.Add(task);
            _entity.SaveChanges();

            return task.Task_ID;
        }

        public bool UpdateTask(TaskModel taskModel)
        {
            Task task = (from t in _entity.Tasks
                         where t.Task_ID == taskModel.TaskID
                         select t).FirstOrDefault();
            if (task != null)
            {
                task.Task1 = taskModel.TaskName;
                task.IsCompleted = taskModel.IsCompleted;
                task.Parent_ID = taskModel.ParentTaskID;
                task.Priority = taskModel.Priority;
                task.Start_Date = taskModel.StartDate;
                task.End_Date = taskModel.EndDate;              
                _entity.SaveChanges();
                return true;
            }
            return false;
        }
    }
}