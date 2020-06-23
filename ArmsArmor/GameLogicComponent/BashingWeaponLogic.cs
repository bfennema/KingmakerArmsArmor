using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.Items;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;

namespace ArmsArmor
{
    [ComponentName("Shield Weapon Size Change")]
    public class BashingWeaponLogic : EquipmentEnchantmentLogic, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IInitiatorRulebookHandler<RuleCalculateAttackBonusWithoutTarget>, IRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateAttackBonusWithoutTarget>, IInitiatorRulebookSubscriber {
        public BlueprintFeature shieldMaster;
        public readonly int SizeCategoryChange = 2;
        private readonly int EnhancementBonus = 1;

        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt) {
            if (evt.Weapon == base.Owner) {
                var diceFormula = (evt.WeaponDamageDiceOverride == null) ? evt.Weapon.Blueprint.BaseDamage : evt.WeaponDamageDiceOverride.Value;
                var baseMaxDamage = diceFormula.Rolls * diceFormula.Dice.Sides();
                var newDiceFormula = WeaponDamageScaleTable.Scale(evt.Weapon.Blueprint.BaseDamage, evt.Weapon.Blueprint.Size + SizeCategoryChange, evt.Weapon.Blueprint.Size, evt.Weapon.Blueprint);
                var newMaxDamage = newDiceFormula.Rolls * newDiceFormula.Dice.Sides();
                if (newMaxDamage > baseMaxDamage) {
                    evt.WeaponDamageDiceOverride = newDiceFormula;
                }
                if (!IsMagic(evt.Weapon) && !evt.Initiator.Descriptor.Progression.Features.HasFact(shieldMaster)) {
                    evt.AddBonusDamage(this.EnhancementBonus);
                    evt.Enhancement += this.EnhancementBonus;
                }
            }
        }
        public void OnEventDidTrigger(RuleCalculateWeaponStats evt) {}

        public void OnEventAboutToTrigger(RuleCalculateAttackBonusWithoutTarget evt) {
            if (evt.Weapon == base.Owner && !IsMasterworkOrMagic(evt.Weapon) && !evt.Initiator.Descriptor.Progression.Features.HasFact(shieldMaster)) {
                evt.AddBonus(this.EnhancementBonus, base.Fact);
            }
        }
        public void OnEventDidTrigger(RuleCalculateAttackBonusWithoutTarget evt) {}

        static bool IsMasterworkOrMagic(ItemEntityWeapon weapon) {
            foreach (var blueprint in weapon.Enchantments) {
                foreach (var component in blueprint.Components) {
                    if (component is WeaponEnhancementBonus || component is WeaponMasterwork) {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool IsMagic(ItemEntityWeapon weapon) {
            foreach (var blueprint in weapon.Enchantments) {
                foreach (var component in blueprint.Components) {
                    if (component is WeaponEnhancementBonus) {
                        return true;
                    }
                }
            }
            return false;
        }
        [HarmonyLib.HarmonyPatch(typeof(RuleCalculateWeaponStats), "WeaponSize", HarmonyLib.MethodType.Getter)]
        private static class RuleCalculateWeaponStatsWeaponSizePatch {
            private static void Prefix(RuleCalculateWeaponStats __instance, ref int ___m_SizeShift, ref int __state, ref Size __result) {
                __state = ___m_SizeShift;
                foreach (var enchantment in __instance.Weapon.Enchantments) {
                    var component1 = enchantment.Blueprint.GetComponent<BashingWeaponLogic>();
                    if (component1 != null) {
                        if (component1.SizeCategoryChange > 0 && ___m_SizeShift > 0) {
                            ___m_SizeShift = 0;
                        }
                        break;
                    }
                    var component2 = enchantment.Blueprint.GetComponent<ImpactLogic>();
                    if (component2 != null) {
                        if (component2.SizeCategoryChange > 0 && ___m_SizeShift > 0) {
                            ___m_SizeShift = 0;
                        }
                        break;
                    }
                }
            }
            private static void Postfix(ref int ___m_SizeShift, int __state) {
                ___m_SizeShift = __state;
            }
        }
    }
}