namespace APIGrowthPersonal.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public ClassesDTO Classes { get; set; }
    }
}
