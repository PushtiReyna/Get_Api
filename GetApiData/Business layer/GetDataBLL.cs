using Azure;
using Azure.Core;
using Data_layer;
using Data_layer.Models;
using DTO.GetData;
using Helper.CommonModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;
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
        public async Task<CommomResponse> GetAll()
        {
            CommomResponse response = new CommomResponse();
            try
            {
                #region MyRegion
                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri("https://movie-database-alternative.p.rapidapi.com");

                //    client.DefaultRequestHeaders.Clear();
                //    Movie page = new Movie()
                //    {
                //        s = "Avengers Endgame"
                //    };
                //    var paging = JsonConvert.SerializeObject(page);
                //    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "71dcebf752msh9f584d63112d25dp140799jsn6fa0f402cc89");
                //    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "movie-database-alternative.p.rapidapi.com"); /*https://localhost:7228*/
                //    HttpContent requestContent = new StringContent(paging, Encoding.UTF8, "application/json");
                //    HttpResponseMessage response1 = client.PostAsJsonAsync(client.BaseAddress, requestContent).Result;


                //    var content = response1.Content.ReadAsStringAsync();
                //} 
                //client.DefaultRequestHeaders.Add("access_key", "b1f4dde6b15d86c6cb6894462a96d47e");
                //client.DefaultRequestHeaders.Add("&symbols", "AAPL");
                #endregion

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://api.marketstack.com/v1/eod?access_key=b1f4dde6b15d86c6cb6894462a96d47e&symbols=AAPL");

                    client.DefaultRequestHeaders.Clear();
                    //pagination page = new pagination()
                    //{
                    //    limit = 100,
                    //    offset = 0,
                    //    count = 100,
                    //    total = 251
                    //};
                    //var paging = JsonConvert.SerializeObject(page);
                    //HttpContent requestContent = new StringContent(paging, Encoding.UTF8, "application/json");

                    HttpResponseMessage response1 = client.GetAsync(client.BaseAddress).Result;

                    ///response1.EnsureSuccessStatusCode();
                    var content = await response1.Content.ReadAsStringAsync();


                    // var json = JsonConvert.SerializeObject(content);

                    //var dataTable = JsonConvert.DeserializeObject(content);

                    //string apiResponse = await response1.Content.ReadAsStringAsync();
                    // var data = JsonConvert.DeserializeObject<List<Datum>>(apiResponse);

                  
                    var getDataReqDTO = JsonConvert.DeserializeObject<GetDataReqDTO>(content);
                    //List<GetDataReqDTO> getDataReqDTOs = getDataReqDTO.Adapt<List<GetDataReqDTO>>();
                    List<Datum> data = new List<Datum>();
                    foreach (var ITEM in getDataReqDTO.data)
                    {
                        Datum datum = new Datum();
                        datum.AdjVolume = ITEM.adj_volume;
   
                        data.Add(datum);
                    }

                    _db.Data.AddRange(data);
                    _db.SaveChanges();


                }

                #region MyRegion

                //if (response1.IsSuccessStatusCode)
                //{




                //  var thirdPartyData = response1.Content.ReadAsAsync<IEnumerable<Datum>>();

                //    List<Datum> list = new List<Datum>();
                //    foreach (var item in dataTable)
                //    {

                //        _db.SaveChanges();
                //    }

                //    //_db.SaveChangesAsync();

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