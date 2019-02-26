using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IMusic_Type:IBase<Music_Type >
    {
        Music_Type SelectID(int id);
        int DeleteID(int id);
    }
}
