# 프로젝트 개발 진행 상황 (Raising a Snowman)

마지막 업데이트: 2026-04-27

## 1. 개발 환경 및 설정 (Setup Guide)
다른 PC에서 이 프로젝트를 열 때 다음 사항을 확인하십시오.

- **Unity 버전**: 6000.3.11f1
- **외부 라이브러리 (NPOI)**:
  - 현재 `Assets/Plugins/NPOI` 폴더에 DLL 파일들이 직접 포함되어 있습니다.
  - 별도의 패키지 매니저 설정 없이 유니티를 열면 즉시 컴파일됩니다.
- **핵심 지침**: 프로젝트 루트의 `AGENT.md`와 `openspec/` 폴더를 참조하여 개발 흐름을 파악하십시오.

## 2. 현재 마일스톤 상태

### Phase 1: 데이터 시스템 (완료 100%)
- [x] NPOI 라이브러리 설치 및 환경 구성
- [x] 데이터 인터페이스 및 기본 SO 구조 설계 (`IDataService`, `DataConfigSO`, `StatsConfigSO`, `ItemConfigSO`, `MonsterConfigSO`)
- [x] 엑셀 템플릿 자동 생성 기능 (`Snowman > Data > Generate Blank Excel Template`)
- [x] 엑셀 데이터 -> ScriptableObject 변환 로직 (`Snowman > Data > Import All from Excel`)
- [x] DI(의존성 주입) 컨테이너 설정 (정적 Dictionary 기반 `Snowman.Core.DI`)
- [x] `GameDataManager` (IDataService 구현체, Resources.LoadAll 기반 SO 로드)
- [x] `CurrencyManager` (골드 관리, K/M/B 단위 포맷팅)
- [x] 확장 데이터 타입 추가 (Skill, Pet, Rebirth, Quest, Achievement, Dungeon, OfflineReward)
- [x] 엑셀 밸런스 데이터 초기값 채우기 (`Snowman > Data > Populate Excel with Game Data`)

### Phase 2: 전투 루프 (대기 - 다음 단계)
- [ ] PlayerController (자동 이동, 애니메이션 제어)
- [ ] EnemyController & Spawner (오브젝트 풀링 기반)
- [ ] StageManager (50마리 카운트, 보스전 전환)
- [ ] BossTimer (30초 제한)

### Phase 3: 성장 & UI (대기)
- [ ] StatManager (공격력, 체력 등 지수 연산)
- [ ] StatUpgradeUI (골드 강화 버튼)
- [ ] Inventory & 합성 로직 (4:1 티어 합성)

### Phase 4: 비주얼 & 폴리싱 (대기)
- [ ] 눈사람 외형 변화 시스템
- [ ] 스킬 이펙트 (눈보라, 고드름 등)

## 3. 기술적 결정 사항 (Key Decisions)
- **DI 패턴**: 정적 Dictionary 기반 DI 컨테이너 사용 (`Assets/Scripts/Core/DI.cs`). 모든 매니저는 인터페이스를 통해 참조하며, 싱글톤 사용을 지양합니다.
- **데이터 관리**: 엑셀을 마스터 데이터로 사용하며, 빌드 시에는 ScriptableObject를 참조합니다.
- **데이터 파이프라인**: NPOI → Excel(.xlsx) → `ExcelDataImporter` → ScriptableObject(.asset) → `GameDataManager`(Resources.LoadAll) → 런타임
- **워크플로우**: 모든 변경은 OpenSpec의 `Propose -> Apply -> Archive` 절차를 따릅니다.

## 4. 다음 작업 (Next Action)
1. **엑셀 데이터 채우기**: `Snowman > Data > Populate Excel with Game Data` 메뉴로 실제 밸런스 데이터 입력
2. **데이터 Import 검증**: `Snowman > Data > Import All from Excel` 로 SO 생성 확인
3. **Phase 2 착수**: `PlayerController`, `EnemyController`, `StageManager` 구현
