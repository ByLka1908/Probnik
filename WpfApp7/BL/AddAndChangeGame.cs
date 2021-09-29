using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7.BL
{
    class AddAndChangeGame
    {
        public static bool AddGames(string name, string price, string description, string image, object steam, object epic, object ubisoft)
        {
            DB.Games games = new DB.Games();
            try
            {
                games.Name = name;
                games.Price = Convert.ToInt32(price);
                games.Description = description;
                games.ImagePatch = image;
                games.Id_Steam = GetSteam(steam as string);
                games.Id_Epic = GetEpic(epic as string);
                games.Id_Ubisoft = GetUbisoft(ubisoft as string);
            }
            catch
            {
                throw new Exception("Error");
            }
            if (games == null)
            {
                return false;
            }
            try
            {
                DB.GamesMenedgmentEntities entities = new DB.GamesMenedgmentEntities();
                entities.Games.Add(games);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error");
            }
        }

        private static int GetSteam(string store)
        {
            try
            {
                DB.GamesMenedgmentEntities entities = new DB.GamesMenedgmentEntities();
                return entities.Steam.Where(x => x.YesOrNo == store).First().Id;
            }
            catch
            {
                throw new Exception("Error");
            }
        }

        private static int GetEpic(string store)
        {
            try
            {
                DB.GamesMenedgmentEntities entities = new DB.GamesMenedgmentEntities();
                return entities.Epic.Where(x => x.YesOrNo == store).First().Id;
            }
            catch
            {
                throw new Exception("Error");
            }
        }
        private static int GetUbisoft(string store)
        {
            try
            {
                DB.GamesMenedgmentEntities entities = new DB.GamesMenedgmentEntities();
                return entities.Ubisoft.Where(x => x.YesOrNo == store).First().Id;
            }
            catch
            {
                throw new Exception("Error");
            }
        }

        public static bool ChangeGame(string name, string price, string description, string image, object steam, object epic, object ubisoft, DB.Games game)
        {
            DB.GamesMenedgmentEntities ent = new DB.GamesMenedgmentEntities();
            DB.Games games = ent.Games.Find(game.Id);
            try
            {
                games.Name = name;
                games.Price = Convert.ToInt32(price);
                games.Description = description;
                games.ImagePatch = image;
                games.Id_Steam = GetSteam(steam as string);
                games.Id_Epic = GetEpic(epic as string);
                games.Id_Ubisoft = GetUbisoft(ubisoft as string);
            }
            catch
            {
                throw new Exception("Error");
            }
            if (games == null)
            {
                return false;
            }
            try
            {
                DB.GamesMenedgmentEntities entities = new DB.GamesMenedgmentEntities();
                entities.Games.AddOrUpdate(games);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error");
            }
        }
    }
}
