using UnityEngine;

namespace Snowman.Core.Data
{
    public class SkillConfigSO : DataConfigSO
    {
        public float damageMultiplier;
        public float cooldown;
        public float duration;
        public int manaCost;
        public int baseUpgradeCost;
        public int maxLevel;
    }
}
