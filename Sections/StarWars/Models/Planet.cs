namespace OpgaverApi.Sections.StarWars.Models
{
    public class Planet
    {
        public string Name { get; set; }
        public int RotationPeriod { get; set; }
        public string OrbitalPeriod { get; set; }
        public int Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public List<string> Terrain { get; set; } = new List<string>(); 
        public float SurfaceWater { get; set; }
        public long Population { get; set; }
        public List<string> Residents { get; set; } = new List<string>();
        public List<object> Films { get; set; } = new List<object>();
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
    }
}
