﻿using EloBuddy;
using EloBuddy.SDK;
using System.Linq;
using UBAddons.Libs;

namespace UBAddons.Champions.Ziggs.Modes
{
    class JungleClear : Ziggs
    {
        public static void Execute()
        {
            if (player.ManaPercent < MenuValue.JungleClear.ManaLimit) return;
            if (MenuValue.JungleClear.UseQ && Q.IsReady())
            {
                var monster = Q3.GetJungleMobs();
                if (monster.Any())
                {
                    CastQ3(monster.First());
                }
            }
            if (MenuValue.JungleClear.UseW && W.IsReady())
            {
                var mob = W.GetJungleMobs();
                if (mob.Any())
                {
                    if (W.Cast(mob.First()))
                    {
                        Core.DelayAction(() => Player.CastSpell(SpellSlot.W), W.CastDelay + (int)player.Distance(mob.First().Position) / W.Speed);
                    }
                }
            }
            if (MenuValue.JungleClear.UseE && E.IsReady())
            {
                var mob = E.GetJungleMobs();
                if (mob.Any())
                {
                    E.Cast(mob.First());
                }
            }
        }
    }
}
