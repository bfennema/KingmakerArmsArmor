using System;
using System.Reflection;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using UnityModManagerNet;

namespace ArmsArmor
{
    public class Main {
        public static Settings ModSettings;
        public static UnityModManager.ModEntry ModEntry;
        public static HarmonyLib.Harmony harmonyInstance;

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
            static void Prefix(bool ___m_Initialized, out bool __state) {
                __state = ___m_Initialized;
            }
            static void Postfix(bool __state) {
                if (!__state) {
                    CallOfTheWild.Init();
                    ProperFlanking20.Init();
                    LocalizedStringHelper.Init();
                    BasicFeatsProgression.Init();
                    FeatSelection.Init();
                    WeaponTrainingSelection.Init();
                    ExoticWeaponProficiencySelection.Init();
                    if (ModSettings.TempleSword == true) {
                        TempleSword.Init();
                        StandardTempleSword.Init();
                        MonkWeaponProficiency.Init();
                        WeaponFocusTempleSword.Init();
                    }
                    if (ModSettings.OrcHornbow == true) {
                        OrcHornbow.Init();
                        StandardOrcHornbow.Init();
                        MartialWeaponProficiency.Init();
                        WeaponFocusOrcHornbow.Init();
                        AspectOfTheFalcon.Init();
                        HurricaneBow.Init();
                        ArcheryBonusesFeature.Init();
                        ArcheryBonusesLesserFeature.Init();
                        RubyPhoenixFeature.Init();
                    }
                    if (ModSettings.UpsettingShieldStyle) {
                        StandardWeaponBuckler.Init();
                    }
                    DefaultsForWeaponCategories.Init();
                    CombatCompetenceProficiencies.Init();
                    SpikedLightShield.Init();
                    SpikedHeavyShield.Init();
                    SpikedLightShieldBashingPlus1.Init();
                    SpikedHeavyShieldBashingPlus1.Init();
                    LightShield.Init();
                    HeavyShield.Init();
                    IrongripGauntlets.Init();
                    BashingEnchantment.Init();
                    BashingWeaponEnchantment.Init();
                    ImpactEnchantment.Init();
                    BashingShieldWeapon.Init();
                    BashingShieldArmor.Init();
                    ShieldMasterFeature.Init();
                    TwoWeaponFightingBasicMechanics.Init();
                    ImprovedShieldBash.Init();
                    if (!ProperFlanking20.IsActive) {
                        ImprovedDisarm.Init();
                        ImprovedTrip.Init();
                        ImprovedSunderArmor.Init();
                    }
                    ShieldBashAbility.Init();
                    RapidShotAbility.Init();
                    RogueLike_NPCVendorTable.Init();
                    C11_OlegVendorTable.Init();
                    DragonStyleBuff.Init();
#if !PATCH21
                    RapidShotBuff.Init();
#endif
                }
            }
            [HarmonyLib.HarmonyPostfix]
            [HarmonyLib.HarmonyPatch("LoadDictionary")]
            [HarmonyLib.HarmonyPriority(HarmonyLib.Priority.Last)]
            static void PostfixLast(bool __state) {
                if (!__state) {
                    CallOfTheWild.LoadDictionary();
                    ProperFlanking20.LoadDictionary();
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(UnitEntityData), "PostLoad")]
        class UnitDescriptorPostLoadPatch {
            static void Postfix(UnitEntityData __instance) {
                BasicFeatsProgression.Update(__instance.Descriptor);
            }
        }
    }
}
