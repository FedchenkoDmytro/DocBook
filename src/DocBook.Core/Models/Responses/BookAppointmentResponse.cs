using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocBook.Core.Models.Responses
{
    public class BookAppointmentResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public int  appointmentID { get; set; }
    }
}
