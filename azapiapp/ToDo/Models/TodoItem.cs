using Microsoft.EntityFrameworkCore;

namespace azapiapp.ToDo
{
    //--------------------------------------------------------------------------------------------------------------
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}