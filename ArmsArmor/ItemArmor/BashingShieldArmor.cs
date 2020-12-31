using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;

namespace ArmsArmor
{
    public class BashingShieldArmor {
        static public void Init() {
            var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintItemArmor>(ExistingGuids.BashingShieldArmor);
            var enchantments = Helpers.BlueprintItemArmorEnchantments(blueprint);
            Helpers.BlueprintItemArmorEnchantments(blueprint) =
                enchantments.Concat(new BlueprintArmorEnchantment[] { BashingEnchantment.GetBlueprint() }).ToArray();
        }
    }
}