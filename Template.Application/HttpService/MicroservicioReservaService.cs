using MicroservicioHotel.Domain.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.HttpService
{
    public class MicroservicioReservaService
    {
        public HttpClient Client { get; }

        public MicroservicioReservaService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44373/");
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");

            Client = client;
        }

        public async Task<List<ResponseHabitacionesReservadasByHotelId>> GetHabitacionesReservadasEntre(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                var response = await Client.GetAsync($"/api/reserva/fecha/?fechaInicio={fechaInicio}&&fechaFin={fechaFin}");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string jsonText = await response.Content.ReadAsStringAsync();

                    var deserialized = JsonConvert.DeserializeObject<List<ResponseHabitacionesReservadasByHotelId>>(jsonText);
                    return deserialized;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
