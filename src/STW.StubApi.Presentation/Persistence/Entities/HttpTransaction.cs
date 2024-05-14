namespace STW.StubApi.Presentation.Persistence.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class HttpTransaction
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid? CorrelationId { get; set; }

    public string RequestBody { get; set; }

    [MaxLength(6)]
    public string RequestMethod { get; set; }

    public DateTime RequestTimestamp { get; set; }

    public int ResponseStatusCode { get; set; }

    public string ResponseBody { get; set; }

    public DateTime ResponseTimestamp { get; set; }
}
