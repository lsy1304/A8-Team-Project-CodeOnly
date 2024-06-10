# 프로젝트 이름
**Qube Story**

## 📖 목차
1. [프로젝트 소개](#프로젝트-소개)
2. [개발기간](#개발기간)
3. [와이어프레임](#와이어프레임)
4. [프로젝트 수행절차](#프로젝트-수행절차)
5. [구현기능](#구현기능)
6. [Trouble Shooting](#trouble-shooting)

## 👨‍🏫 프로젝트 소개
1. 단순하지만 다양한 기믹을 포함하는 파이퍼캐쥬얼 퍼즐 게임
2. 간단한 조작으로 다양한 기믹을 파훼하여 여러 스테이지로 구성된 퍼즐을 해결해 나가는 하이퍼캐쥬얼 게임

## ⏲️ 개발기간
- 2024.06.03(월) ~ 2024.06.10(월)

## 와이어프레임
- 초기 구상 로직
![기초 화면 및 로직 구상](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/fea27d12-7bfc-4178-8d81-22ae4697d539)
![기본로직](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/27bb38d5-ea44-49a3-a770-84d3510e35e8)

## 프로젝트 수행절차
|구분|기간|활동|
|:---|:---|:---|
사전기획|6/3|프로젝트 기획 및 UML설계
기본구현|6/4|플레이어 이동 및 테스트 스테이지 구현
기능구현|6/4 ~ 6/8|트랩, 레이저, 사운드, UI, 시스템 전반 구현 및 병합
QA|6/9 ~ 6/10|정상 작동 테스트 및 버그 수정

## 🕹구현기능
1.편의성 - 유저 편의를 위한 옵션 및 선택지  
- 스테이지 선택
     </br>![스타트시 스테이지 선택](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/437f4c54-9776-4241-913f-6bf3627fcc38)

- 오디오 설정 (우측상단 톱니바퀴)
    </br>![오디오설정](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/7090f19b-a473-4926-9de1-37629e6ea776)

- 일시정지 메뉴 (게임 플레이 중 esc버튼)
    </br>![게임도중 선택지](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/ae92c33b-344f-458c-b470-7180a0da56c7)

2.스위치 - 플레이어와의 상호작용 또는 턴의 종료 유무에 따라 작동 
  - Normal = 상호작용이 단 한번만 가능
  </br>![Normal](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/41193807-f0e6-4a5e-ac67-3d7885dff012)

  - Timer = 상호작용 후 일정 턴이 지난 뒤에 원상복귀
  </br>![Timer](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/24b194ed-d05e-4232-931b-0253b0c6a61e)

  - Toggle = 플레이어의 턴이 끝날때마다 기능
  </br>![Toggle](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/6e8c0be8-92e7-4aeb-99a0-bee21a75152d)

3.트랩 = 닿으면 스테이지 재시작
  - 가시함정 = 플레이어의 턴에 따라 작동
     </br>![Honeycam 2024-06-08 13-39-47](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/8ce01f7d-3f07-4c9a-826a-31b031e24854)

  - 레이저
    </br>![레이저 트랩](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/cb479980-155d-4d12-8383-772ecd7f8ded)

4.스테이지 구성  
    
  - 튜토리얼 스테이지 (+게임 플레이 설명 UI)  
     </br>![스테이지1 튜토리얼](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/e4b4a051-0f15-42bd-a715-11a20d5344fd)
  - 스테이지 3
     </br>![스테이지3](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/0fc3031f-a245-4cf2-b4cc-7495be6dabc8)
  - 스테이지 5
     </br>![스테이지5](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/0bbda3f2-e65f-42eb-9ed8-02dc5c698cc0)

## 🛠Trouble Shooting
1. 토글 스위치와 턴 카운트 간 연동 문제
 </br>🐛문제발생
  </br>-토글 스위치가 켜질 때 턴 카운트의 값에 반영이 되지 않는 오류
 </br>🔍원인
  </br>-플레이어와 스위치 오브젝트 간에 접촉이 불확실해서 발생
 </br>💡해결
  </br>-스위치의 콜라이더 크기를 키우고 스위치 오브젝트 양 옆에 추가로 콜라이더를 요철처럼 튀어나오게 설계하여 해결

![스위치 콜라이더 설정](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/980d8a84-43ea-41ea-a1e5-f5b3294cc7c0)
  
 2. 트랩 기능 구현
  </br>🐛문제발생
   </br>-애니메이션이 시간마다 일정하게 움직이는 방식으로 출력되며 의도치 않은 동작을 보임
  </br>🔍원인
   </br>-추가한 에셋에 동봉된 스크립트의 내용이 사용자의 의도와 달랐기에 발생했던 문제
  </br>💡해결
   </br>-코루틴 방식이 아닌 플레이어의 움직임과 연동되도록 스크립트를 수정

![재원님 트랩 트러블슈팅 (1)](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/4abbd27f-f461-4a1f-ba86-bca886b4faa0)
![재원님 트랩 트러블슈팅 (2)](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/386bc1a7-c59a-4b8a-85f8-c06b03a33d44)
![재원님 트랩 트러블슈팅 (3)](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/e59f2316-0d93-4419-9406-7b3fc4d8a620)

 3. 레이저 기능 구현
  </br>🐛문제발생
   </br>-레이저가 의도하지 않은 곳에 그려짐
  </br>🔍원인
   </br>-Line Renderer의 끝나는 지점에 잘못된 데이터가 적용되어 발생한 문제
  </br>💡해결
   </br>-Raycast의 대상인 hit의 좌표값이 아닌 거리를 적용하여 해결

![Laser](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/ee22696f-84d5-43f8-a9d6-7037231edc3e)

 4. 스테이지 생성
  </br>🐛문제발생
   </br>-이전 스테이지 파괴시 MissingReferenceException 에러가 발생
  </br>🔍원인
   </br>-GameManager.Instance.OnTurnEnd에 구독되어 있는 Toggle 메서드가 스테이지 파괴 이후에도 호출됨
  </br>💡해결
   </br>-OnDestroy가 호출되면 해당 스테이지의 Toggle 함수를 제거
   
![스테이지 파괴시 에러발생](https://github.com/welephant3/Spartan-Dungeon/assets/167234182/da628c0a-9f34-455b-9b5f-1123ced2bd5f)
