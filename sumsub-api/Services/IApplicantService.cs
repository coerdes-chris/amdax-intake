using sumsub_api.Controllers;
using sumsub_api.Models;

namespace sumsub_api.Services;

public enum HandleReviewResult
{
    CREATED,
    UPDATED,
}

public interface IApplicantService
{
    public HandleReviewResult HandleApplicantReview(ApplicantController.ApplicantReviewedPayload review);
}