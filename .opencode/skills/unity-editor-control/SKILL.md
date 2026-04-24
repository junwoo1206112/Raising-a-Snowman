---
name: unity-editor-control
description: 유니티 에디터의 실행 상태를 제어하고 에셋 시스템을 동기화하는 스킬입니다.
---

# unity-editor-control

이 스킬은 `unity-cli` 명령어를 사용하여 유니티 에디터의 상태를 관리할 때 사용합니다.

## 주요 기능
- **Play/Stop/Pause:** 에디터의 플레이 모드를 제어합니다.
- **Refresh:** 프로젝트 에셋을 리프레시하여 변경 사항을 반영합니다.
- **Wait for Compile:** 스크립트 컴파일이 완료될 때까지 대기합니다.

## 지침
- 코드를 수정한 후에는 반드시 `unity-cli refresh`를 호출하여 에디터에 반영하세요.
- 런타임 테스트가 필요한 경우 `unity-cli play`를 사용하여 에디터를 실행하세요.
- 에디터가 응답하지 않거나 상태가 불분명할 경우 `unity-cli status`를 먼저 확인하세요.
