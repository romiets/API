using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lms.apis.core.Models.Definitions
{
    [Table("Admin_state")]
    public class State
    {
        [Key, Column(Order = 0)]
        public int stateID { get; set; }
        public string stateName { get; set; }
        public string countryCode { get; set; }
        public string Description { get; set; }

    }
}