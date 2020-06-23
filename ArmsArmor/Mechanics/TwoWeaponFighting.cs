using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;

namespace ArmsArmor
{
	public class TwoWeaponFightingBasicMechanics {
		static readonly string guid = "6948b379c0562714d9f6d58ccbfa8faa";
		static BlueprintFeature blueprint = null;
		static public BlueprintFeature GetBlueprint() {
			if (!blueprint) {
				blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(guid);
				Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString("e32ce256-78dc-4fd0-bf15-21f9ebdf9921");
			}
			return blueprint;
		}
		static public void Init() {
			GetBlueprint();
		}
	}
}