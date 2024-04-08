using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sumsub_api.Models;

namespace sumsub_api.DAL;

public class ApplicantContext : DbContext
{
    public ApplicantContext(DbContextOptions<ApplicantContext> options) : base(options)
    { }
    
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<ApplicantReview> Reviews { get; set; }
    public DbSet<ReviewResult> ReviewResults { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReviewResult>().Property(p => p.rejectLabels)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v)
            );
    }
}