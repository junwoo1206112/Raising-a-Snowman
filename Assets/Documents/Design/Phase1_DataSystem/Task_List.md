# Phase 1: Task List & Test Plan

## 1. 리서치 (Research)
- [x] NPOI 설치 및 Unity 6 호환성 확인.
- [ ] ScriptableObject 구조와 엑셀 데이터 매핑 방식 검토.
- [ ] VContainer 또는 기본 DI 패턴 도입 검토.

## 2. 구현 계획 (Implementation Plan)
- **Task 1**: `IDataService` 및 기본 SO 클래스 설계.
- **Task 2**: NPOI 기반의 `ExcelManager` 클래스 구현 (에디터 전용).
- **Task 3**: 엑셀 템플릿 생성 기능 구현.
- **Task 4**: 엑셀 데이터 -> SO 변환 기능 구현.

## 3. 테스트 계획 (Test Plan)
- 빈 엑셀 파일이 올바른 경로에 생성되는지 확인.
- 임의의 데이터를 엑셀에 입력 후 Import 시 SO 데이터가 갱신되는지 확인.
- DI 컨테이너에서 `IDataService`가 정상적으로 주입되는지 확인.
