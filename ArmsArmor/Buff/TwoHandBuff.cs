using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using UnityEngine;

namespace ArmsArmor
{
    public class TwoHandBuff {
        static BlueprintBuff blueprint;

        static public BlueprintBuff GetBlueprint() {
            if (!blueprint) {
                blueprint = ScriptableObject.CreateInstance<BlueprintBuff>();
                Helpers.SetBlueprintBuffFlags(blueprint, 2 + 8);
                blueprint.IsClassFeature = true;
                blueprint.FxOnStart = new PrefabLink();
                blueprint.FxOnRemove = new PrefabLink();
                Helpers.BlueprintUnitFactDisplayName(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TwoHand);
                Helpers.BlueprintUnitFactDescription(blueprint) = LocalizedStringHelper.GetLocalizedString(StringGuids.TwoHandDescription);
                CopyFromBlueprint(blueprint, ExistingGuids.WeaponSpecialization);
                var component = ScriptableObject.CreateInstance<TwoHandFeature>();
                component.name = "$TwoHandFeature$839dee3d-caa1-4c1b-91ae-92a58e0237eb";
                blueprint.ComponentsArray = new BlueprintComponent[] { component };
                Helpers.BlueprintScriptableObjectAssetGuid(blueprint) = CustomGuids.TwoHandBuff;
                blueprint.name = "TwoHandBuff";
                ResourcesLibrary.LibraryObject.BlueprintsByAssetId?.Add(blueprint.AssetGuid, blueprint);
                ResourcesLibrary.LibraryObject.GetAllBlueprints()?.Add(blueprint);
            }
            return blueprint;
        }
        static public void Init() {
            GetBlueprint();
        }
        static public void CopyFromBlueprint(BlueprintBuff ability, string guid) {
            var copyFromBlueprint = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>(guid);
            Helpers.BlueprintUnitFactIcon(ability) = copyFromBlueprint.Icon;
        }
    }
}