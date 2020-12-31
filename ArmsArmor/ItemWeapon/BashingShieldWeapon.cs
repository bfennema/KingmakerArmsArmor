using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.RuleSystem;

namespace ArmsArmor
{
    public class BashingShieldWeapon {
        static public void Init() {
            var blueprint = ResourcesLibrary.TryGetBlueprint<BlueprintItemWeapon>(ExistingGuids.BashingShieldWeapon);
            Helpers.BlueprintItemWeaponEnchantments(blueprint) = Array.Empty<BlueprintWeaponEnchantment>();
            Helpers.BlueprintItemWeaponOverrideDamageDice(blueprint) = false;
            Helpers.BlueprintItemWeaponDamageDice(blueprint) = new DiceFormula(1, DiceType.D4);
        }
    }
}