---
name: unity-asset-safety
description: YAML 기반 유니티 에셋(.prefab, .unity)의 무결성을 보호하고 재직렬화하는 스킬입니다.
---

# unity-asset-safety

이 스킬은 에셋 파일을 텍스트(YAML) 형태로 직접 수정할 때 발생할 수 있는 손상을 방지하기 위해 사용합니다.

## 주요 기능
- **Reserialize:** 에셋 파일을 유니티의 최신 직렬화 형식으로 다시 저장합니다.
- **Integrity Check:** 에셋의 메타데이터와 파일 구조가 올바른지 확인합니다.

## 지침
- `.prefab`, `.unity`, `.asset` 파일을 직접 수정(replace 등)한 후에는 반드시 `unity-cli reserialize <파일경로>`를 실행하여 파일 손상을 방지하세요.
- 메타 파일(`.meta`)이 누락되거나 손상된 경우 즉시 복구 작업을 수행하세요.
