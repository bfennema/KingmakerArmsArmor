using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;

namespace ArmsArmor
{
	public class TwoWeaponFightingBasicMechanics {
		static BlueprintFeature blueprint = null;
		static public BlueprintFeature GetBlueprint() {
			if (!blueprint) {
				blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(ExistingGuids.TwoWeaponFightingBasicMechanics);
				Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TwoWeaponFighting);
			}
			return blueprint;
		}
		static public void Init() {
			GetBlueprint();
		}
	}
}