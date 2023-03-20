using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimousineApi.Models
{
    public class Notification
    {
         public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

         public string TitleEng{ get; set; }
        public string BodyEng { get; set; }
        // public string Image { get; set; }
        // public string Modle { get; set; }
        public string ModelId { get; set; }
        public int IsRead { get; set; }
        public DateTime Date { get; set; }

        public Notification()
        {
            Date = DateTime.UtcNow.AddHours(3);
        }
    }
}