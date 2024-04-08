using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sumsub_api.Models;
using sumsub_api.Services;

namespace sumsub_api.Controllers;

[ApiController]
[Route("webhook/applicant")]
public class ApplicantController : ControllerBase
{
    public class ApplicantReviewedPayload
    {
        public class ApplicantReviewResultPayload
        {
            [JsonProperty]
            public string moderationComment { get; set; }

            [JsonProperty]
            public string clientComment { get; set; }

            [JsonProperty]
            public string reviewAnswer { get; set; }

            [JsonProperty]
            public List<string> rejectLabels { get; set; }

            [JsonProperty]
            public string reviewRejectType { get; set; }

            public static implicit operator ReviewResult(ApplicantReviewResultPayload payload) => new ReviewResult
            {
                moderationComment = payload.moderationComment,
                clientComment = payload.clientComment,
                reviewAnswer = payload.reviewAnswer,
                rejectLabels = payload.rejectLabels,
                reviewRejectType = payload.reviewRejectType
            };
        }
        
        [JsonProperty]
        public string applicantId { get; set; }
        
        [JsonProperty]
        public string inspectionId { get; set; }
        
        [JsonProperty]
        public string correlationId { get; set; }
        
        [JsonProperty]
        public string externalUserId { get; set; }
        
        [JsonProperty]
        public string levelName { get; set; }
        
        [JsonProperty]
        public string type { get; set; }
        
        [JsonProperty]
        public ApplicantReviewResultPayload reviewResult { get; set; }
        
        [JsonProperty]
        public string reviewStatus { get; set; }
        
        [JsonProperty]
        public string createdAtMs { get; set; }

        public static implicit operator ApplicantReview(ApplicantReviewedPayload payload) => new ApplicantReview
        {
            applicantId = payload.applicantId,
            inspectionId = payload.inspectionId,
            correlationId = payload.correlationId,
            externalUserId = payload.externalUserId,
            levelName = payload.levelName,
            type = payload.type,
            reviewResult = payload.reviewResult,
            reviewStatus = payload.reviewStatus,
            createdAtMs = payload.createdAtMs
        };
    }
    
    private IApplicantService _applicantService;
    
    public ApplicantController(IApplicantService applicantService)
    {
        _applicantService = applicantService;
    }
    
    [HttpPost]
    [Route("reviewed")]
    public IActionResult ApplicantReviewed(
        [FromBody] ApplicantReviewedPayload review
    )
    {
        // Do some business logic
        var result = _applicantService.HandleApplicantReview(review);

        if (result == HandleReviewResult.CREATED)
        {
            return StatusCode(201);
        } else if (result == HandleReviewResult.UPDATED)
        {
            return StatusCode(204);
        }

        return StatusCode(200);
    }
}