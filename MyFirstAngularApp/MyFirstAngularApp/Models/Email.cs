using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstAngularApp.Models
{
    public class Email
    {
        public string recipient { get; set; }
        public string subject { get; set; }
        public string content { get; set; }
    }
}