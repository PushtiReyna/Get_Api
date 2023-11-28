using Business_layer;
using Helper.CommonModel;
using Service_layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_layer.Implementation
{
    public class GetDataImpl: IGetData
    {
        public readonly GetDataBLL _getDataBLL;
        public GetDataImpl(GetDataBLL getDataBLL)
        {
            _getDataBLL = getDataBLL;
        }
        public CommomResponse GetAll()
        {
            return _getDataBLL.GetAll();
        }
    }
}
