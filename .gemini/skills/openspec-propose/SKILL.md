---
name: openspec-propose
description: 새로운 변경 사항이나 기능을 제안하기 위해 제안서(Proposal)와 사양서(Specs)를 작성하는 스킬입니다.
---

# openspec-propose

이 스킬은 프로젝트에 새로운 기능 추가나 변경이 필요할 때 사용합니다.

## 지침
- 모든 변경 작업의 시작은 `/propose` 또는 이 스킬의 활성화로 시작됩니다.
- `openspec/changes/` 폴더 내에 고유한 ID를 가진 새 폴더를 생성합니다.
- 해당 폴더 내에 `proposal.md`, `specs/`, `tasks.md` 파일을 작성합니다.
- 사용자가 제안서를 승인하기 전까지는 실제 코드를 수정하지 마세요.

## 산출물 구조
- `openspec/changes/<ID>/proposal.md`: 변경의 목적과 범위를 설명합니다.
- `openspec/changes/<ID>/specs/`: 구체적인 기술 사양을 정의합니다.
- `openspec/changes/<ID>/tasks.md`: 구현을 위한 단계별 태스크 리스트입니다.
