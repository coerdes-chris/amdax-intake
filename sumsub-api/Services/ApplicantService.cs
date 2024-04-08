using sumsub_api.Controllers;
using sumsub_api.DAL;
using sumsub_api.Models;

namespace sumsub_api.Services;

public class ApplicantService : IApplicantService
{
    private ApplicantContext _db;
    
    public ApplicantService(ApplicantContext db)
    {
        _db = db;
    }
    
    public HandleReviewResult HandleApplicantReview(ApplicantController.ApplicantReviewedPayload review)
    {
        HandleReviewResult result;
        
        // Check if applicant already exists in db
        var existingApplicant = _db.Applicants.Where(
                applicant =>
                    applicant.ApplicantId == review.applicantId
                    && applicant.ExternalUserId == review.externalUserId
            )
            .FirstOrDefault();

        if (existingApplicant == null)
        {
            // Save new applicant (+ review)
            existingApplicant = new Applicant();
            existingApplicant.ApplicantId = review.applicantId;
            existingApplicant.ExternalUserId = review.externalUserId;
            existingApplicant.Review = review;
            existingApplicant.Review.Applicant = existingApplicant;
            existingApplicant.Review.reviewResult.ApplicantReview = existingApplicant.Review;
            _db.Applicants.Add(existingApplicant);

            result = HandleReviewResult.CREATED;
        }
        else
        {
            // Update existing review
            var existingReview = _db.Reviews.SingleOrDefault(
                r => r.applicantId == existingApplicant.ApplicantId
            );
            var existingReviewResult = _db.ReviewResults.SingleOrDefault(
                rr => rr.ApplicantReviewId == existingApplicant.ApplicantId
            );

            existingReview = review;
            existingReviewResult = review.reviewResult;

            existingReview._ApplicantId = existingApplicant.ApplicantId;
            existingReviewResult.ApplicantReviewId = existingApplicant.ApplicantId;

            existingApplicant.Review = review;
            existingReview.reviewResult = existingReviewResult;

            result = HandleReviewResult.UPDATED;
        }

        _db.SaveChanges();

        return result;
    }
}