﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialRed.Core.Application.DTOs.Account
{
    public class ForgotPasswordResponse
    {
        public string Error { get; set; }
        public bool HasError { get; set; }
    }
}
