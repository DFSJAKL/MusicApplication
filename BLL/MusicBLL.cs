using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using Model;
using IDAL;


namespace BLL
{
    public class MusicBLL:BaseManager<Music1>
    {
        private IMusic imusic = DataAccess.CreateMusic();
        public override IBase<Music1> GetDal()
        {
            return DataAccess.CreateMusic();
        }
        public bool Delete(int id)
        {
            return imusic.Delete(id) > 0;
        }
    }
}
