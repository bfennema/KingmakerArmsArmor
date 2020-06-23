using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.RuleSystem;

namespace ArmsArmor
{
	public class LightShield {
		static readonly string guid = "1fd965e522502fe479fdd423cca07684";
		static public void Init() {
			if (Main.ModSettings.FixShieldBashDamage) {
				var lightShield = ResourcesLibrary.TryGetBlueprint<BlueprintWeaponType>(guid);
				Helpers.BlueprintWeaponTypeBaseDamage(lightShield) = new DiceFormula(1, DiceType.D3);
			}
		}
	}
}