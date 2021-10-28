using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7.BL
{
    class Delete
    {
        public static void Deleted(DB.Games games)
        {
            try
            {
                DB.GamesMenedgmentEntities entities = new DB.GamesMenedgmentEntities();
                entities.Games.Remove(entities.Games.Find(games.Id));
                entities.SaveChanges();
            }
            catch
            {
                throw new Exception("Ошибка при удалении");
            }
        }
    }
}