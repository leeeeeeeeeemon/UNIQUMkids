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
    
    public partial class Lesson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lesson()
        {
            this.LessonChild = new HashSet<LessonChild>();
        }
    
        public int id_Lesson { get; set; }
        public string Name { get; set; }
        public Nullable<int> MinYear { get; set; }
        public Nullable<int> MaxYear { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> id_Teacher { get; set; }
    
        public virtual Teacher Teacher { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LessonChild> LessonChild { get; set; }
    }
}
