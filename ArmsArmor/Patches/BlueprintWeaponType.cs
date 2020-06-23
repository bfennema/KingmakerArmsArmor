using Kingmaker.Blueprints.Items.Weapons;

namespace ArmsArmor
{
    public class BlueprintWeaponTypePatch {
        [HarmonyLib.HarmonyPatch(typeof(BlueprintWeaponType), "IsOneHandedWhichCanBeUsedWithTwoHands", HarmonyLib.MethodType.Getter)]
        private static class BlueprintItemShieldTypePatch {
            private static void Postfix(BlueprintWeaponType __instance, ref bool __result) {
                if (__result == true && __instance.Category == Kingmaker.Enums.WeaponCategory.Rapier) {
                    __result = false;
                }
            }
        }
    }
}
