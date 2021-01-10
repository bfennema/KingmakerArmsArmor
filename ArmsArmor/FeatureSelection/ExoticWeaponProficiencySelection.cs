using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;

namespace ArmsArmor
{
    public class ExoticWeaponProficiencySelection {
        static public void Init() {
            var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeatureSelection>(ExistingGuids.ExoticWeaponProficiencySelection);
            var features = blueprint.AllFeatures.ToList();
            if (Main.ModSettings.TempleSword == true) {
                features.Add(TempleSwordProficiency.GetBlueprint());
            }
            if (Main.ModSettings.OrcHornbow == true) {
                features.Add(OrcHornbowProficiency.GetBlueprint());
            }
            blueprint.AllFeatures = features.ToArray();

            foreach (var component in blueprint.ComponentsArray) {
                if (component is PrerequisiteNotProficient prerequisiteNotProficient) {
                    var weaponProficiencies = prerequisiteNotProficient.WeaponProficiencies.ToList();
                    if (Main.ModSettings.TempleSword == true) {
                        weaponProficiencies.Add(TempleSword.WeaponCategoryTempleSword);
                    }
                    if (Main.ModSettings.OrcHornbow == true) {
                        weaponProficiencies.Add(OrcHornbow.WeaponCategoryOrcHornbow);
                    }
                    prerequisiteNotProficient.WeaponProficiencies = weaponProficiencies.ToArray();
                }
            }
        }
    }
}