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
    
    public partial class Employee
    {
        public int id_Usr { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<int> id_Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    
        public virtual Role Role { get; set; }
    }
}