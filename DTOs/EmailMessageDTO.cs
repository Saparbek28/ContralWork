using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionLesson.DTOs
{
    public class EmailMessageDTO
    {
        public string To { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
