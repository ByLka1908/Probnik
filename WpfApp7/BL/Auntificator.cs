using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7.BL
{
    class Auntificator
    {
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
                    throw new Exception("Error");
                }
            }
            catch
            {
                throw new Exception("Error");
            }
        }
    }
}
