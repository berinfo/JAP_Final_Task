using System;

namespace server.Dtos
{
    public class GetCategoryDto
    {
        public int Id { get; set; } 
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
    }
}
