using UnityEngine;

namespace Snowman.Core.Data
{
    public class AchievementConfigSO : DataConfigSO
    {
        public string requirementType;
        public int requirementValue;
        public int rewardGold;
        public float permanentStatBonus;
    }
}
