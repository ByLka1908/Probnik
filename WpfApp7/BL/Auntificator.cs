using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7.BL
{
    class Auntificator
    {

        /// <summary>
        /// Аунтификация
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static DB.User Auntification(string login, string password)
        {
            try
            {
                DB.GamesMenedgmentEntities entities = new DB.GamesMenedgmentEntities();
                DB.User user = new DB.User();
                user = entities.User.Single(x => x.Login == login && x.Password == password);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                throw new Exception("Проблемы с аунтификацией");
            }
        }
    }
}
