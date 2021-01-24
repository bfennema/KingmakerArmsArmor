using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items.Shields;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.ServiceWindow;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using Kingmaker.Visual.CharacterSystem;
using UnityEngine;
using UnityEngine.UI;

namespace ArmsArmor
{
    static class Helpers
    {
        // BlueprintScriptableObject
        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintScriptableObject, string> BlueprintScriptableObjectAssetGuid =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintScriptableObject, string>("m_AssetGuid");


        // BlueprintUnitFact
        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintUnitFact, LocalizedString> BlueprintUnitFactDisplayName =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintUnitFact, LocalizedString>("m_DisplayName");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintUnitFact, LocalizedString> BlueprintUnitFactDescription =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintUnitFact, LocalizedString>("m_Description");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintUnitFact, Sprite> BlueprintUnitFactIcon =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintUnitFact, Sprite>("m_Icon");


        // LocalizedString
        static public readonly HarmonyLib.AccessTools.FieldRef<LocalizedString, string> LocalizedStringKey =
            HarmonyLib.AccessTools.FieldRefAccess<LocalizedString, string>("m_Key");


        // BlueprintWeaponType
        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, LocalizedString> BlueprintWeaponTypeTypeNameText =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, LocalizedString>("m_TypeNameText");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, LocalizedString> BlueprintWeaponTypeDefaultNameText =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, LocalizedString>("m_DefaultNameText");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, LocalizedString> BlueprintWeaponTypeDescriptionText =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, LocalizedString>("m_DescriptionText");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, LocalizedString> BlueprintWeaponTypeMasterworkDescriptionText =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, LocalizedString>("m_MasterworkDescriptionText");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, LocalizedString> BlueprintWeaponTypeMagicDescriptionText =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, LocalizedString>("m_MagicDescriptionText");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, Sprite> BlueprintWeaponTypeIcon =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, Sprite>("m_Icon");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, WeaponVisualParameters> BlueprintWeaponTypeVisualParameters =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, WeaponVisualParameters>("m_VisualParameters");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, AttackType> BlueprintWeaponTypeAttackType =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, AttackType>("m_AttackType");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, Feet> BlueprintWeaponTypeAttackRange =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, Feet>("m_AttackRange");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, DiceFormula> BlueprintWeaponTypeBaseDamage =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, DiceFormula>("m_BaseDamage");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, DamageTypeDescription> BlueprintWeaponTypeDamageType =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, DamageTypeDescription>("m_DamageType");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, int> BlueprintWeaponTypeCriticalRollEdge =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, int>("m_CriticalRollEdge");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, DamageCriticalModifierType> BlueprintWeaponTypeCriticalModifier =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, DamageCriticalModifierType>("m_CriticalModifier");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, WeaponFighterGroup> BlueprintWeaponTypeFighterGroup =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, WeaponFighterGroup>("m_FighterGroup");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, float> BlueprintWeaponTypeWeight =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, float>("m_Weight");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, bool> BlueprintWeaponTypeIsTwoHanded =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, bool>("m_IsTwoHanded");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, bool> BlueprintWeaponTypeIsLight =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, bool>("m_IsLight");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, bool> BlueprintWeaponTypeIsMonk =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, bool>("m_IsMonk");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintWeaponType, BlueprintWeaponEnchantment[]> BlueprintWeaponTypeEnchantments =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintWeaponType, BlueprintWeaponEnchantment[]>("m_Enchantments");


        // BlueprintItemWeapon
        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemWeapon, BlueprintWeaponType> BlueprintItemWeaponType =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemWeapon, BlueprintWeaponType>("m_Type");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemWeapon, Size> BlueprintItemWeaponSize =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemWeapon, Size>("m_Size");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemWeapon, BlueprintWeaponEnchantment[]> BlueprintItemWeaponEnchantments =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemWeapon, BlueprintWeaponEnchantment[]>("m_Enchantments");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemWeapon, DamageTypeDescription> BlueprintItemWeaponDamageType =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemWeapon, DamageTypeDescription>("m_DamageType");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemWeapon, bool> BlueprintItemWeaponOverrideDamageDice =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemWeapon, bool>("m_OverrideDamageDice");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemWeapon, DiceFormula> BlueprintItemWeaponDamageDice =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemWeapon, DiceFormula>("m_DamageDice");


