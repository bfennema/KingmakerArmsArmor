using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.RuleSystem;

namespace ArmsArmor
{
	public class BashingShieldWeapon {
		static readonly string guid = "d7fb623f94b42304db03645c6fdef245";
		static public void Init() {
			var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintItemWeapon>(guid);
			Helpers.BlueprintItemWeaponEnchantments(blueprint) = Array.Empty<BlueprintWeaponEnchantment>();
			Helpers.BlueprintItemWeaponOverrideDamageDice(blueprint) = false;
			Helpers.BlueprintItemWeaponDamageDice(blueprint) = new DiceFormula(1, DiceType.D4);
		}
	}
}