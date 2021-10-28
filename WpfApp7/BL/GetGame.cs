using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7.BL
{
    class GetGame
    {
        public static List<ViewGame> GetGames()
        {
            try
            {
                DB.GamesMenedgmentEntities entities = new DB.GamesMenedgmentEntities();
                var game = entities.Games.ToList();
                List<ViewGame> view = new List<ViewGame>();
                foreach(var item in game)
                {
                    view.Add(new ViewGame(item));
                }
                return view;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
