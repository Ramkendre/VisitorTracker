using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorTrackerStatelessService.StorageModel
{
    public class Contact
    {
        [Required]
        public Guid Id { get; set; }
        public string ContactPersonName { get; set; }
        public string EmailAddress { get; set; }
        public string SkypeId { get; set; }
    }
}
