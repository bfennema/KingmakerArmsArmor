using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Enums;
using Kingmaker.Items;
using Kingmaker.Items.Slots;
using Kingmaker.UnitLogic;
using Kingmaker.Utility;

namespace ArmsArmor
{
    class CallOfTheWild {
        public static Assembly assembly;
        private static Type UnitPartCanHold2hWeaponIn1h;
        private static MethodInfo UnitPartCanHold2hWeaponIn1hCanBeUsedOn;
        private static MethodInfo AddEntry;
        private static bool loaded = false;
        private static Type FullProficiency;
        private static MethodInfo HasProficiency;
        private static Type CanUse2hWeaponAs1hBase;
        private static MethodInfo CanUse2hWeaponAs1hBaseCanBeUsedOn;
        private static MethodInfo CanUse2hWeaponAs1hBaseCanBeUsedAs2h;
        private static Type CanUseSpellCombatBase;
        private static MethodInfo CanUseSpellCombatBaseCanBeUsedOn;
        private static Type ConsiderAsLightWeaponBase;
        private static MethodInfo ConsiderAsLightWeaponBaseCanBeUsedOn;

        static public bool IsActive {
            get { return assembly != null; }
        }

        static public bool canBeUsedOn(Dictionary<Type, UnitPart> parts, ItemEntityWeapon weapon) {
            return (bool)UnitPartCanHold2hWeaponIn1hCanBeUsedOn.Invoke(parts[UnitPartCanHold2hWeaponIn1h], new object[] { weapon });
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

        static void HasFullProficiencyPostfix(WeaponCategory category, ref bool __result, List<Fact> ___buffs) {
            if (__result == false) {
                foreach (var b in ___buffs) {
                    foreach (var c in b.Components) {
                        if (FullProficiency.IsAssignableFrom(c.GetType())) {
                            var is_ok = (bool)HasProficiency.Invoke(c, new object[] { category });
                            if (is_ok) {
                                __result = true;
                                return;
                            }
                        }
                    }
                }
            }
        }

        static void UnitPartCanHold2hWeaponIn1hCanBeUsedOnPostfix(ItemEntityWeapon weapon, ref bool __result, List<Fact> ___buffs) {
            if (__result == false) {
                if (___buffs.Empty()) {
                    return;
                }

                foreach (var b in ___buffs) {
                    foreach (var c in b.Components) {
                        if (CanUse2hWeaponAs1hBase.IsAssignableFrom(c.GetType())) {
                            var result = (bool)CanUse2hWeaponAs1hBaseCanBeUsedOn.Invoke(c, new object[] { weapon });
                            if (result) {
                                __result = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void UnitPartCanHold2hWeaponIn1hcanBeUsedAs2hPostfix(ItemEntityWeapon weapon, ref bool __result, List<Fact> ___buffs) {
            if (__result == false) {
                if (___buffs.Empty()) {
                    return;
                }

                foreach (var b in ___buffs) {
                    foreach (var c in b.Components) {
                        if (CanUse2hWeaponAs1hBase.IsAssignableFrom(c.GetType())) {
                            var can_2h = (bool)CanUse2hWeaponAs1hBaseCanBeUsedAs2h.Invoke(c, new object[] { weapon });
                            var can_use = (bool)CanUse2hWeaponAs1hBaseCanBeUsedOn.Invoke(c, new object[] { weapon });
                            if (can_use && can_2h) {
                                __result = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void UnitPartCanUseSpellCombatCanBeUsedOnPostfix(HandSlot primary_hand, HandSlot secondary_hand, bool use_two_handed, ref bool __result, List<Fact> ___buffs) {
            if (__result == false) {
                if (___buffs.Empty()) {
                    return;
                }

                foreach (var b in ___buffs) {
                    foreach (var c in b.Components) {
                        if (CanUseSpellCombatBase.IsAssignableFrom(c.GetType())) {
                            var result = (bool)CanUseSpellCombatBaseCanBeUsedOn.Invoke(c, new object[] { primary_hand, secondary_hand, use_two_handed });
                            if (result) {
                                __result = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void UnitPartConsiderAsLightWeaponCanBeUsedOnPostfix(ItemEntityWeapon weapon, ref bool __result, List<Fact> ___buffs) {
            if (__result == false) {
                if (___buffs.Empty()) {
                    return;
                }

                foreach (var b in ___buffs) {
                    foreach (var c in b.Components) {
                        if (ConsiderAsLightWeaponBase.IsAssignableFrom(c.GetType())) {
                            var result = (bool)ConsiderAsLightWeaponBaseCanBeUsedOn.Invoke(c, new object[] { weapon });
                            if (result) {
                                __result = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        static bool AddPostfix(string typeName, string funcName, Type[] parameters = null, string postfixName = null) {
            var type = assembly.GetType("CallOfTheWild." + typeName);
            return type != null && AddPostfix(type, funcName, parameters, postfixName);
        }

        static bool AddPostfix(Type type, string funcName, Type[] parameters = null, string postfixName = null) {
            var func = HarmonyLib.AccessTools.Method(type, funcName, parameters);
            return func != null && AddPostfix(type, func, postfixName);
        }

        static bool AddPostfix(Type type, MethodInfo func, string postfixName = null) {
            if (postfixName == null) {
                postfixName = func.Name + "Postfix";
            }

            var postfix = typeof(CallOfTheWild).GetMethod(postfixName, BindingFlags.NonPublic | BindingFlags.Static);
            if (postfix != null) {
                var patch = Main.harmonyInstance.Patch(func, postfix: new HarmonyLib.HarmonyMethod(postfix));
                if (patch != null) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        static public void Init() {
            assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == "CallOfTheWild");

            if (IsActive) {
                var GuidStorage = assembly.GetType("CallOfTheWild.Helpers+GuidStorage");
                AddPostfix(GuidStorage, "load", new Type[] { typeof(string), typeof(bool) }, nameof(LoadPostfix));

                FullProficiency = assembly.GetType("CallOfTheWild.WeaponsFix+FullProficiency");
                HasProficiency = HarmonyLib.AccessTools.Method(FullProficiency, "hasProficiency");
                AddPostfix("WeaponsFix+UnitPartFullProficiency", "hasFullProficiency", new Type[] { typeof(WeaponCategory) }, nameof(HasFullProficiencyPostfix));

                AddEntry = HarmonyLib.AccessTools.Method(GuidStorage, "addEntry");
                UnitPartCanHold2hWeaponIn1h = assembly.GetType("CallOfTheWild.HoldingItemsMechanics.UnitPartCanHold2hWeaponIn1h");
                UnitPartCanHold2hWeaponIn1hCanBeUsedOn = HarmonyLib.AccessTools.Method(UnitPartCanHold2hWeaponIn1h, "canBeUsedOn", new Type[] { typeof(ItemEntityWeapon) });
                AddPostfix(UnitPartCanHold2hWeaponIn1h, UnitPartCanHold2hWeaponIn1hCanBeUsedOn, nameof(UnitPartCanHold2hWeaponIn1hCanBeUsedOnPostfix));

                AddPostfix(UnitPartCanHold2hWeaponIn1h, "canBeUsedAs2h", new Type[] { typeof(ItemEntityWeapon) }, nameof(UnitPartCanHold2hWeaponIn1hcanBeUsedAs2hPostfix));

                CanUse2hWeaponAs1hBase = assembly.GetType("CallOfTheWild.HoldingItemsMechanics.CanUse2hWeaponAs1hBase");
                CanUse2hWeaponAs1hBaseCanBeUsedOn = HarmonyLib.AccessTools.Method(CanUse2hWeaponAs1hBase, "canBeUsedOn", new Type[] { typeof(ItemEntityWeapon) });
                CanUse2hWeaponAs1hBaseCanBeUsedAs2h = HarmonyLib.AccessTools.Method(CanUse2hWeaponAs1hBase, "canBeUsedAs2h", new Type[] { typeof(ItemEntityWeapon) });

                AddPostfix("HoldingItemsMechanics.UnitPartCanUseSpellCombat", "canBeUsedOn", new Type[] { typeof(HandSlot), typeof(HandSlot), typeof(bool) }, nameof(UnitPartCanUseSpellCombatCanBeUsedOnPostfix));

                CanUseSpellCombatBase = assembly.GetType("CallOfTheWild.HoldingItemsMechanics.CanUseSpellCombatBase");
                CanUseSpellCombatBaseCanBeUsedOn = HarmonyLib.AccessTools.Method(CanUseSpellCombatBase, "canBeUsedOn", new Type[] { typeof(HandSlot), typeof(HandSlot), typeof(bool) });

                AddPostfix("HoldingItemsMechanics.UnitPartConsiderAsLightWeapon", "canBeUsedOn", new Type[] { typeof(ItemEntityWeapon) }, nameof(UnitPartConsiderAsLightWeaponCanBeUsedOnPostfix));

                ConsiderAsLightWeaponBase = assembly.GetType("CallOfTheWild.HoldingItemsMechanics.ConsiderAsLightWeaponBase");
                ConsiderAsLightWeaponBaseCanBeUsedOn = HarmonyLib.AccessTools.Method(ConsiderAsLightWeaponBase, "canBeUsedOn", new Type[] { typeof(ItemEntityWeapon) });
            }
        }
    }
}