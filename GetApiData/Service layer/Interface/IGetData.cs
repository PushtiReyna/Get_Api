using Helper.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_layer.Interface
{
    public interface IGetData
    {
        public CommomResponse GetAll();
    }
}
