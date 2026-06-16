using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Snowman.Core.Data
{
    public class GameDataManager : IDataService
    {
        private Dictionary<string, StatsConfigSO> _statsCache;
        private Dictionary<string, ItemConfigSO> _itemCache;
        private Dictionary<string, MonsterConfigSO> _monsterCache;
        private Dictionary<string, SkillConfigSO> _skillCache;
        private Dictionary<string, PetConfigSO> _petCache;
        private Dictionary<string, RebirthConfigSO> _rebirthCache;
        private Dictionary<string, QuestConfigSO> _questCache;
        private Dictionary<string, AchievementConfigSO> _achievementCache;
        private Dictionary<string, DungeonConfigSO> _dungeonCache;
        private Dictionary<string, OfflineRewardConfigSO> _offlineRewardCache;

        public void LoadAllData()
        {
            _statsCache = Resources.LoadAll<StatsConfigSO>("Data/Stats").ToDictionary(s => s.id, s => s);
            _itemCache = Resources.LoadAll<ItemConfigSO>("Data/Items").ToDictionary(i => i.id, i => i);
            _monsterCache = Resources.LoadAll<MonsterConfigSO>("Data/Monsters").ToDictionary(m => m.id, m => m);
            _skillCache = Resources.LoadAll<SkillConfigSO>("Data/Skills").ToDictionary(s => s.id, s => s);
            _petCache = Resources.LoadAll<PetConfigSO>("Data/Pets").ToDictionary(p => p.id, p => p);
            _rebirthCache = Resources.LoadAll<RebirthConfigSO>("Data/Rebirth").ToDictionary(r => r.id, r => r);
            _questCache = Resources.LoadAll<QuestConfigSO>("Data/Quests").ToDictionary(q => q.id, q => q);
            _achievementCache = Resources.LoadAll<AchievementConfigSO>("Data/Achievements").ToDictionary(a => a.id, a => a);
            _dungeonCache = Resources.LoadAll<DungeonConfigSO>("Data/Dungeons").ToDictionary(d => d.id, d => d);
            _offlineRewardCache = Resources.LoadAll<OfflineRewardConfigSO>("Data/OfflineRewards").ToDictionary(o => o.id, o => o);

            Debug.Log($"[GameDataManager] Loaded {_statsCache.Count} stats, {_itemCache.Count} items, {_monsterCache.Count} monsters, " +
                $"{_skillCache.Count} skills, {_petCache.Count} pets, {_rebirthCache.Count} rebirths, " +
                $"{_questCache.Count} quests, {_achievementCache.Count} achievements, {_dungeonCache.Count} dungeons, {_offlineRewardCache.Count} offlineRewards");
        }

        public T GetConfig<T>(string key) where T : class
        {
            if (typeof(T) == typeof(StatsConfigSO))
                return _statsCache.GetValueOrDefault(key) as T;
            if (typeof(T) == typeof(ItemConfigSO))
                return _itemCache.GetValueOrDefault(key) as T;
            if (typeof(T) == typeof(MonsterConfigSO))
                return _monsterCache.GetValueOrDefault(key) as T;
            if (typeof(T) == typeof(SkillConfigSO))
                return _skillCache.GetValueOrDefault(key) as T;
            if (typeof(T) == typeof(PetConfigSO))
                return _petCache.GetValueOrDefault(key) as T;
            if (typeof(T) == typeof(RebirthConfigSO))
                return _rebirthCache.GetValueOrDefault(key) as T;
            if (typeof(T) == typeof(QuestConfigSO))
                return _questCache.GetValueOrDefault(key) as T;
            if (typeof(T) == typeof(AchievementConfigSO))
                return _achievementCache.GetValueOrDefault(key) as T;
            if (typeof(T) == typeof(DungeonConfigSO))
                return _dungeonCache.GetValueOrDefault(key) as T;
            if (typeof(T) == typeof(OfflineRewardConfigSO))
                return _offlineRewardCache.GetValueOrDefault(key) as T;

            Debug.LogWarning($"[GameDataManager] Unknown config type: {typeof(T).Name}");
            return null;
        }

        public IEnumerable<T> GetAllConfigs<T>() where T : class
        {
            if (typeof(T) == typeof(StatsConfigSO))
                return _statsCache.Values as IEnumerable<T>;
            if (typeof(T) == typeof(ItemConfigSO))
                return _itemCache.Values as IEnumerable<T>;
            if (typeof(T) == typeof(MonsterConfigSO))
                return _monsterCache.Values as IEnumerable<T>;
            if (typeof(T) == typeof(SkillConfigSO))
                return _skillCache.Values as IEnumerable<T>;
            if (typeof(T) == typeof(PetConfigSO))
                return _petCache.Values as IEnumerable<T>;
            if (typeof(T) == typeof(RebirthConfigSO))
                return _rebirthCache.Values as IEnumerable<T>;
            if (typeof(T) == typeof(QuestConfigSO))
                return _questCache.Values as IEnumerable<T>;
            if (typeof(T) == typeof(AchievementConfigSO))
                return _achievementCache.Values as IEnumerable<T>;
            if (typeof(T) == typeof(DungeonConfigSO))
                return _dungeonCache.Values as IEnumerable<T>;
            if (typeof(T) == typeof(OfflineRewardConfigSO))
                return _offlineRewardCache.Values as IEnumerable<T>;

            return Enumerable.Empty<T>();
        }
    }
}
