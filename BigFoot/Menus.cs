//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BigFoot
{
    using System;
    using System.Collections.Generic;
    
    public partial class Menus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menus()
        {
            this.SubMenus = new HashSet<SubMenus>();
        }
    
        public int MenuID { get; set; }
        public string Menu { get; set; }
        public string mUrl { get; set; }
        public Nullable<int> PageID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubMenus> SubMenus { get; set; }
        public virtual Pages Pages { get; set; }
    }
}
