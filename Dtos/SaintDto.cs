using System;

public class SaintDto {
    public string name { get; set; }
    public string pictureUrl { get; set; }
    public string quote { get; set; }
    public string biography { get; set; }
    public string country { get; set; }
    public string status { get; set; }    
    public int? beatifiedYear { get; set; }
    public int? canonizedYear { get; set; }
    public int? latestEvent { get; set; }
    public bool martyr { get; set; }
    public DateTime? birthDate { get; set; }
    public int? deathYear { get; set; }
    public string feastDay { get; set; }
}