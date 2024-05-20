using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialRed.Core.Application.ViewModels.Publication
{
    public class SavePublicationViewModel
    {
        public int Id { get; set; }



        [Required(ErrorMessage = "Debe agregar una descripcion.")]
        [DataType(DataType.Text)]
        public string DescriptionPublication { get; set; }


        public string? ImagePublication { get; set; }




        [DataType(DataType.Upload)]
        public IFormFile? FileImg { get; set; }

        public string? CreateBy { get; set; }
        public DateTime? Created { get; set; }

        public string? IdOfUserPublication { get; set; }

        public string? UrlVideoPublication { get; set; }

    }
}
