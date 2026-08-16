using IntoXml.Models;

namespace IntoXml.Sql;

public static class MockData
{
    public static List<AuditLog> ReadData()
    {
        var data = new List<AuditLog>
        {
            new ()
            {
                Id = 1,
                PatientFirstname = "Adam",
                PatientLastname = "Adamsson",
                PatientPnr = "191001010101",
                UserFirstname = "David",
                UserLastname = "Davidsson",
                UserPnr = "194004040404",
                Insats = "<insats><id>1</id></insats>",
                LogDate = new DateTime(2026, 1, 1, 12, 13, 14)
            },
            new ()
            {
                Id = 2,
                PatientFirstname = "Bengt",
                PatientLastname = "Bengtsson",
                PatientPnr = "192002020202",
                UserFirstname = "Erik",
                UserLastname = "Eriksson",
                UserPnr = "195005050505",
                Insats = "<insats><id>2</id></insats>",
                LogDate = new DateTime(2026, 2, 1, 12, 12, 14)
            },
            new ()
            {
                Id = 1,
                PatientFirstname = "Carl",
                PatientLastname = "Carlsson",
                PatientPnr = "193003030303",
                UserFirstname = "Filip",
                UserLastname = "Filipsson",
                UserPnr = "196006060606",
                Insats = "<insats><id>3</id></insats>",
                LogDate = new DateTime(2026, 2, 1, 12, 12, 14)
            },
            new ()
            {
                Id = 1,
                PatientFirstname = "Adam",
                PatientLastname = "Adamsson",
                PatientPnr = "191001010101",
                UserFirstname = "Gustav",
                UserLastname = "Gustavsson",
                UserPnr = "197007070707",
                Insats = "<insats><id>4</id></insats>",
                LogDate = new DateTime(2025, 2, 2, 13, 14, 15)
            },
            new ()
            {
                Id = 1,
                PatientFirstname = "Adam",
                PatientLastname = "Adamsson",
                PatientPnr = "191001010101",
                UserFirstname = "Henrik",
                UserLastname = "Henriksson",
                UserPnr = "198008080808",
                LogDate = new DateTime(2025, 2, 2, 13, 14, 15)
            },
        };
        return data;
    }
}