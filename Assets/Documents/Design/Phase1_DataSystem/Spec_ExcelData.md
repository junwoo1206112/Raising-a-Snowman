# Phase 1: Data System Specification

## 1. 개요
프로젝트 전반에서 사용할 밸런스 데이터를 엑셀에서 관리하고, 이를 유니티 `ScriptableObject`로 자동 변환하는 시스템을 구축한다.

## 2. 세부 사양
- **엑셀 양식**: 
  - `Stats`: 공격력, 체력, 성장 계수 등
  - `Items`: 이름, 등급, 능력치 배율
  - `Monsters`: 체력, 골드 보상, 등장 스테이지
- **데이터 컨버팅**:
  - `NPOI`를 사용하여 `.xlsx` 파일을 파싱.
  - 에디터 상단 메뉴 `Snowman > Data > Generate Template` 기능 제공.
  - `Snowman > Data > Import Excel` 기능 제공.
- **아키텍처 (DI)**:
  - `IDataService`: 데이터를 로드하고 제공하는 인터페이스.
  - `ExcelDataService`: 엑셀에서 데이터를 추출하여 SO로 변환 및 관리.
  - 직접적인 싱글톤 사용을 금지하며 모든 참조는 DI를 통해 주입받음.
