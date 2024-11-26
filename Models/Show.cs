using System.Collections.Generic;

namespace TVMazeScraper.Models;

public class Show
{
    public int id { get; set; }
    public string name { get; set; }
    public List<CastInfo> Cast { get; set; } = new List<CastInfo>();
}
