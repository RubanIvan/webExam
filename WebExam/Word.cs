//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebExam
{
    using System;
    using System.Collections.Generic;
    
    public partial class Word
    {
        public int WordID { get; set; }
        public Nullable<int> WordPackageID { get; set; }
        public string En { get; set; }
        public string Ru { get; set; }
    
        public virtual WordPackage WordPackage { get; set; }
    }
}