        // BlueprintItemEquipmentHand
        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemEquipmentHand, WeaponVisualParameters> BlueprintItemEquipmentHandVisualParameters =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemEquipmentHand, WeaponVisualParameters>("m_VisualParameters");


        // BlueprintItemArmor
        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemArmor, BlueprintArmorType> BlueprintItemArmorType =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemArmor, BlueprintArmorType>("m_Type");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemArmor, Size> BlueprintItemArmorSize =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemArmor, Size>("m_Size");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemArmor, BlueprintEquipmentEnchantment[]> BlueprintItemArmorEnchantments =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemArmor, BlueprintEquipmentEnchantment[]>("m_Enchantments");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemArmor, ArmorVisualParameters> BlueprintItemArmorVisualParameters =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemArmor, ArmorVisualParameters>("m_VisualParameters");


        // BlueprintItemShield
        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemShield, BlueprintItemWeapon> BlueprintItemShieldWeaponComponent =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemShield, BlueprintItemWeapon>("m_WeaponComponent");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemShield, BlueprintItemArmor> BlueprintItemShieldArmorComponent =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemShield, BlueprintItemArmor>("m_ArmorComponent");


        // BlueprintItem
        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItem, Sprite> BlueprintItemIcon =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItem, Sprite>("m_Icon");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItem, int> BlueprintItemCost =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItem, int>("m_Cost");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItem, float> BlueprintItemWeight =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItem, float>("m_Weight");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItem, string> BlueprintItemInventoryPutSound =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItem, string>("m_InventoryPutSound");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItem, string> BlueprintItemInventoryTakeSound =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItem, string>("m_InventoryTakeSound");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItem, LocalizedString> BlueprintItemDisplayNameText =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItem, LocalizedString>("m_DisplayNameText");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItem, LocalizedString> BlueprintItemDescriptionText =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItem, LocalizedString>("m_DescriptionText");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItem, LocalizedString> BlueprintItemFlavorText =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItem, LocalizedString>("m_FlavorText");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItem, LocalizedString> BlueprintItemNonIdentifiedNameText =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItem, LocalizedString>("m_NonIdentifiedNameText");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItem, LocalizedString> BlueprintItemNonIdentifiedDescriptionText =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItem, LocalizedString>("m_NonIdentifiedDescriptionText");


        // BlueprintItemEquipmentSimple
        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemEquipmentSimple, BlueprintEquipmentEnchantment[]> BlueprintItemEquipmentSimpleEnchantments =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemEquipmentSimple, BlueprintEquipmentEnchantment[]>("m_Enchantments");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemEquipmentSimple, string> BlueprintItemEquipmentSimpleInventoryEquipSound =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemEquipmentSimple, string>("m_InventoryEquipSound");


        // BlueprintItemEquipment
        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemEquipment, KingmakerEquipmentEntity> BlueprintItemEquipmentEquipmentEntity =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemEquipment, KingmakerEquipmentEntity>("m_EquipmentEntity");


        // BlueprintItemEnchantment
        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemEnchantment, LocalizedString> BlueprintItemEnchantmentEnchantName =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemEnchantment, LocalizedString>("m_EnchantName");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemEnchantment, LocalizedString> BlueprintItemEnchantmentDescription =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemEnchantment, LocalizedString>("m_Description");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemEnchantment, LocalizedString> BlueprintItemEnchantmentPrefix =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemEnchantment, LocalizedString>("m_Prefix");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemEnchantment, LocalizedString> BlueprintItemEnchantmentSuffix =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemEnchantment, LocalizedString>("m_Suffix");

        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintItemEnchantment, int> BlueprintItemEnchantmentIdentifyDC =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintItemEnchantment, int>("m_IdentifyDC");


        // BlueprintBuff
        static public void SetBlueprintBuffFlags(BlueprintBuff buff, int flags) {
            HarmonyLib.AccessTools.Field(typeof(BlueprintBuff), "m_Flags").SetValue(buff, flags);
        }


