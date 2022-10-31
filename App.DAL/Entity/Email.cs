using System;
using System.Collections.Generic;

namespace App.DAL.Models
{
    public partial class Email
    {
        public int Id { get; set; }
        public string EmailTitle { get; set; } = null!;
        public string EmailContent { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public bool Status { get; set; }
    }
}
