using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Kingmaker.Utility;
using Newtonsoft.Json;

namespace ArmsArmor
{
    [AllowedOn(typeof(BlueprintUnitFact))]
    [AllowedOn(typeof(BlueprintUnit))]
    [AllowMultipleComponents]
    public class TwoHandFeature : OwnedGameLogicComponent<UnitDescriptor>, IHandleEntityComponent<UnitEntityData> {
        public override void OnTurnOn() {
            base.Owner.Ensure<UnitPartTwoHand>().TwoHand.Retain();
        }
        public override void OnTurnOff() {
            base.Owner.Ensure<UnitPartTwoHand>().TwoHand.Release();
        }
        public void OnEntityCreated(UnitEntityData entity) {
            entity.Descriptor.Ensure<UnitPartTwoHand>().TwoHand.Retain();
        }
        public void OnEntityRemoved(UnitEntityData entity) {
        }
    }

    public class UnitPartTwoHand : UnitPart {
        [JsonProperty]
        public readonly CountableFlag TwoHand = new CountableFlag();
    }
}