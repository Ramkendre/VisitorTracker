using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisitorTrackerStatelessService.Mappers;
using VisitorTrackerStatelessService.Model;
using VisitorTrackerStatelessService.StorageModel;
using VisitorTrackerStatelessService.Helpers;
using Storage = VisitorTrackerStatelessService.StorageModel;
using Domain = VisitorTrackerStatelessService.Model;


namespace VisitorTrackerStatelessService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackerController : ControllerBase
    {
        private readonly VisitorContext dbContext;
        public TrackerController(VisitorContext context)
        {
            dbContext = context;
        }
        // GET api/values/5
        [HttpPost("Login")]
        public ActionResult<ResponseModel> Login(LoginModel model)
        {
            return new ResponseModel { IsSuccess = true, Message = "Login Successful." };
        }

        [HttpPost("AddVisitor")]
        public ActionResult<ResponseModel> AddVisitor([FromBody] VisitorModel model)
        {
            var storageVisitor = Mapper.ConvertVisitorDomainModelToStorage(model);
            dbContext.Visitors.Add(storageVisitor);
            dbContext.SaveChanges();
            return new ResponseModel { IsSuccess = true, Message = "Save Successful." };
        }

        //[Microsoft.AspNetCore.Mvc.HttpPost]
        //[System.Web.Http.Route("api/Values/AddVisitor")]
        //public IHttpActionResult CreateDocument([Microsoft.AspNetCore.Mvc.FromBody] VisitorModel model)
        //{
        //    var storageVisitor = Mapper.ConvertVisitorDomainModelToStorage(model);
        //    dbContext.Visitors.Add(storageVisitor);
        //    dbContext.SaveChanges();
        //    var response = new ResponseModel();
        //    response.IsSuccess = true;
        //    response.Message = "Save Successful.";
        //    return (IHttpActionResult)Ok(response);
        //}

        [HttpPost("GetVisitors")]
        public ActionResult<VisitorCollectionResponse> GetVisitors(Filter model)
        {
            List<VisitorCollection> visitorsList = new List<VisitorCollection>();
            // var storageVisitors = dbContext.Visitors.Paginate(model.PageNo, model.PageCount);
            foreach (var item in model.SearchText)
            {
                var storageVisitors = dbContext.Visitors.Where(x => (x.VisitorName.Contains(item) || x.Purpose.Contains(item) || x.ContactPerson.Contains(item) || x.MobileNumber.Contains(item)) && (x.VisitTime.Date > DateTime.Now.AddDays(-1).Date && x.VisitTime.Date <= DateTime.Now.Date));
                foreach (var storageModel in storageVisitors)
                {
                    var visitorModel = Mapper.ConvertVisitorStorageToDomainModel(storageModel);
                    visitorsList.Add(visitorModel);
                }
            }
            if (visitorsList.Count > 0)
                visitorsList = visitorsList.Paginate(model.PageNo, model.PageCount).ToList();
            //List<VisitorCollection> List = new List<VisitorCollection> { new VisitorCollection { ContactPerson = "Richard", From = "India", MobileNumber = "zzzzzzzz", Purpose = "Interview", VisitorImage = "", VisitorName = "Interviewer", VisitTime = DateTime.Now.ToShortDateString() } };
            return new VisitorCollectionResponse { List = visitorsList, IsSuccess = "True", Message = string.Empty };
        }

        [HttpPost("GetMonthlyVisitors")]
        public ActionResult<VisitorCollectionResponse> GetMonthlyVisitors(Filter model)
        {
            List<VisitorCollection> visitorsList = new List<VisitorCollection>();
            foreach (var item in model.SearchText)
            {
                var storageVisitors = dbContext.Visitors.Where(x => (x.VisitorName.Contains(item) || x.Purpose.Contains(item) || x.ContactPerson.Contains(item) || x.MobileNumber.Contains(item)) && (x.VisitTime.Date > DateTime.Now.AddMonths(-1).Date && x.VisitTime.Date <= DateTime.Now.Date));
                foreach (var storageModel in storageVisitors)
                {
                    var visitorModel = Mapper.ConvertVisitorStorageToDomainModel(storageModel);
                    visitorsList.Add(visitorModel);
                }
            }
            if (visitorsList.Count > 0)
                visitorsList = visitorsList.Paginate(model.PageNo, model.PageCount).ToList();
            //List<VisitorCollection> List = new List<VisitorCollection> { new VisitorCollection { ContactPerson = "Richard", From = "India", MobileNumber = "zzzzzzzz", Purpose = "Interview", VisitorImage = "", VisitorName = "Interviewer", VisitTime = DateTime.Now.ToShortDateString() } };
            return new VisitorCollectionResponse { List = visitorsList, IsSuccess = "True", Message = string.Empty };
        }


        [HttpPost("GetVisitorsByNameAndPurpose")]
        public ActionResult<VisitorCollectionResponse> GetVisitorsByNameAndPurpose(Filter model)
        {
            List<VisitorCollection> visitorsList = new List<VisitorCollection>();
            foreach (var item in model.SearchText)
            {
                var storageVisitors = dbContext.Visitors.Where(x => x.VisitorName.Contains(item) || x.Purpose.Contains(item) || x.ContactPerson.Contains(item) || x.MobileNumber.Contains(item)).ToList();
                foreach (var storageModel in storageVisitors)
                {
                    var visitorModel = Mapper.ConvertVisitorStorageToDomainModel(storageModel);
                    visitorsList.Add(visitorModel);
                }
            }

            if (visitorsList.Count > 0)
                visitorsList = visitorsList.Paginate(model.PageNo, model.PageCount).ToList();
            //List<VisitorCollection> List = new List<VisitorCollection> { new VisitorCollection { ContactPerson = "Richard", From = "India", MobileNumber = "zzzzzzzz", Purpose = "Interview", VisitorImage = "", VisitorName = "Interviewer", VisitTime = DateTime.Now.ToShortDateString() } };
            return new VisitorCollectionResponse { List = visitorsList, IsSuccess = "True", Message = string.Empty };
        }

        [HttpGet("GetTodaysAndMonthlyCount")]
        public ActionResult<VisitorsCountReponse> GetTodaysAndMonthlyCount()
        {
            var todaysVisitors = dbContext.Visitors.Where(x => x.VisitTime.Date == DateTime.Now.Date).Count();
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var lastMonth = DateTime.Now.AddMonths(-1);
            var monthlyVisitors = dbContext.Visitors.Where(x => x.VisitTime.Date > lastMonth.Date && x.VisitTime.Date <= DateTime.Now.Date).Count();
            return new VisitorsCountReponse { Message = string.Empty, IsSuccess = true, DailyCount = todaysVisitors, MonthlyCount = monthlyVisitors };
        }

        [HttpPost("GetContactPersons")]
        public ActionResult<ContactResponse> GetContactPersons(Filter model)
        {
            List<Domain.Contact> contactList = new List<Domain.Contact>();
            foreach (var item in model.SearchText)
            {
                var storageContacts = dbContext.Contact.Where(x => x.ContactPersonName.Contains(item) || x.EmailAddress.Contains(item)).ToList();
                foreach (var storageModel in storageContacts)
                {
                    var contactModel = Mapper.ConvertContactStorageToDomainModel(storageModel);
                    contactList.Add(contactModel);
                }
            }
            if (contactList.Count > 0)
                contactList = contactList.Paginate(model.PageNo, model.PageCount).ToList();
            //List<VisitorCollection> List = new List<VisitorCollection> { new VisitorCollection { ContactPerson = "Richard", From = "India", MobileNumber = "zzzzzzzz", Purpose = "Interview", VisitorImage = "", VisitorName = "Interviewer", VisitTime = DateTime.Now.ToShortDateString() } };
            return new ContactResponse { List = contactList, IsSuccess = "True", Message = string.Empty };
        }

    }
}
