using System;
using System.Reflection;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic;
using UnityModManagerNet;

namespace ArmsArmor
{
    public class Main {
        public static Settings ModSettings;
        public static UnityModManager.ModEntry ModEntry;
        private static HarmonyLib.Harmony harmonyInstance;

        static bool Load(UnityModManager.ModEntry modEntry) {
            try {
                ModEntry = modEntry;
                ModSettings = UnityModManager.ModSettings.Load<Settings>(modEntry);
                modEntry.OnSaveGUI = UI.OnSaveGui;
                modEntry.OnToggle = UI.OnToggle;
                modEntry.OnGUI = UI.OnGui;
                harmonyInstance = new HarmonyLib.Harmony(modEntry.Info.Id);
                harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex) {
                ModEntry.Logger.Error($"Exception during patching: {ex}");
                throw ex;
            }
            return true;
        }

        [HarmonyLib.HarmonyPatch(typeof(LibraryScriptableObject), "LoadDictionary")]
        static class LibraryScriptableObjectLoadDictionaryPatch {
            static void Prefix(bool ___m_Initialized, ref bool __state) {
                __state = ___m_Initialized;
            }
            static void Postfix(bool __state) {
                if (!__state) {
                    LocalizedStringHelper.Init();
                    BasicFeatsProgression.Init();
                    ExoticWeaponProficiencySelection.Init();
                    WeaponTrainingSelection.Init();
                    TempleSword.Init();
                    StandardTempleSword.Init();
                    SpikedLightShield.Init();
                    SpikedHeavyShield.Init();
                    SpikedHeavyShieldBashing.Init();
                    LightShield.Init();
                    HeavyShield.Init();
                    IrongripGauntlets.Init();
                    MonkWeaponProficiency.Init();
                    BashingEnchantment.Init();
                    BashingWeaponEnchantment.Init();
                    ImpactEnchantment.Init();
                    BashingShieldWeapon.Init();
                    BashingShieldArmor.Init();
                    ShieldMasterFeature.Init();
                    TwoWeaponFightingAttackPenaltyPatch.Init();
                    TwoWeaponFightingBasicMechanics.Init();
                    ImprovedShieldBash.Init();
                    ShieldBashAbility.Init();
                    RapidShotAbility.Init();
#if !PATCH21
                    RapidShotBuff.Init();
#endif
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(UnitDescriptor), "PostLoad")]
        class UnitDescriptorPostLoadPatch {
            static void Postfix(UnitDescriptor __instance) {
                BasicFeatsProgression.Update(__instance);
            }
        }
    }
}