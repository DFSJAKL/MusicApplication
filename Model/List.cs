//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class List
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public List()
        {
            this.List_Comment = new HashSet<List_Comment>();
            this.List_Keep = new HashSet<List_Keep>();
            this.List_Music_Keep = new HashSet<List_Music_Keep>();
        }
    
        public int list_id { get; set; }
        public string list_name { get; set; }
        public string list_mess { get; set; }
        public string list_image { get; set; }
        public Nullable<System.DateTime> list_time { get; set; }
        public Nullable<int> tuijian { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<List_Comment> List_Comment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<List_Keep> List_Keep { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<List_Music_Keep> List_Music_Keep { get; set; }
    }
}
