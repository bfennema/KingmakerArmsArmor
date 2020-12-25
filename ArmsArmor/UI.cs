using System;
using UnityEngine;
using UnityModManagerNet;

namespace ArmsArmor
{
    public class UI {
        public static void OnSaveGui(UnityModManager.ModEntry modEntry) {
            Main.ModSettings.Save(modEntry);
        }

        public static bool OnToggle(UnityModManager.ModEntry modEntry, bool enabled) {
            return true;
        }

        public static void OnGui(UnityModManager.ModEntry modEntry) {
            try {
                RenderLabel("NOTE: Must restart game after making changes.");
            }
            catch (Exception e) {
                modEntry.Logger.Error($"Error rendering GUI: {e}");
            }
        }

        private static void RenderCheckbox(ref bool value, string label) {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button($"{(value ? "<color=green><b>✔</b></color>" : "<color=red><b>✖</b></color>")} {label}", GUILayout.ExpandWidth(false))) {
                value = !value;
            }

            GUILayout.EndHorizontal();
        }

        private static void RenderLabel(string label) {
            GUILayout.BeginHorizontal();
            GUILayout.Label(label);
            GUILayout.EndHorizontal();
        }
    }
}