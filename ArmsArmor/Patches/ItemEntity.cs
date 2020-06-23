using System;
using Kingmaker.Items;
using Kingmaker.UnitLogic;

namespace ArmsArmor
{
    class ItemEntityPatch {
        [HarmonyLib.HarmonyPatch]
        public class ItemEntityCanBeEquippedInternalReversePatch {
            [HarmonyLib.HarmonyReversePatch]
            [HarmonyLib.HarmonyPatch(typeof(ItemEntity), "CanBeEquippedInternal", new Type[] { typeof(UnitDescriptor) })]
            public static bool CanBeEquippedInternal(ItemEntity __instance, UnitDescriptor owner) {
                // its a stub so it has no initial content
                throw new NotImplementedException("It's a stub");
            }
        }
    }
}