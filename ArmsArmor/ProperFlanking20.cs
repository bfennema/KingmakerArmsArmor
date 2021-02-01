using System;
using System.Linq;
using System.Reflection;
using Kingmaker.Blueprints;

namespace ArmsArmor
{
    class ProperFlanking20 {
        public static Assembly assembly;
        private static bool dictionary = false;

        static public bool IsActive {
            get { return assembly != null; }
        }

        static public void LoadDictionary() {
            if (dictionary == false) {
                dictionary = true;

                ImprovedDisarm.Init();
                ImprovedTrip.Init();
                ImprovedSunderArmor.Init();
            }
        }

        static bool AddPostfix(string typeName, string funcName, Type[] parameters = null, string postfixName = null) {
            var type = assembly.GetType("ProperFlanking20." + typeName);
            if (type == null) {
                type = assembly.GetType("ProperFlanking20+" + typeName);
            }
            if (type == null) {
                Main.ModEntry.Logger.Log($"AddPostfix: assembly.GetType(\"ProperFlanking20[.+]{typeName}\") returned null");
            }
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
            assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == "ProperFlanking20");
        }
    }
}