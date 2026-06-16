using UnityEngine;

namespace Snowman.Core.Data
{
    public class DungeonConfigSO : DataConfigSO
    {
        public string dungeonType;
        public int dailyEntryLimit;
        public float monsterHpMultiplier;
        public float goldRewardMultiplier;
        public int unlockStage;
    }
}
