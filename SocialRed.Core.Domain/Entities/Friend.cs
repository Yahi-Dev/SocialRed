namespace SocialRed.Core.Domain.Entities
{
    public class Friend 
    {
        public virtual int Id { get; set; }
        public string IdUserApplicant { get; set; }
        public string IdUserFollowed { get; set; }
    }
}
