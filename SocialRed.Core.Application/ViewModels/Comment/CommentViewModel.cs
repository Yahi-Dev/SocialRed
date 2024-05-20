using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialRed.Core.Application.ViewModels.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string ImageProfile { get; set; }
        public string? IdOfUserPublication { get; set; }
        public int IdOfPublication { get; set; }
        public string Comments { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? Created { get; set; }
        public string IdOfUserComment { get; set; }
        public string? ImageUser {  get; set; }
        public int? IdReply { get; set; }
    }
}
