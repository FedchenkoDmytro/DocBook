using System.ComponentModel.DataAnnotations;

namespace DocBook.Core.Models.DTOs
{
    public class WorkingHoursDTO
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
