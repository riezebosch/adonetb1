//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Course
    {
        public Course()
        {
            this.StudentGrades = new HashSet<StudentGrade>();
            this.Instructor = new HashSet<Instructor>();
        }
    
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual OnlineCourse OnlineCourse { get; set; }
        public virtual OnsiteCourse OnsiteCourse { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
        public virtual ICollection<Instructor> Instructor { get; set; }
    }
}
