using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using System.Reflection;
using System.Configuration;

namespace DALFactory
{
    public class DataAccess
    {
        private static string assemblyName = ConfigurationManager.AppSettings["Path"].ToString();
        private static string db = ConfigurationManager.AppSettings["DB"].ToString();
        public static IManager CreateManager()
        {
            string className = assemblyName + "." + db + "Manager";
            return (IManager)Assembly.Load(assemblyName).CreateInstance(className);
        }
        public static IUser CreateUsers()
        {
            string className = assemblyName + "." + db + "User";
            return (IUser)Assembly.Load(assemblyName).CreateInstance(className);
        }
        public static IMusic CreateMusic()
        {
            string className = assemblyName + "." + db + "Music";
            return (IMusic)Assembly.Load(assemblyName).CreateInstance(className);
        }
        public static IList CreateList()
        {
            string className = assemblyName + "." + db + "List";
            return (IList)Assembly.Load(assemblyName).CreateInstance(className);

        }
        public static IList_Comment CreateList_Comment()
        {
            string className = assemblyName + "." + db + "List_Comment";
            return (IList_Comment)Assembly.Load(assemblyName).CreateInstance(className);

        }
        public static IMusic_Comment CreateMusic_Comment()
        {
            string className = assemblyName + "." + db + "Music_Comment";
            return (IMusic_Comment)Assembly.Load(assemblyName).CreateInstance(className);
        }
         public static IArticles CreateArticles()
        {
            string className = assemblyName + "." + db + "Articles";
            return (IArticles)Assembly.Load(assemblyName).CreateInstance(className);
        }
        public static IArticles_Comment CreateArticles_Comment()
        {
            string className = assemblyName + "." + db + "Articles_Comment";
            return (IArticles_Comment)Assembly.Load(assemblyName).CreateInstance(className);
        }
        public static IMusic_Type CreateMusic_Type()
        {
            string className = assemblyName + "." + db + "Music_Type";
            return (IMusic_Type)Assembly.Load(assemblyName).CreateInstance(className);
        }
    }
}
