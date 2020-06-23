using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;

namespace ArmsArmor
{
	public class BashingShieldArmor {
		static readonly string guid = "5ba44cd58f731144a9f390c2c099abc6";
		static public void Init() {
			var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintItemArmor>(guid);
			var enchantments = Helpers.BlueprintItemArmorEnchantments(blueprint);
			Helpers.BlueprintItemArmorEnchantments(blueprint) =
				enchantments.Concat(new BlueprintArmorEnchantment[] { BashingEnchantment.GetBlueprint() }).ToArray();
		}
	}
}