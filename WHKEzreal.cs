using System;
using HesaEngine.SDK;
using HesaEngine.SDK.Enums;
using HesaEngine.SDK.GameObjects;
using static HesaEngine.SDK.Orbwalker;
using static Ezreal.EzrealMenu;
using static Ezreal.EzrealCombo;
using static Ezreal.EzrealDraw;
//using static Ezreal.EzrealLastHit;

namespace WHKEzreal
{
    public class WHKEzreal : IScript
    {
        public string Author => "WahooK";
        public string Name => "WHKEzreal";
        public string Version => "7.12";

        public static Spell Q, W;
        public static Item bork;
        public static Spell Heal;
        public static AIHeroClient Ezreal => ObjectManager.Player;
        public static Orbwalker.OrbwalkerInstance MyOrb => Core.Orbwalker;

        public void OnInitialize()
        {
            Game.OnGameLoaded += LoadComplete;
        }

        private void LoadComplete()
        {
            if (ObjectManager.Player.Hero != Champion.Ezreal) return;

            Chat.Print("Welcome To <b><font color='#389BFF'>WHK_Ezreal</font></b> <font color='#FF0000'> v.7.1.2 </font>");
            Chat.Print("Heal and LastHit is Testing now <b> <font color='#33FFFF'>*Not Working </font></b>");
            Chat.Print("Have a Nice day with HesaEngine :D");

            SetMenu();
            SetSpells();
            SetDrawings();

            Game.OnUpdate += GameUpdate;
        }

        private void GameUpdate()
        {
            switch (MyOrb.ActiveMode)
            {
                case Orbwalker.OrbwalkingMode.Combo:
                    UseCombo();
                    break;
                    //case Orbwalker.OrbwalkingMode.LastHit:
                    //UseLastHit();
                    //break;
                    Summoners();
            }
        }

        private void SetSpells()
        {
            Q = new Spell(SpellSlot.Q, 1150, TargetSelector.DamageType.Physical);
            W = new Spell(SpellSlot.W, 1000, TargetSelector.DamageType.Physical);

            Q.SetSkillshot(0.25f, 60f, 2000f, true, SkillshotType.SkillshotLine);
            W.SetSkillshot(0.25f, 80f, 1600f, false, SkillshotType.SkillshotLine);

            //Heal = new Spell(Ezreal.GetSpellSlotFromName("summonerheal"), 600);
            bork = new Item(ItemId.Blade_of_the_Ruined_King, 550);

        }

        public void Summoners()
        {
            if (Main.Get<MenuCheckbox>("borkItem").Checked)
            {
                if (bork.IsOwned() && bork.IsReady())
                {
                    var enemy = TargetSelector.GetTarget(Ezreal.GetAutoAttackRange(Ezreal), TargetSelector.DamageType.Physical);
                    if (enemy == null) return;
                    if (Main.Get<MenuCheckbox>("borkLowHP").Checked)
                    {
                        if (enemy.HealthPercent > 50)
                        {
                            bork.Cast(enemy);
                        }
                    }
                    else
                    {
                        bork.Cast(enemy);
                    }
                }
                //else if (Heal.IsReady())
                {
                   // var healSlot = ObjectManager.Player.GetSpellSlotFromName(SummonerSpells.Heal);
                   // if (Heal != null && Heal.IsReady())
                   //if (Main.Get<MenuCheckbox>("healUsage").Checked)
                       // {
                           // if (Ezreal.HealthPercent >= Main.Get<MenuSlider>("healthpSlider").CurrentValue)
                           // {
                           //     Heal.Cast();
                         //   }
                      //  }
                     //   else
                      //  {
                      //      Heal.Cast();
                      //  }
                }
            }
        }
    }
}
