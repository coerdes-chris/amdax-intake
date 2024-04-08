using Microsoft.EntityFrameworkCore;

namespace sumsub_api.Models;

[PrimaryKey(nameof(ApplicantId))]
public class Applicant
{
    public string ExternalUserId { get; set; }
    public string ApplicantId { get; set; }

    public ApplicantReview Review { get; set; }
}