using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7.BL
{
    public class ViewGame
    {
        public DB.Games Games { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string SteamEpic { get; set; }
        public string Ubisoft { get; set; }
        public ViewGame(DB.Games games)
        {
            Games = games;
            Image = string.IsNullOrWhiteSpace(games.ImagePatch) ? @"/ImageDef.jpg" : games.ImagePatch;
            Name = $"Имя: {games.Name}";
            Price = $"Деньги: {games.Price}";
            Description = $"Описание: {games.Description}";
            SteamEpic = $"Steam: {games.Steam.YesOrNo}   Epic: {games.Epic.YesOrNo}";
            Ubisoft = $"Ubisoft: {games.Ubisoft.YesOrNo}";
        }
    }
}
