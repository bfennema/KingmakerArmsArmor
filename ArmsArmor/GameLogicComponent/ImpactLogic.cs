using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;

namespace ArmsArmor
{
    [ComponentName("Weapon Size Change")]
    public class ImpactLogic : EquipmentEnchantmentLogic, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>, IInitiatorRulebookSubscriber {
        public readonly int SizeCategoryChange = 1;

        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt) {
            Main.ModEntry.Logger.Log($"Impact: evt.Weapon: {evt.Weapon}, base.Owner: {base.Owner}, evt.Initiator: {evt.Initiator}, change: {this.SizeCategoryChange}");
            if (evt.Weapon == base.Owner) {
                var diceFormula = (evt.WeaponDamageDiceOverride == null) ? evt.Weapon.Blueprint.BaseDamage : evt.WeaponDamageDiceOverride.Value;
                var baseMaxDamage = diceFormula.Rolls * diceFormula.Dice.Sides();
                var newDiceFormula = WeaponDamageScaleTable.Scale(evt.Weapon.Blueprint.BaseDamage, evt.Weapon.Blueprint.Size + SizeCategoryChange, evt.Weapon.Blueprint.Size, evt.Weapon.Blueprint);
                var newMaxDamage = newDiceFormula.Rolls * newDiceFormula.Dice.Sides();
                Main.ModEntry.Logger.Log($"newMaxDamage: {newMaxDamage}, baseMaxDamage: {baseMaxDamage}");
                if (newMaxDamage > baseMaxDamage) {
                    evt.WeaponDamageDiceOverride = newDiceFormula;
                }
            }
        }
        public void OnEventDidTrigger(RuleCalculateWeaponStats evt) {}
    }
}