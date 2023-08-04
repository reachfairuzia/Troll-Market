using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMarket.ViewModel.Account
{
    public class RegistAccountViewModel
    {
        [Required(ErrorMessage = "harap di isi")]
        [MinLength(8, ErrorMessage = "panjang kurang dari 8")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "harap di isi")]
        [MinLength(8, ErrorMessage = "panjang kurang dari 8")]
        public string Password { get; set; }

        [Required(ErrorMessage = "harap di isi")]
        public string Name { get; set; }

        [Required(ErrorMessage = "harap di isi")]
        public string Address { get; set; }

        [AllowNull]
        public string Role { get; set; }

    }
}
