using UnityEngine;

namespace Snowman.Core.Data
{
    public class QuestConfigSO : DataConfigSO
    {
        public string questType;
        public string requirementType;
        public int requirementValue;
        public int rewardGold;
        public string rewardItemId;
    }
}
