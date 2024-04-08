using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace sumsub_api.Models;


[JsonObject]
public class ReviewResult
{
    [Required]
    [Key]
    [ForeignKey("ApplicantReview")]
    public string ApplicantReviewId { get; set; }
    public ApplicantReview ApplicantReview { get; set; }

    public string moderationComment { get; set; }

    public string clientComment { get; set; }

    public string reviewAnswer { get; set; }

    public List<string> rejectLabels { get; set; }

    public string reviewRejectType { get; set; }
}

[JsonObject]
public class ApplicantReview
{
    [Required]
    [Key]
    [ForeignKey("Applicant")]
    public string _ApplicantId { get; set; }
    public Applicant Applicant { get; set; }
    
    public string applicantId { get; set; }
        
    public string inspectionId { get; set; }
        
    public string correlationId { get; set; }
        
    public string externalUserId { get; set; }
        
    public string levelName { get; set; }
        
    public string type { get; set; }
        
    public ReviewResult reviewResult { get; set; }
        
    public string reviewStatus { get; set; }
        
    public string createdAtMs { get; set; }
}