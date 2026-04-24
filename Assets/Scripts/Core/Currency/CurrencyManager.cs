using System;
using UnityEngine;

namespace Snowman.Core.Currency
{
    public class CurrencyManager
    {
        public event Action<long> OnGoldChanged;

        private long _gold;
        public long Gold => _gold;

        public void AddGold(long amount)
        {
            if (amount <= 0) return;
            _gold += amount;
            OnGoldChanged?.Invoke(_gold);
            Debug.Log($"[CurrencyManager] Gold +{amount}. Total: {_gold}");
        }

        public bool TrySpendGold(long amount)
        {
            if (amount <= 0 || _gold < amount) return false;
            _gold -= amount;
            OnGoldChanged?.Invoke(_gold);
            Debug.Log($"[CurrencyManager] Gold -{amount}. Total: {_gold}");
            return true;
        }

        public void SetGold(long value)
        {
            _gold = Math.Max(0, value);
            OnGoldChanged?.Invoke(_gold);
        }

        public static string FormatGold(long value)
        {
            if (value >= 1_000_000_000)
                return $"{value / 1_000_000_000f:F1}B";
            if (value >= 1_000_000)
                return $"{value / 1_000_000f:F1}M";
            if (value >= 1_000)
                return $"{value / 1_000f:F1}K";
            return value.ToString();
        }
    }
}
