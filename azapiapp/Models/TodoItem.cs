using Microsoft.EntityFrameworkCore;

namespace azapiapp.Models
{
    //--------------------------------------------------------------------------------------------------------------
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}