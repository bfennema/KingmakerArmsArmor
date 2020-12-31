using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.Items;
using Kingmaker.UnitLogic;
using UnityEngine;

namespace ArmsArmor
{
    class CallOfTheWild {
        public static Assembly assembly;
        private static Type UnitPartCanHold2hWeaponIn1h;
        private static MethodInfo CanBeUsedOn;
        private static MethodInfo AddEntry;
        private static Type GuidStorage;
        private static bool loaded = false;

        static public bool IsActive {
            get { return assembly != null; }
        }

        static public bool canBeUsedOn(Dictionary<Type, UnitPart> parts, ItemEntityWeapon weapon) {
            return (bool)CanBeUsedOn.Invoke(parts[UnitPartCanHold2hWeaponIn1h], new object[] { weapon });
        }

        static void addEntry(string name, string guid) {
            AddEntry.Invoke(null, new object[] { name, guid });
        }

        static void LoadPostfix() {
            if (loaded == false) {
                loaded = true;
                if (Main.ModSettings.TempleSword == true) {
                    Main.ModEntry.Logger.Log("Adding Temple Sword variants for CoTW");

                    addEntry("PsychicStandardTempleSword", CustomGuids.PsychicStandardTempleSword);
                    addEntry("TempleSwordManifestWeaponBuff", CustomGuids.TempleSwordManifestWeaponBuff);
                    addEntry("TempleSwordManifestWeaponAbility", CustomGuids.TempleSwordManifestWeaponAbility);
                    addEntry("TempleSwordManifestWeaponBothHandsBuff", CustomGuids.TempleSwordManifestWeaponBothHandsBuff);
                    addEntry("TempleSwordManifestWeaponBothHandsAbility", CustomGuids.TempleSwordManifestWeaponBothHandsAbility);
                    addEntry("TempleSwordFocusedWeaponAdvancedWeaponTrainingFeatureSelection", CustomGuids.TempleSwordFocusedWeaponAdvancedWeaponTrainingFeatureSelection);
                }
            }
        }

        static public void Init() {
            assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == "CallOfTheWild");

            if (IsActive) {
                GuidStorage = assembly.GetType("CallOfTheWild.Helpers+GuidStorage");
                var load = HarmonyLib.AccessTools.Method(GuidStorage, "load", new Type[] { typeof(string), typeof(bool) });
                var postfix = typeof(CallOfTheWild).GetMethod("LoadPostfix", BindingFlags.NonPublic | BindingFlags.Static);
                Main.harmonyInstance.Patch(load, postfix: new HarmonyLib.HarmonyMethod(postfix));
                AddEntry = HarmonyLib.AccessTools.Method(GuidStorage, "addEntry");
                UnitPartCanHold2hWeaponIn1h = assembly.GetType("CallOfTheWild.HoldingItemsMechanics.UnitPartCanHold2hWeaponIn1h");
                CanBeUsedOn = HarmonyLib.AccessTools.Method(UnitPartCanHold2hWeaponIn1h, "canBeUsedOn");
            }
        }
    }
}