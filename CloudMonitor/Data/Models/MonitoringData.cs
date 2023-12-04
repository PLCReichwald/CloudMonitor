using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CloudMonitor.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace CloudMonitor.Data.Models;

public class MonitoringData
{
    [Key]
    public uint Id { get; set; }
    
    public uint ConfigId { get; set; }
    
    public string UserId { get; set; }

    public DateTime Timestamp { get; set; }

    public EStatusCodes EStatusCode { get; set; }
    
    public string StatusMessage { get; set; }
    
    public DateTime AvailableAgain { get; set; }
}