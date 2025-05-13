namespace APIGrowthPersonal.Models
{
    public class Classes
    {
        public int id {  get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public double factorStrength { get; set; }
        public double factorIntelligence { get; set; }
        public double factorDexterity { get; set; }
        public double factorPhysique { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
