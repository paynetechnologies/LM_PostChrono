using System.ComponentModel.DataAnnotations;
using gov.uscourts.ao.rest.dal.Interfaces.IDomain;

namespace gov.uscourts.ao.rest.dal.Domain
{
    public class ChronoStatus //: IChronoStatus
    {
        [Key]
        public int ChronoStatusId { get; set; }
        [Required]
        public string application { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public int retryCount { get; set; }
        [Required]
        public string addDate { get; set; }
        [Required]
        public string retryDate { get; set; }
        [Required]
        public string modifiedDate { get; set; }

        public virtual ChronoLog chronoLog { get; set; }
    }
}