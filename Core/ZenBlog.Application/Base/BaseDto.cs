namespace ZenBlog.Application.Base
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }//her kaydın bir numarası olur 
        public DateTime CreatedAt { get; set; } //Kayıt açıldığı tarih 
        public DateTime UpdatedAt { get; set; }

    }
}
