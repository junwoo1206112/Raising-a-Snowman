using UnityEngine;

namespace Snowman.Core.Data
{
    public class PetConfigSO : DataConfigSO
    {
        public int tier;
        public float attackDamage;
        public float attackSpeed;
        public string buffType;
        public float buffValue;
        public int unlockStage;
    }
}
