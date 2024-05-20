using SocialRed.Core.Domain.Common;

namespace SocialRed.Core.Domain.Entities
{
    public class Reply : AuditableBaseEntity
    {
        public int IdComment { get; set; }
        public string CommentReply { get; set; }
        public int IdPublication { get; set; }
        public string IdUserReply { get; set; }
        public string ContentReply { get; set; }


        public Comment? Comments { get; set; }
    }
}
