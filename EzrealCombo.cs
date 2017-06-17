using HesaEngine.SDK;
using HesaEngine;
using static Ezreal.EzrealMenu;
using static WHKEzreal.WHKEzreal;


namespace Ezreal
{
    class EzrealCombo
    {
     public static void UseCombo()
        {
            var qtarg = TargetSelector.GetTarget(1150);
            var wtarg = TargetSelector.GetTarget(1000);

            if (wtarg == null) return;

            if (Main.Get<MenuCheckbox>("CW").Checked && W.IsReady())
            {
                var prediction = W.GetPrediction(wtarg);
                if (prediction.Hitchance >= HitChance.High)
                {
                    W.Cast(prediction.CastPosition);
                }

            }

            if (Main.Get<MenuCheckbox>("CQ").Checked && Q.IsReady())
            {
                var prediction = Q.GetPrediction(qtarg);
                if (prediction.Hitchance >= HitChance.High)
                {
                    Q.Cast(prediction.CastPosition);
                }
            }

        }

    }
}
