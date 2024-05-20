using SocialRed.Core.Domain.Common;

namespace SocialRed.Core.Domain.Entities
{
    public class Comment : AuditableBaseEntity
    {
        public string IdOfUserPublication { get; set; }
        public int IdOfPublication {  get; set; }
        public string Comments { get; set; }
        public string IdOfUserComment { get; set; }
        public int IdReply { get; set; }



        public Publication? Publication { get; set; }


        public ICollection<Reply> Replies { get; set; }

    }
}
