using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SWII6_Models.Dtos;
using SWII6_Models.Models;
using System.Net;

namespace SWII6_TP04.Services
{
    public class CarroService
    {
        private string baseURL;
        public CarroService()
        {
            baseURL = "http://localhost:5151";
        }

        public async Task<Carro> Get(int id)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseURL}/carros/{id}");


            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var carro = JsonConvert.DeserializeObject<Carro>(await response.Content.ReadAsStringAsync());

            return carro;
        }

        public async Task<List<Carro>> GetAll()
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseURL}/carros");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            
            var carros = JsonConvert.DeserializeObject<List<Carro>>(await response.Content.ReadAsStringAsync());

            return carros;
        }

        public async Task<bool> Create(CarroCreateDTO dto)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseURL}/carros");

            var content = JsonConvert.SerializeObject(dto);

            request.Content = new StringContent(content, null, "application/json");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync();

            return response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<bool> Delete(int id)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Delete, $"{baseURL}/carros/{id}");


            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync();

            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> Update(CarroUpdateDTO dto)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Put, $"{baseURL}/carros/{dto.Id}");

            var content = JsonConvert.SerializeObject(dto);

            request.Content = new StringContent(content, null, "application/json");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync();

            return response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}
