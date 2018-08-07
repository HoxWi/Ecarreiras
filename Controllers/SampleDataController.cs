using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HoxWi.Client;

namespace Ecarreiras.Core.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            //you must set your secret key on hoxwi.settings.json in order to perform operations like this
            var data1 = new HoSearch().Run("summaries");

            //or you just need a public key and endpoint to perform operations like this
            var data = new HoAction().Search("PK-b39113f956ed484e933a4f1ab9d776112018JFK", "list-summaries", new { });

            return Enumerable.Range(0, data.Results.Count()-1).Select(index => new WeatherForecast
            {
                DateFormatted = data.Results[index].DateFormatted,
                TemperatureC = data.Results[index].TemperatureC,
                Summary = data.Results[index].Summary
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
