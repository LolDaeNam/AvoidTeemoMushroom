# AvoidTeemoMushroom - 티모 버섯 키우기
![Teemo Main](/teemoMain.jpg)

우리들의 친구 가렌을 저 사악한 티모의 버섯으로부터 구하자

# 🖥️ 프로젝트 소개

스파르타코딩클럽 내일배움캠프 - 게임 개발 입문 팀프로젝트

Unity를 활용한 2D 플레시 게임

# 🕰️ 개발 기간

24.05.16 (목) - 24.05.23 (목)

# 🧑‍🤝‍🧑 팀원 구성

- 김정석 (팀장) - [Github](https://github.com/RryNoel)
- 김세일 - [Github](https://github.com/Seillluuuu)  
- 손영주 - [Github](https://github.com/JNUSYJ)  
- 최재훈 - [Github](https://github.com/chl1195)

# ⚙️ Development Environment

- Language : C#
- Engine : Unity 2022.3.12f1
- IDE : Visual Studio 2022
- Framework : .NET 6.0

# 📌 주요 기술

## Singleton

여러가지 필드와 자료들을 중복해서 생성하지 않고 여러 스크립트에서 공유하기위해 정적 객체를 활용.
씬이 전환될 때에도 유지되어야 할 정보를 가진 정적 객체는 DontDestroyOnLoad를 활용하여 객체가 파괴되는 것을 방지.

## PlayerPrefs

최고 점수를 저장하여 게임이 재시작해도 기록이 남아있게 구현할 필요성을 느낌. 간단한 데이터이기 때문에 PlayerPrefs 기능을 활용

## Couroutine

메서드 기능 중 일부를 일정 시간 뒤에 실행 시켜야 하는 로직을 구현하기 위해 사용

## Item

아이템이 게임 내에서 어떻게 동작하는 지를 정의하며 , 자식 클래스가 구체적인 아이템 효과를 구현할 수 있도록 추상 메서드를 제공

# ⚒️ 트러블 슈팅

## 사례 1

- 문제 : 아이템에 코루틴을 사용하여 일정 시간 뒤에 실행되는 기능을 구현하였는데, 아이템이 소모되어 파괴되면서 코루틴도 같이 소멸하는 현상
- 접근 : 새로운 객체를 잠깐 동안 만들어서 코루틴을 실행하는 동안 파괴되지 않는 대리 객체를 생성하면 어떨까?
- 해결 : 새로운 객체를 만들기보다, 기존에 있는 아이템 매니저 안에 기능을 구현하였다. 그래서 아이템 효과 발동 시 아이템이 아이템 매니저에게 기능을 실행하도록 전달해주는 방식으로 구현하였다. 그러면 아이템 매니저가 해당 기능을 대신 실행한다.

## 사례 2

- 문제 : 캐릭터의 애니메이션에서는 Rotation만 바꾸고 스크립트로 Sprite를 바꿀 때, 정상적으로 작동 되야할 Sprite가 바뀌지 않는 현상
- 접근 : 스크립트가 원인인지 유니티 내에서의 원인인지 파악한 후, 애니메이션이 바뀔 때 문제가 생긴 것을 확인
- 해결 : Rotation만 바꾸던 캐릭터 애니메이션에 스크립트로 바꾸려고 했던 Sprite를 애니메이션의 처음 부분과 끝 부분에 넣어서 문제를 해결했다.

## 사례 3

- 문제 : 다른 팀원의 브렌치를 Merge Commit push한 이후에 Mushroom.prefab 이 소실되어서 버섯이 나오지 않는 오류 발생
- 접근 : 깃헙에 오류 발생 원인을 찾는 중에 충돌로 인한 오류가 발생한 걸 확인
- 해결 : 에디터에서 해당 Prefab을 찾아 우클릭으로Show in Explorer 해서 Prefab 파일 안에서 충돌 난 코드 수정 후 저장해서 해결하였습니다.

## 사례 4

- 문제 : Push를 해야 하는 상황에서 오류로 인하여 Push가 되지 않음. 오류 메세지 내용은 로그인 관련 된 내용
- 접근 : 깃허브에서 새로운 브랜치를 생성해서, 그 안에서 작업 후 push를 하는 상황 
- 해결 : 로그인 관련 정보를 찾으며, 로그인에는 이상이 없음을 확인 후 결구 작업하던 브랜치를 삭제 후 새로운 브랜치로 작업 후 Push , 유추 하기로 팀원들과 나의 OS 환경 차이로 일어나지 않았을 까 예상



# 📌 링크

팀 노션 페이지

[Notion](https://teamsparta.notion.site/eb9943ab263a43079668e22369bfeb24)

팀 와이어프레임 페이지

[Excalidraw](https://excalidraw.com/#room=50c9f24654bab70ee50e,DQR3oT1VgOe2uUX9L8LWsg)

팀 UML 페이지

[UML](https://app.diagrams.net/#G1ZRVC0xSPDBX0nrgXBFCXF0qtUYv2eJPd#%7B%22pageId%22%3A%22C5RBs43oDa-KdzZeNtuy%22%7D)

