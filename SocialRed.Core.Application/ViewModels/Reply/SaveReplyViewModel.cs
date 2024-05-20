using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialRed.Core.Application.ViewModels.Reply
{
    public class SaveReplyViewModel
    {
        public int Id { get; set; }
        public int? IdComment { get; set; }
        public string? ImageUserOfCreateComment { get; set; }
        public string? IUsernameUserOfCreateComment { get; set; }
        public DateTime? OfCreatedComment { get; set; }
        public string? CommentReply { get; set; }
        public int? IdPublication { get; set; }
        public string? IdUserReply { get; set; }


        [Required(ErrorMessage = "El Reply no puede ser vacio.")]
        [DataType(DataType.Text)]
        public string ContentReply { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? Created { get; set; }
    }
}
