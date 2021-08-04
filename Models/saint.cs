using System;

public class Saint
{

    public Guid Id { get; set; }
    public string name { get; set; }
    public string pictureUrl { get; set; }
    public string quote { get; set; }
    public string biography { get; set; }
    public string country { get; set; }
    public string status { get; set; }
    public int? beatifiedYear { get; set; }
    private int? latestEvent;
    public int? LatestEvent
    {
        get
        {
            return canonizedYear != null ? canonizedYear : beatifiedYear;
        }
        set
        {
            latestEvent = value;
        }
    }
    public int? canonizedYear { get; set; }
    public bool martyr { get; set; }
    public DateTime? birthDate { get; set; }
    public int? deathYear { get; set; }
    public string feastDay { get; set; }

}