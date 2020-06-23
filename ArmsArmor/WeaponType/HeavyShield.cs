using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.RuleSystem;

namespace ArmsArmor
{
	public class HeavyShield {
		static readonly string guid = "be9b6408e6101cb4997a8996484baf19";
		static public void Init() {
			if (Main.ModSettings.FixShieldBashDamage) {
				var lightShield = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>(guid);
				Helpers.BlueprintWeaponTypeBaseDamage(lightShield) = new DiceFormula(1, DiceType.D4);
			}
		}
	}
}