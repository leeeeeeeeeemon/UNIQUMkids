//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UNIQUMkidsCore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Child
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Child()
        {
            this.LessonChild = new HashSet<LessonChild>();
        }
    
        public int id_Child { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> id_Gender { get; set; }
        public Nullable<int> id_Parent { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Gender Gender { get; set; }
        public virtual Parent Parent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LessonChild> LessonChild { get; set; }
    }
}
