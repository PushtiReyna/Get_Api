using Azure;
using Azure.Core;
using Data_layer;
using Data_layer.Models;
using Helper.CommonModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business_layer
{
    public class GetDataBLL
    {
        public readonly ApiGetDataDbContext _db;
        public GetDataBLL(ApiGetDataDbContext db)
        {

            _db = db;

        }
        public CommomResponse GetAll()
        {
            CommomResponse response = new CommomResponse();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://movie-database-alternative.p.rapidapi.com");

                    client.DefaultRequestHeaders.Clear();
                    Movie page = new Movie()
                    {
                        s = "Avengers Endgame"
                    };
                    var paging = JsonConvert.SerializeObject(page);
                    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "71dcebf752msh9f584d63112d25dp140799jsn6fa0f402cc89");
                    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "movie-database-alternative.p.rapidapi.com"); /*https://localhost:7228*/
                    HttpContent requestContent = new StringContent(paging, Encoding.UTF8, "application/json");
                    HttpResponseMessage response1 = client.PostAsJsonAsync(client.BaseAddress, requestContent).Result;


                    var content = response1.Content.ReadAsStringAsync();
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api-football-v1.p.rapidapi.com/v3/timezone");

                    client.DefaultRequestHeaders.Clear();
                    Paging page = new Paging()
                    {
                        current = 1,
                        total = 1
                    };
                    var paging = JsonConvert.SerializeObject(page);
                    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "71dcebf752msh9f584d63112d25dp140799jsn6fa0f402cc89");
                    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "https://localhost:7228/api-football-v1.p.rapidapi.com");
                    HttpContent requestContent = new StringContent(paging, Encoding.UTF8, "application/json");

                    HttpResponseMessage response1 = client.PostAsJsonAsync(client.BaseAddress, requestContent).Result;

                    response1.EnsureSuccessStatusCode();
                    var content = response1.Content.ReadAsStringAsync();
                }
                #region MyRegion

                //if (response1.IsSuccessStatusCode)
                //{


                //    var thirdPartyData = response1.Content.ReadAsAsync<IEnumerable<TimezoneMst>>();

                //List<TimezoneMst> list = new List<TimezoneMst>();
                //   foreach (var data in content)
                //    {
                //list.Add(new TimezoneMst()
                //{
                //    Field    = data
                //})
                //        _db.TimezoneMsts.Add(data);
                //    }

                //     _db.SaveChangesAsync();

                //}


                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri("https://v3.football.api-sports.io/timezone"); 
                //       
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //   // HttpResponseMessage response1 = await client.GetAsync("api/third-party-data");
                //    HttpResponseMessage res = await client.GetAsync("api/third-party-data");

                //    if (res.IsSuccessStatusCode)
                //    {
                //    //    var thirdPartyData =  response1.Content.ReadAsAsync()<IEnumerable<TimezoneMst>>();

                //        var thirdPartyData = await res.Content.ReadAsAsync<IEnumerable<TimezoneMst>>();


                //        foreach (var data in thirdPartyData)
                //            {
                //                _db.TimezoneMsts.Add(data);
                //            }

                //            await _db.SaveChangesAsync();

                //    }

                //} 

                //model
                //    var client = new HttpClient();
                //var request = new HttpRequestMessage
                //{
                //    Method = HttpMethod.Get,
                //    RequestUri = new Uri("https://movie-database-alternative.p.rapidapi.com"),
                //    Headers =
                //    {
                //        { "X-RapidAPI-Key", "71dcebf752msh9f584d63112d25dp140799jsn6fa0f402cc89" },
                //        { "X-RapidAPI-Host", "movie-database-alternative.p.rapidapi.com" },
                //    },
                //};
                //HttpResponseMessage response1 = client.PostAsJsonAsync(client.BaseAddress, request).Result;
                #endregion

            }
            catch { throw; }

            return response;
        }
    }
}