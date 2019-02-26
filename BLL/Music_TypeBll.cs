using DALFactory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Music_TypeBll:BaseManager<Music_Type>
    {
        public override IBase<Music_Type> GetDal()
        {
            return DataAccess.CreateMusic_Type();
        }
        public Music_Type SelectID(int id)
        {
            return DataAccess.CreateMusic_Type().SelectID(id);
        }
        public bool DeleteID(int id)
        {
            return DataAccess.CreateMusic_Type().DeleteID(id) > 0;
        }
    }
}
