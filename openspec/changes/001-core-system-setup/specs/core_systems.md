# Specification: Core Systems

## 1. Battle System
- **Monster Loop**: 50 Normal Mobs -> 1 Boss.
- **Boss Timer**: 30 seconds limit. If fail, return to the current stage for farming.
- **Auto Movement**: Player moves right and attacks automatically within range.

## 2. Growth & Data System
- **Stat Formula**: 
    - `Atk = BaseAtk + (Level * GrowthValue)`
    - `UpgradeCost = BaseCost * (1.1 ^ Level)`
- **Currency Format**: 
    - `1,000`단위마다 접미사 추가 (K, M, B, T, Aa, Bb...).
    - 내부적으로 `double` 또는 `BigInteger` (지수 분리형 클래스) 사용.

## 3. Inventory System
- **Tiers**: Bronze < Silver < Gold < Platinum < Diamond < Mythic.
- **Synthesis**: 4 items of the same tier -> 1 item of the next tier.
