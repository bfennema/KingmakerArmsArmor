using UnityModManagerNet;

namespace ArmsArmor
{
    public class Settings : UnityModManager.ModSettings
    {
        public bool EquipWeaponWithoutProficiency = true;
        public bool EquipArmorWithoutProficiency = true;
        public bool EquipShieldWithoutProficiency = true;
        public bool FixShieldBashDamage = true;
        public bool TempleSword = true;
        public bool OrcHornbow = true;
        public bool ShieldBash = true;
        public bool Disarm = true;
        public bool Trip = true;
        public bool Sunder = true;
        public bool TwoHand = true;
        public bool UpsettingShieldStyle = true;

        public override void Save(UnityModManager.ModEntry modEntry) {
            Save(this, modEntry);
        }
    }
}