        // BlueprintActivatableAbility
        static public readonly HarmonyLib.AccessTools.FieldRef<BlueprintActivatableAbility, UnitCommand.CommandType> BlueprintActivatableAbilityActivateWithUnitCommand =
            HarmonyLib.AccessTools.FieldRefAccess<BlueprintActivatableAbility, UnitCommand.CommandType>("m_ActivateWithUnitCommand");


        // EquipSlot
        static public readonly HarmonyLib.AccessTools.FieldRef<EquipSlot, Image> EquipSlotTypeIcon =
            HarmonyLib.AccessTools.FieldRefAccess<EquipSlot, Image>("m_TypeIcon");

        // UnitDescriptor
        static public readonly HarmonyLib.AccessTools.FieldRef<UnitDescriptor, UnitPartsManager> UnitDescriptorParts =
            HarmonyLib.AccessTools.FieldRefAccess<UnitDescriptor, UnitPartsManager>("m_Parts");


        // UnitPartsManager
        static public readonly HarmonyLib.AccessTools.FieldRef<UnitPartsManager, Dictionary<Type, UnitPart>> UnitPartsManagerParts =
            HarmonyLib.AccessTools.FieldRefAccess<UnitPartsManager, Dictionary<Type, UnitPart>>("m_Parts");


        // UnitProficiency
        static public readonly HarmonyLib.AccessTools.FieldRef<UnitProficiency, MultiSet<WeaponCategory>> UnitProficiencyWeaponProficiencies =
            HarmonyLib.AccessTools.FieldRefAccess<UnitProficiency, MultiSet<WeaponCategory>>("m_WeaponProficiencies");

        static public readonly HarmonyLib.AccessTools.FieldRef<MultiSet<WeaponCategory>, Dictionary<WeaponCategory, int>> MultiSetWeaponCategoryData =
            HarmonyLib.AccessTools.FieldRefAccess<MultiSet<WeaponCategory>, Dictionary<WeaponCategory, int>>("m_Data");


        // LootItemsPackFixed
        static public readonly HarmonyLib.AccessTools.FieldRef<LootItemsPackFixed, LootItem> LootItemsPackFixedItem =
            HarmonyLib.AccessTools.FieldRefAccess<LootItemsPackFixed, LootItem>("m_Item");

        static public readonly HarmonyLib.AccessTools.FieldRef<LootItemsPackFixed, int> LootItemsPackFixedCount =
            HarmonyLib.AccessTools.FieldRefAccess<LootItemsPackFixed, int>("m_Count");


        // LootItem
        static public readonly HarmonyLib.AccessTools.FieldRef<LootItem, BlueprintItem> LootItemItem =
            HarmonyLib.AccessTools.FieldRefAccess<LootItem, BlueprintItem>("m_Item");


        // AddParametrizedFeatures
        static private readonly Type m_AddParametrizedFeaturesData = HarmonyLib.AccessTools.Inner(typeof(AddParametrizedFeatures), "Data");

        public class AddParametrizedFeaturesData
        {
            public BlueprintParametrizedFeature feature;
            public WeaponCategory category;
        };

        static public void AddParametrizedFeaturesFeatures(AddParametrizedFeatures feature, AddParametrizedFeaturesData[] array) {
            var features = Array.CreateInstance(m_AddParametrizedFeaturesData, array.Length);
            for (int i=0; i<array.Length; i++) {
                var data = Activator.CreateInstance(m_AddParametrizedFeaturesData);
                HarmonyLib.AccessTools.Field(data.GetType(), "Feature").SetValue(data, array[i].feature);
                HarmonyLib.AccessTools.Field(data.GetType(), "ParamWeaponCategory").SetValue(data, array[i].category);
                features.SetValue(data, i);
            }
            HarmonyLib.AccessTools.Field(feature.GetType(), "m_Features").SetValue(feature, features);
        }


        // Weapons that can be used two handed with martial weapon proficiency, or one handed with exotic
        static public bool IsExoticTwoHandedMartialWeapon(BlueprintItemWeapon weapon) {
            return weapon.Category == WeaponCategory.BastardSword
                || weapon.Category == WeaponCategory.DwarvenWaraxe
                || weapon.Category == WeaponCategory.Estoc;
        }
    }
}