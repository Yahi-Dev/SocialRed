using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialRed.Core.Application.ViewModels.Friends
{
    public class SaveFriendViewModel
    {
        public int? Id { get; set; }
        public string? IdUSerSearchFriend { get; set; }


        [Required(ErrorMessage = "El usuario no puede ser vacio")]
        [DataType(DataType.Text)]
        public string UserNameFriend { get; set; }
    }
}
