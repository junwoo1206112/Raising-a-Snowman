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

        public void LoadAllData()
        {
            _statsCache = Resources.LoadAll<StatsConfigSO>("Data/Stats").ToDictionary(s => s.id, s => s);
            _itemCache = Resources.LoadAll<ItemConfigSO>("Data/Items").ToDictionary(i => i.id, i => i);
            _monsterCache = Resources.LoadAll<MonsterConfigSO>("Data/Monsters").ToDictionary(m => m.id, m => m);

            Debug.Log($"[GameDataManager] Loaded {_statsCache.Count} stats, {_itemCache.Count} items, {_monsterCache.Count} monsters");
        }

        public T GetConfig<T>(string key) where T : class
        {
            if (typeof(T) == typeof(StatsConfigSO))
                return _statsCache.GetValueOrDefault(key) as T;
            if (typeof(T) == typeof(ItemConfigSO))
                return _itemCache.GetValueOrDefault(key) as T;
            if (typeof(T) == typeof(MonsterConfigSO))
                return _monsterCache.GetValueOrDefault(key) as T;

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

            return Enumerable.Empty<T>();
        }
    }
}
