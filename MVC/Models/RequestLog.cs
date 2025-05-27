using System.ComponentModel.DataAnnotations;

namespace MVC.Models;

public class RequestLog
{
    [Key]
    public int Id { get; set; }
    public DateTime RequestDate { get; set; }
    [MaxLength(1000)]
    public string Url { get; set; }
    [MaxLength(50)]
    public string IpAddress { get; set; }
}
