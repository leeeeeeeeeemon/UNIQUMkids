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
    
    public partial class LessonChild
    {
        public int id_LessonChild { get; set; }
        public Nullable<int> id_Lesson { get; set; }
        public Nullable<int> id_Child { get; set; }
        public Nullable<int> id_Raspisanie { get; set; }
        public Nullable<int> id_Teacher { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<bool> IsConfirmed { get; set; }
    
        public virtual Child Child { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Raspisanie Raspisanie { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
