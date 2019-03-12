using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorTrackerStatelessService.Model
{

    public class VisitorModel
    {
        public string VisitorName { get; set; }
        public string MobileNumber { get; set; }
        public string From { get; set; }
        public string IdNumber { get; set; }
        public string Location { get; set; }
        public string Purpose { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonEmail { get; set; }
        public string VisitorImage { get; set; }
        public DateTime VisitTime { get; set; }
    }

    public class VisitorCollection
    {
        public string VisitorName { get; set; }
        public string MobileNumber { get; set; }
        public string From { get; set; }
        public string Purpose { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonEmail { get; set; }
        public string VisitorImage { get; set; }
        public DateTime VisitTime { get; set; }
    }

    public class VisitorCollectionResponse
    {
        public string IsSuccess { get; set; }
        public string Message { get; set; }
        public List<VisitorCollection> List { get; set; }
    }
    public class Paging
    {
        public int PageNo { get; set; }
        public int PageCount { get; set; }
    }


    public class Filter
    {
        public List<string> SearchText { get; set; }
        public int PageNo { get; set; }
        public int PageCount { get; set; }
    }
    public class VisitorsCountReponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int DailyCount { get; set; }
        public int MonthlyCount { get; set; }
    }

    public class Contact
    {
        public string ContactPersonName { get; set; }
        public string EmailAddress { get; set; }
        public string SkypeId { get; set; }
    }

    public class ContactResponse
    {
        public string IsSuccess { get; set; }
        public string Message { get; set; }
        public List<Contact> List { get; set; }
    }
}


