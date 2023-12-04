using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CloudMonitor.Data.Enums;

namespace CloudMonitor.Data.Models;

public class Configuration
{
    [Key]
    public uint Id { get; set; }
    
    public string UserId { get; set; }
    
    [ForeignKey("UserId")]
    public virtual User? User { get; set; }
    
    public ECheckTypes ECheckType { get; set; }
   
    public string? Name { get; set; }
    
    public string? Url { get; set; }
    
    public DateTime CheckRepeat { get; set; }
    
    public ELighthouseChecks ELighthouseCheck { get; set; }
    
    public string? AlternativeEmail { get; set; }
}