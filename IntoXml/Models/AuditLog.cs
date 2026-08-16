namespace IntoXml.Models;

public class AuditLog
{
    public int Id { get; set; }
    public string PatientFirstname { get; set; }
    public string PatientLastname { get; set; }
    public string PatientPnr { get; set; }
    public string UserFirstname { get; set; }
    public string UserLastname { get; set; }
    public string UserPnr { get; set; }
    public string Insats { get; set; }
    public DateTime LogDate { get; set; }
}