using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tp.EntityFramework.Entities;

namespace Tp.API.Logic
{
    public class DigimonLogic
    {
        public async Task<List<Digimon>> GetDigimon()
        {
            HttpClient cliente = new HttpClient();
            var json = await cliente.GetStringAsync("https://digimon-api.vercel.app/api/digimon");

            dynamic digimons = JsonConvert.DeserializeObject<List<Digimon>>(json);

            return digimons;


        }
    }
}
