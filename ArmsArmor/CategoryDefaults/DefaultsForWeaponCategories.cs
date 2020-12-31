using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;

namespace ArmsArmor
{
    public class DefaultsForWeaponCategories {
        static public void Init() {
            var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintCategoryDefaults>(ExistingGuids.DefaultsForWeaponCategories);
            var entries = blueprint.Entries.ToList();
            entries.Add(new BlueprintCategoryDefaults.CategoryDefaultEntry
            {
                Key = TempleSword.WeaponCategoryTempleSword,
                DefaultWeapon = StandardTempleSword.GetBlueprint()
            });
            blueprint.Entries = entries.ToArray();
        }
    }
}
