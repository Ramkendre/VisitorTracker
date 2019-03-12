using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorTrackerStatelessService.StorageModel
{
    public class Visitors
    {
        [Required]
        public Guid Id { get; set; }
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
}
