using Kingmaker.Blueprints;
using Kingmaker.Designers;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;

namespace ArmsArmor
{
    [AllowMultipleComponents]
    public class ShieldMasterLogic : GameLogicComponent, IInitiatorRulebookHandler<RuleCalculateDamage>, IInitiatorRulebookHandler<RuleCalculateAttackBonusWithoutTarget>, IInitiatorRulebookHandler<RuleCalculateWeaponStats> {
        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt) {
            if (!evt.Initiator.Body.SecondaryHand.HasShield || evt.Weapon == null || !evt.Weapon.IsShield) {
                return;
            }
            var armorEnhancementBonus = GameHelper.GetItemEnhancementBonus(evt.Initiator.Body.SecondaryHand.Shield.ArmorComponent);
            var weaponEnhancementBonus = GameHelper.GetItemEnhancementBonus(evt.Initiator.Body.SecondaryHand.Shield.WeaponComponent);
            var itemEnhancementBonus = armorEnhancementBonus - weaponEnhancementBonus;
            if (itemEnhancementBonus > 0) {
                evt.AddBonusDamage(itemEnhancementBonus);
            }
        }
        public void OnEventDidTrigger(RuleCalculateWeaponStats evt) { }

        public void OnEventAboutToTrigger(RuleCalculateDamage evt) {
            if (!evt.Initiator.Body.SecondaryHand.HasShield || evt.DamageBundle.Weapon == null || !evt.DamageBundle.Weapon.IsShield) {
                return;
            }
            var armorEnhancementBonus = GameHelper.GetItemEnhancementBonus(evt.Initiator.Body.SecondaryHand.Shield.ArmorComponent);
            var weaponEnhancementBonus = GameHelper.GetItemEnhancementBonus(evt.Initiator.Body.SecondaryHand.Shield.WeaponComponent);
            var itemEnhancementBonus = armorEnhancementBonus - weaponEnhancementBonus;
            PhysicalDamage physicalDamage = evt.DamageBundle.WeaponDamage as PhysicalDamage;
            if (physicalDamage != null && itemEnhancementBonus > 0) {
                physicalDamage.Enchantment += itemEnhancementBonus;
                physicalDamage.EnchantmentTotal += itemEnhancementBonus;
            }
        }
        public void OnEventDidTrigger(RuleCalculateDamage evt) { }

        public void OnEventAboutToTrigger(RuleCalculateAttackBonusWithoutTarget evt) {
            if (!evt.Initiator.Body.SecondaryHand.HasShield || evt.Weapon == null || !evt.Weapon.IsShield) {
                return;
            }
            var armorEnhancementBonus = GameHelper.GetItemEnhancementBonus(evt.Initiator.Body.SecondaryHand.Shield.ArmorComponent);
            var weaponEnhancementBonus = GameHelper.GetItemEnhancementBonus(evt.Initiator.Body.SecondaryHand.Shield.WeaponComponent);
            if (weaponEnhancementBonus == 0 && evt.Initiator.Body.SecondaryHand.Shield.WeaponComponent.Blueprint.IsMasterwork) {
                weaponEnhancementBonus = 1;
            }
            var num = armorEnhancementBonus - weaponEnhancementBonus;
            if (num > 0) {
                evt.AddBonus(num, base.Fact);
            }
        }
        public void OnEventDidTrigger(RuleCalculateAttackBonusWithoutTarget evt) { }
    }
}