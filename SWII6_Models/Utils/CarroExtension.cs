using SWII6_Models.Dtos;
using SWII6_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWII6_Models.Utils
{
    public static class CarroExtension
    {

        public static Carro toModel(this CarroCreateDTO dto)
        {
            return new Carro()
            {
                Id = 0,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                Placa = dto.Placa,
                Ano = dto.Ano
            };
        }

        public static Carro toModel(this CarroUpdateDTO dto)
        {
            return new Carro()
            {
                Id = dto.Id,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                Placa = dto.Placa,
                Ano = dto.Ano
            };
        }

        public static void toUpdateWithDto(this Carro carro, CarroUpdateDTO dto)
        {
            carro.Modelo = dto.Modelo;
            carro.Placa = dto.Placa;
            carro.Marca = dto.Marca;
            carro.Ano = dto.Ano;
        }
    }
}
