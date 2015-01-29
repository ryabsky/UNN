//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class class_assignments
    {
        public class_assignments()
        {
            this.group_assignments = new HashSet<group_assignments>();
        }
    
        public int class_assignment_id { get; set; }
        public int room_id { get; set; }
        public System.TimeSpan start_time_id { get; set; }
        public int weekday_id { get; set; }
        public int teacher_id { get; set; }
        public string class_name { get; set; }
        public bool lecture_indicator { get; set; }
        public Nullable<bool> odd_even_indicator { get; set; }
    
        public virtual room room { get; set; }
        public virtual start_times start_times { get; set; }
        public virtual teacher teacher { get; set; }
        public virtual weekday weekday { get; set; }
        public virtual ICollection<group_assignments> group_assignments { get; set; }
    }
}
