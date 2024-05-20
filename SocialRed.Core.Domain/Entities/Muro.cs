using SocialRed.Core.Domain.Common;

namespace SocialRed.Core.Domain.Entities
{
    public class Muro : AuditableBaseEntity
    {
        public string IdOfUserPublication { get; set; }
        public string DescriptionPublication { get; set; }
        public string ImagePublication { get; set; }
        public string UrlVideoPublication { get; set; }
    }
}
