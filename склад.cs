//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQL_WPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class склад
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public склад()
        {
            this.заказы = new HashSet<заказы>();
        }
    
        public string код_заказа { get; set; }
        public string код_товара { get; set; }
        public string наименование_товара { get; set; }
        public Nullable<System.DateTime> дата_поступления { get; set; }
        public Nullable<double> количество_поступившего { get; set; }
        public Nullable<System.DateTime> дата_выбытия { get; set; }
        public Nullable<double> количество_выбывшего { get; set; }
        public string еденицы_измерения { get; set; }
        public Nullable<int> цена_за_еденицу_бел_руб { get; set; }
        public string срок_гарантии { get; set; }
        public string код_поставщика { get; set; }
        public string наименование_поставщика { get; set; }
        public string код_поставки { get; set; }
        public byte[] upsize_ts { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<заказы> заказы { get; set; }
        public virtual поставщики поставщики { get; set; }
    }
}
