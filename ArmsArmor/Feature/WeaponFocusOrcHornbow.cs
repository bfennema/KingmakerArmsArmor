using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using UnityEngine;

namespace ArmsArmor
{
    public class WeaponFocusOrcHornbow {
        static BlueprintFeature blueprint = null;
        static private BlueprintFeature GetBlueprint() {
            if (!blueprint) {
                var component = ScriptableObject.CreateInstance<Kingmaker.Designers.Mechanics.Facts.WeaponFocus>();
                component.WeaponType = OrcHornbow.GetBlueprint();
                component.AttackBonus = 1;
                component.name = "$WeaponTypeAttackBonus$0150eba0-d6df-4062-88c4-6bce9ff709e0";

                blueprint = ScriptableObject.CreateInstance<BlueprintFeature>();
                blueprint.Groups = Array.Empty<FeatureGroup>();
                blueprint.Ranks = 1;
                blueprint.IsClassFeature = true;
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.WeaponFocusOrcHornbow);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.WeaponFocusOrcHornbowDescription);
                CopyFromBlueprint(blueprint, ExistingGuids.WeaponFocusLightCrossbow);
                blueprint.ComponentsArray = new BlueprintComponent[] { component };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.WeaponFocusOrcHornbow;
                blueprint.name = "WeaponFocusOrcHornbow";
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }

        static public void CopyFromBlueprint(BlueprintFeature feature, string guid) {
            var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(guid);
            Helpers.BlueprintUnitFactIcon(feature) = copyFromBlueprint.Icon;
        }

        static public void Init() {
            GetBlueprint();
        }
    }
}