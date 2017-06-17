using System;
using HesaEngine.SDK;
using SharpDX;
using static Ezreal.EzrealMenu;
using static WHKEzreal.WHKEzreal;

namespace Ezreal
{
    class EzrealDraw
    {
        public static void SetDrawings()
        {
            Drawing.OnDraw += Ondrawing;
        }

        private static void Ondrawing(EventArgs args)
        {
            if (Main.Get<MenuCheckbox>("DrawQ").Checked && Q.IsReady())
            {
                Drawing.DrawCircle(ObjectManager.Player.Position, Q.Range, Color.Magenta);
            }

            if (Main.Get<MenuCheckbox>("DrawW").Checked && W.IsReady())
            {
                Drawing.DrawCircle(ObjectManager.Player.Position, W.Range, Color.Cyan);
            }
        }
    }
}
