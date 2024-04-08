using Microsoft.EntityFrameworkCore;
using sumsub_api.DAL;
using sumsub_api.Services;

namespace sumsub_api_test;

public class ApplicantServiceTest
{
    [Fact]
    public void HandleReview_ShouldCreateNewApplicantIfNoneFound()
    {
        // Mock db interaction
        var options = new DbContextOptionsBuilder<ApplicantContext>()
            .UseInMemoryDatabase(databaseName: "sumsub-Applicants")
            .Options;
        var context = new ApplicantContext(options);

        var service = new ApplicantService(context);
        // Run HandleReview
        // Check if new Applicant was created
    }

    [Fact]
    public void HandleReview_ShouldUpdateExistingApplicantIFApplicantFound()
    {
        // Mock db interaction
        // Run HandleReview
        // Check if no new Applicants were created
        // Check if existing Applicant was updated
    }
}