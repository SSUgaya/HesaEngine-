using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HesaEngine.SDK;


namespace Ezreal
{
    public class EzrealMenu
    {
        public static Menu Main, combo, draw, lasthit, item;

        public static void SetMenu()
        {
            Main = Menu.AddMenu("WHK Ezreal");

            var combo = Main.AddSubMenu("Combo Settings");
            combo.Add(new MenuCheckbox("CQ", "Use Q", true));
            combo.Add(new MenuCheckbox("CW", "Use W", true));

            var draw = Main.AddSubMenu("Draw Settings");
            draw.Add(new MenuCheckbox("DrawQ", "Draw [Q] Range", true));
            draw.Add(new MenuCheckbox("DrawW", "Draw [W] Range", true));
            draw.Add(new MenuCheckbox("DMG", "Draw Damage", true));

            var summonerMenu = Main.AddSubMenu("Summoners");
            summonerMenu.Add(new MenuCheckbox("healUsage", "Use Heal", true));
            summonerMenu.Add(new MenuSlider("healSlider", "Use Heal if HP is under X%", 0, 100, 5));

            //var lasthit = Main.AddSubMenu("LastHit Settings");
            //lasthit.Add(new MenuCheckbox("LastQ", "Use Q", true));

            var item = Main.AddSubMenu("Item Usage");
            item.Add(new MenuCheckbox("borkItem", "Use BOTRK", true));
            item.Add(new MenuCheckbox("borkLowHP", "Use BOTRK Only If Low HP", true));

        }
    }
}
