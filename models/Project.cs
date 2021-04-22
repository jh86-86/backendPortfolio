using System.ComponentModel.DataAnnotations;
using System;

public class Project {
    public long Id { get; set; }
    
    public string Name { get; set; }

    public string Link { get; set; }
    public string Image { get; set; }
    public string ProjectInfo { get; set; }

    public string Description { get; set; }
}

