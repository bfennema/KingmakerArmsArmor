using System.Collections.Generic;
using Kingmaker.Items;
using Kingmaker.UI.Common;
using Kingmaker.UI.ServiceWindow.CharacterScreen;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;

namespace ArmsArmor
{
    class CharSAttackPatch {
        [HarmonyLib.HarmonyPatch(typeof(CharSAttack), "SetupAttackComponent")]
        private static class CharSAttackSetupAttackComponentPatch {
            private static void Prefix(CharSAttack __instance, List<UIUtilityItem.AttackData> attackData, bool isAdditionalWeapon, UnitDescriptor unit) {
                if (!isAdditionalWeapon && attackData.Count > 1 && unit.Body.SecondaryHand.MaybeShield != null) {
                    if (attackData[0].Item == unit.Body.SecondaryHand.MaybeWeapon) {
                        attackData[0].Item = unit.Body.SecondaryHand.MaybeShield;
                        attackData[0].hasShield = true;
                    } else if (attackData[1].Item == unit.Body.SecondaryHand.MaybeWeapon) {
                        attackData[1].Item = unit.Body.SecondaryHand.MaybeShield;
                        attackData[1].hasShield = true;
                    }
                }
            }

            private static void Postfix(CharSAttack __instance, List<UIUtilityItem.AttackData> attackData, bool isAdditionalWeapon, UnitDescriptor unit) {
                if (!isAdditionalWeapon && attackData.Count > 1) {
                    if (__instance.AttackUI[0].ItemSlot.Item == __instance.AttackUI[1].ItemSlot.Item) {
                        ItemEntityWeapon itemEntityWeapon = attackData[0].Item as ItemEntityWeapon;
                        ItemEntityShield itemEntityShield = attackData[0].Item as ItemEntityShield;
                        var unitPartTwoHand = unit.Get<UnitPartTwoHand>();
                        var unitPartMagus = unit.Get<UnitPartMagus>();
                        if (itemEntityWeapon != null && !ItemEntityWeaponPatch.IsTwoHanded(itemEntityWeapon, unit)
                            && (!(unitPartTwoHand && unitPartTwoHand.TwoHand) || (unitPartMagus && unitPartMagus.SpellCombat.Active))) {
                            __instance.AttackUI[1].SetIcon(null, 0f);
                        } else if (itemEntityShield != null && (itemEntityShield.WeaponComponent.Blueprint.IsLight || !(unitPartTwoHand && unitPartTwoHand.TwoHand))) {
                            __instance.AttackUI[1].SetIcon(null, 0f);
                        } else {
                            __instance.AttackUI[1].SetIcon(attackData[0].Icon, 0.3f);
                        }
                    }
                }
            }
        }
    }
}