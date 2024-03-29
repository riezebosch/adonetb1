﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseFirstDemoLazyLoading
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class SchoolEntities : DbContext
    {
        public SchoolEntities()
            : base("name=SchoolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<OnlineCourse> OnlineCourses { get; set; }
        public DbSet<OnsiteCourse> OnsiteCourses { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }
    
        public virtual ObjectResult<StudentGrade> GetStudentGrades(Nullable<int> studentID)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StudentGrade>("GetStudentGrades", studentIDParameter);
        }
    
        public virtual ObjectResult<StudentGrade> GetStudentGrades(Nullable<int> studentID, MergeOption mergeOption)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StudentGrade>("GetStudentGrades", mergeOption, studentIDParameter);
        }
    }
}
