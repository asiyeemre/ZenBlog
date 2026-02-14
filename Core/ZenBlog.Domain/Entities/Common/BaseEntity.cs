using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenBlog.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        //Bu class tüm entitylerde ortak olan özellikleri tutar. 
        public Guid Id { get; set; }//her kaydın bir numarası olur 
        public DateTime CreatedAt { get; set; } //Kayıt açıldığı tarih 
        public DateTime UpdatedAt { get; set; } //Güncellendiği tarih 



    }
}
