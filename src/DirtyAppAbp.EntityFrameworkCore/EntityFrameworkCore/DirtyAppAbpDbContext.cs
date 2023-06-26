using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DirtyAppAbp.Authorization.Roles;
using DirtyAppAbp.Authorization.Users;
using DirtyAppAbp.MultiTenancy;
using DirtyAppAbp.Domain;

namespace DirtyAppAbp.EntityFrameworkCore
{
    public class DirtyAppAbpDbContext : AbpZeroDbContext<Tenant, Role, User, DirtyAppAbpDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ApplicantSubject> ApplicantSubjects { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<StoredFile> StoredFiles { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<InstituteFaculty> InstituteFaculties { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DirtyAppAbpDbContext(DbContextOptions<DirtyAppAbpDbContext> options)
            : base(options)
        {
        }
    }
}
