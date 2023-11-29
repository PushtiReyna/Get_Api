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
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://api.marketstack.com/v1/eod?access_key=b1f4dde6b15d86c6cb6894462a96d47e&symbols=AAPL");

                    client.DefaultRequestHeaders.Clear();
                    HttpResponseMessage res = client.GetAsync(client.BaseAddress).Result;

                    var content = await res.Content.ReadAsStringAsync();

                    if (res.IsSuccessStatusCode)
                    {
                        var getDataReqDTO = JsonConvert.DeserializeObject<GetDataReqDTO>(content);
                        List<ApiGetDataMst> lstApiGetDataMst = new List<ApiGetDataMst>();
                        foreach (var item in getDataReqDTO.data)
                        {
                            ApiGetDataMst apiGetDataMst = new ApiGetDataMst();
                            apiGetDataMst.High = item.high;
                            apiGetDataMst.Low = item.low;
                            apiGetDataMst.AdjHigh = item.adj_high;
                            apiGetDataMst.AdjLow = item.adj_low;

                            lstApiGetDataMst.Add(apiGetDataMst);
                        }

                        _db.ApiGetDataMsts.AddRange(lstApiGetDataMst);
                        _db.SaveChanges();
                        response.Status = true;
                        response.Message = "Data are stored in database successfully!";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Message = "Data are not stored in database";
                        response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    }
                }
            }
            catch { throw; }

            return response;
        }
    }
}