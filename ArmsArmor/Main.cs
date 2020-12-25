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
                }
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(UnitDescriptor), "PostLoad")]
        class UnitDescriptorPostLoadPatch {
            static void Postfix(UnitDescriptor __instance) {
            }
        }
    }
}
