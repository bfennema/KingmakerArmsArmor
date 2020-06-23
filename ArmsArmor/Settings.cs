using UnityModManagerNet;

namespace ArmsArmor
{
    public class Settings : UnityModManager.ModSettings
    {
        public bool EquipWeaponWithoutProficiency = true;
        public bool EquipArmorWithoutProficiency = true;
        public bool EquipShieldWithoutProficiency = true;
        public bool FixShieldBashDamage = true;

        public override void Save(UnityModManager.ModEntry modEntry) {
            Save(this, modEntry);
        }
    }
}