﻿using System;
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
                RenderCheckbox(ref Main.ModSettings.EquipWeaponWithoutProficiency, "Equip weapons without weapon proficiency (-4 to hit).");
                RenderCheckbox(ref Main.ModSettings.EquipArmorWithoutProficiency, "Equip armor without armor proficiency (Penalty based on armor check penalty).");
                RenderCheckbox(ref Main.ModSettings.EquipShieldWithoutProficiency, "Equip shields without shield proficiency (Penalty based on armor check penalty).");
                RenderCheckbox(ref Main.ModSettings.FixShieldBashDamage, "Fix shield bash damage.");
                RenderCheckbox(ref Main.ModSettings.TempleSword, "Add Temple Sword.");
                RenderCheckbox(ref Main.ModSettings.OrcHornbow, "Add Orc Hornbow.");
                RenderCheckbox(ref Main.ModSettings.ShieldBash, "Add Shield Bash without Shield Bash Feat.");
                RenderCheckbox(ref Main.ModSettings.Disarm, "Add Disarm Combat Combat Maneuver without Improved Disarm Feat.");
                RenderCheckbox(ref Main.ModSettings.Sunder, "Add Sunder Combat Combat Maneuver without Improved Sunder Feat.");
                RenderCheckbox(ref Main.ModSettings.Trip, "Add Trip Combat Combat Maneuver without Improved Trip Feat.");
                RenderCheckbox(ref Main.ModSettings.TwoHand, "Add toggle for switching between one handing and two handing weapons.");
                RenderCheckbox(ref Main.ModSettings.UpsettingShieldStyle, "Add Upsetting Shield Style feat");

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