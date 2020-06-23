#if !PATCH21
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Shields;

namespace ArmsArmor
{
	public class BlueprintItemShieldPatch {
		[HarmonyLib.HarmonyPatch(typeof(BlueprintItemShield), "Type", HarmonyLib.MethodType.Getter)]
		private static class BlueprintItemShieldTypePatch {
			static MethodInfo methodToFind1;
			static MethodInfo methodToFind2;
			private static bool Prepare() {
				try {
					methodToFind1 = HarmonyLib.AccessTools.Property(typeof(BlueprintItemShield), nameof(BlueprintItemShield.ArmorComponent)).GetGetMethod();
					methodToFind2 = HarmonyLib.AccessTools.Property(typeof(BlueprintItemArmor), nameof(BlueprintItemArmor.Type)).GetGetMethod();
				}
				catch (Exception ex) {
					Main.ModEntry.Logger.Log($"Error Preparing: {ex.Message}");
					return false;
				}
				return true;
			}
			private static IEnumerable<HarmonyLib.CodeInstruction> Transpiler(IEnumerable<HarmonyLib.CodeInstruction> instructions, ILGenerator il) {
				Label type = il.DefineLabel();
				Label isinst = il.DefineLabel();
				int state = 0;
				foreach (var inst in instructions) {
					if (state == 0 && inst.opcode == OpCodes.Call && inst.operand as MethodInfo == methodToFind1) {
						yield return inst;
						yield return new HarmonyLib.CodeInstruction(OpCodes.Dup);
						yield return new HarmonyLib.CodeInstruction(OpCodes.Brtrue_S, type);
						yield return new HarmonyLib.CodeInstruction(OpCodes.Pop);
						yield return new HarmonyLib.CodeInstruction(OpCodes.Ldnull);
						yield return new HarmonyLib.CodeInstruction(OpCodes.Br_S, isinst);
						state = 1;
					} else if (state == 1 && inst.opcode == OpCodes.Callvirt && inst.operand as MethodInfo == methodToFind2) {
						inst.opcode = OpCodes.Call;
						inst.labels.Add(type);
						yield return inst;
						state = 2;
					} else if (state == 2 && inst.opcode == OpCodes.Isinst) {
						inst.labels.Add(isinst);
						yield return inst;
					} else {
						yield return inst;
					}
				}
			}
		}
	}
}
#endif