using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7.BL
{
    class GetStore
    {
        public static List<string> GetSteam()
        {
            try
            {
                DB.GamesMenedgmentEntities entities = new DB.GamesMenedgmentEntities();
                var game = entities.Steam.Select(x => x.YesOrNo).ToList();
                return game;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static List<string> GetUbisoft()
        {
            try
            {
                DB.GamesMenedgmentEntities entities = new DB.GamesMenedgmentEntities();
                var game = entities.Ubisoft.Select(x => x.YesOrNo).ToList();
                return game;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static List<string> GetEpic()
        {
            try
            {
                DB.GamesMenedgmentEntities entities = new DB.GamesMenedgmentEntities();
                var game = entities.Epic.Select(x => x.YesOrNo).ToList();
                return game;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
