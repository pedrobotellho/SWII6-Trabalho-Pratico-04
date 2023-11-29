using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWII6_Models.Dtos
{
    public class CarroUpdateDTO
    {
        [Required(ErrorMessage = "obrigatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "obrigatorio")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "obrigatorio")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "obrigatorio")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "obrigatorio")]
        public short Ano { get; set; }
    }
}
