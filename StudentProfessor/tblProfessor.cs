//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentProfessor
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProfessor
    {
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }
        public string ProfessorName { get; set; }
    
        public virtual courseTable courseTable { get; set; }
    }
}