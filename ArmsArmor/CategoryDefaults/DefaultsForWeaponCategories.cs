using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;

namespace ArmsArmor
{
    public class DefaultsForWeaponCategories {
        static public void Init() {
            var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintCategoryDefaults>(ExistingGuids.DefaultsForWeaponCategories);
            var entries = blueprint.Entries.ToList();
            if (Main.ModSettings.TempleSword == true) {
                entries.Add(new BlueprintCategoryDefaults.CategoryDefaultEntry
                {
                    Key = TempleSword.WeaponCategoryTempleSword,
                    DefaultWeapon = StandardTempleSword.GetBlueprint(0)
                });
            }
            if (Main.ModSettings.OrcHornbow == true) {
                entries.Add(new BlueprintCategoryDefaults.CategoryDefaultEntry
                {
                    Key = OrcHornbow.WeaponCategoryOrcHornbow,
                    DefaultWeapon = StandardOrcHornbow.GetBlueprint(0)
                });
            }
            blueprint.Entries = entries.ToArray();
        }
    }
}
