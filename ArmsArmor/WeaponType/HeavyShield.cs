using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.RuleSystem;

namespace ArmsArmor
{
	public class HeavyShield {
		static public void Init() {
			if (Main.ModSettings.FixShieldBashDamage) {
				var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>(ExistingGuids.WeaponHeavyShield);
				Helpers.BlueprintWeaponTypeBaseDamage(blueprint) = new DiceFormula(1, DiceType.D4);
			}
		}
	}
}