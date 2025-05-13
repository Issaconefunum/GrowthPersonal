using Microsoft.AspNetCore.Identity;

namespace APIGrowthPersonal.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string secondName { get; set; }
        public string password { get; set; }
        public int? id_class { get; set; } // Знак вопроса означает, что поле может быть null
        
    }
}
