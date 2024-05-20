using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialRed.Core.Application.ViewModels.Muro
{
    public class SaveMuroViewModel
    {
        public int Id { get; set; }

        public string? DescriptionPublication { get; set; }


        public string? ImagePublication { get; set; }

        public string? UserNameOfUserPublication { get; set; }



        [Required(ErrorMessage = "Debe colocar aunque sea una imagen")]
        [DataType(DataType.Upload)]
        public IFormFile? FileImg { get; set; }

        public string? CreateBy { get; set; }
        public DateTime? Created { get; set; }

        public string? IdOfUserPublication { get; set; }

        public string? UrlVideoPublication { get; set; }
    }
}
