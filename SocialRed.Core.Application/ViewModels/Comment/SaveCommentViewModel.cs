using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.ComponentModel.DataAnnotations;

namespace SocialRed.Core.Application.ViewModels.Comment
{
    public class SaveCommentViewModel
    {
        public int Id { get; set; }
        public string? IdOfUserPublication { get; set; }
        public int? IdOfPublication { get; set; }

        public string? CreateBy { get; set; }
        public DateTime? Created { get; set; }

        [Required(ErrorMessage = "El comentario no puede ser vacio.")]
        [DataType(DataType.Text)]
        public string Comments { get; set; }
        public string? IdOfUserComment { get; set; }
        public string? ImageUser { get; set; }
        public int? IdReply { get; set; }
        public IFormFile? FileImg { get; set; }
    }
}
