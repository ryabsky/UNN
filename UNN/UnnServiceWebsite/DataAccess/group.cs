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
    
    public partial class group
    {
        public group()
        {
            this.group_assignments = new HashSet<group_assignments>();
        }
    
        public int group_id { get; set; }
        public int year_id { get; set; }
        public int direction_id { get; set; }
    
        public virtual direction direction { get; set; }
        public virtual ICollection<group_assignments> group_assignments { get; set; }
    }
}
