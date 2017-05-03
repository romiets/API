using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lms.apis.core.Models.Definitions
{
    [Table("Settings_Text")]
    public class SettingsText
    {
        [Key, Column(Order = 0)]
        public int ID { get; set; }
        public string OwnerType { get; set; }
        public int OwnerID { get; set; }
        public string key { get; set; }
        public string value { get; set; }
        public bool Cascade { get; set; }
    }
}