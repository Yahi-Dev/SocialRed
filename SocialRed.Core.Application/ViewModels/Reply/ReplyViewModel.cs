using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialRed.Core.Application.ViewModels.Reply
{
    public class ReplyViewModel
    {
        public int Id { get; set; }
        public int? IdComment { get; set; }
        public string? CommentReply { get; set; }
        public int IdPublication { get; set; }
        public string IdUserReply { get; set; }
        public string ContentReply { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? Created { get; set; }
        public string ImageUser {  get; set; }
    }
}
