# Raising a snowman - Project Overview

This is a Unity 2D game project titled "Raising a snowman". The project is currently in its early setup phase, using Unity 6 (version 6000.3.11f1).

## Technologies & Frameworks

- **Unity Engine:** Version 6000.3.11f1
- **Render Pipeline:** Universal Render Pipeline (URP) with 2D Renderer.
- **Input System:** New Unity Input System (`com.unity.inputsystem`).
- **Visual Scripting:** Integrated support for Visual Scripting (`com.unity.visualscripting`).
- **2D Specialized Packages:**
    - 2D Animation
    - Aseprite Importer
    - PSD Importer
    - Tilemap & Tilemap Extras
    - SpriteShape

## Project Structure

- `Assets/`: Contains all game assets.
    - `Scenes/`: Holds Unity scenes (currently contains `SampleScene`).
    - `Settings/`: Contains URP and other global settings.
    - `InputSystem_Actions.inputactions`: Configuration for the new Input System.
- `Packages/`: Project dependencies managed via Unity Package Manager.
- `ProjectSettings/`: Global project configurations (Player settings, Graphics, etc.).

## 전용 스킬 (Custom Skills)

이 프로젝트는 효율적인 개발과 사양 관리를 위해 두 가지 카테고리의 스킬을 보유하고 있습니다.

### 1. OpenSpec (사양 기반 개발) 스킬
프로젝트의 모든 변경 사항은 **OpenSpec**의 SDD(Spec-Driven Development) 워크플로우를 따릅니다.
- **`openspec-explore`**: 프로젝트 구조 및 기존 사양 탐색.
- **`openspec-propose`**: 새로운 변경 사항 제안 (Proposal & Specs 작성).
- **`openspec-apply`**: 승인된 사양에 따라 코드 구현.
- **`openspec-archive`**: 완료된 작업을 보관하고 메인 사양에 통합.

### 2. Unity 엔진 전용 스킬
유니티 에디터와 직접 상호작용할 때 사용합니다.
- **`unity-editor-control`**: 에디터 상태(Play/Stop) 제어 및 에셋 리프레시.
- **`unity-csharp-runner`**: 에디터 내 C# 코드 즉석 실행 (`exec`).
- **`unity-asset-safety`**: YAML 에셋 수정 후 재직렬화 및 무결성 검사.

## 개발 가이드라인 (Mandates)

1.  **사양 우선 개발 (Spec-First)**: 모든 코드 수정이나 기능 추가는 `openspec-propose` 스킬을 통한 사양 정의 및 사용자 승인 후 진행합니다.
2.  **스킬 활성화**: 작업의 성격에 맞는 스킬을 `activate_skill`로 활성화하고, 해당 스킬의 전문가 지침을 엄격히 준수하세요.
3.  **무결성 유지**:
    - `.prefab`, `.unity` 등 YAML 에셋 수정 후에는 반드시 `unity-asset-safety`로 `reserialize`를 수행합니다.
    - 구현 완료 후에는 `openspec-archive`를 통해 프로젝트의 "진실의 원천(Source of Truth)"을 업데이트합니다.

## Development Workflow

### 사양 기반 개발 사이클 (OpenSpec)

1.  **Explore**: `openspec-explore`로 현재 시스템 파악.
2.  **Propose**: `openspec-propose`로 `proposal.md`, `specs/`, `tasks.md` 작성 및 승인 대기.
3.  **Apply**: 승인 후 `openspec-apply`를 활성화하여 구현 및 테스트.
4.  **Archive**: 구현 완료 및 검증 후 `openspec-archive`로 정리.

### Building and Running

1.  **Open in Unity:** Use Unity Hub to open the project with Unity version `6000.3.11f1`.
2.  **Play Mode:** Press the Play button in the Unity Editor to test the game.
3.  **Build:** Navigate to `File > Build Settings` to configure and build for target platforms (currently default settings target PC, Mac & Linux Standalone).

### Coding Standards

- The project is set up to use C# but currently relies on Visual Scripting.
- If C# scripts are added, they should be placed within an `Assets/Scripts` folder (to be created) following standard Unity naming conventions (PascalCase for classes and files).

### Testing

- Unity Test Framework is included (`com.unity.test-framework`). Tests should be placed in `Assets/Tests` (to be created).

## Usage

This directory contains the complete source and assets for the Unity project. To collaborate or develop:
1. Clone the repository.
2. Open with the specified Unity version.
3. Assets and logic are primarily managed through the Unity Editor.
