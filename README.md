# Unlocking System with Gaze Tracking
# 시선 추적을 이용한 잠금 해제 시스템
[요약](#요약)  
[개발 기간](#개발-기간)  
[개발자](#개발자)  
[하드웨어 제작](#하드웨어-제작)  
[사용 프로그램](#사용-프로그램)
[사용 기술](#사용-기술)

---
### 요약
- 카메라를 이용하여 실시간 동공 영상 촬영
- 모니터와 사용자 눈의 움직임간 동기화를 위한 캘리브레이션 과정 수행

- 사용자의 눈의 움직임에 따라 유니티에서 캐릭터의 눈이 움직임

- 아바타의 눈 움직임에 따라 비밀번호가 입력됨
---
### 개발 기간

- 2019/08/19 ~ 2019/09/11
---
### 개발자

- [김소현 (sohyeon98720)](https://github.com/sohyeon98720), 박현지, [이혜인(hyeinlee725)](https://github.com/hyeinlee725), [정민지(minji-o-j)](https://github.com/minji-o-j) 


--- 
### 하드웨어 제작
#### - 준비물
![image](https://user-images.githubusercontent.com/45448731/75803052-1aec8180-5dc1-11ea-9005-3a1a7a7de31d.png)


- 웹캠의 __적외선 차단 필름 제거__  
- __자외선 차단 필름을 넣음__  　    `<<선명한 동공 영상을 얻기 위해 적외선 영상을 만듦!`  
- 카메라 주위에 적외선 램프 고정
<br>

#### -완성품
![image](https://user-images.githubusercontent.com/45448731/75803296-92baac00-5dc1-11ea-95c0-182f2be12af5.png)
- 3D 프린팅을 이용하여 카메라 케이스를 제작하였다.
---

### 사용 프로그램

-  __CL-Eye Test__: 안경에 부착된 카메라를 통해 눈 영상 촬영

-  __OpenCV__: 동공 추출, 시선 추적, Calibration

-  __Unity__: 프로그램 제작, 아바타의 눈 움직이게끔 함

-  __Visual Studio__: 프로그래밍, 시선 관련 데이터 처리

---
### 사용 기술
#### -동공 추출
- HoughCircles 함수를 이용하여 원을 찾음  
- 찾을 수 있는 원의 최소 반지름, 최대 반지름, 원 사이의 거리를 조절하여 동공 하나만 추출하도록 함

    ![image](https://user-images.githubusercontent.com/45448731/75806335-cb10b900-5dc6-11ea-8a4e-0ba68616577a.png)
- __Circle 함수를 이용해 동공에 원을 그리고, 그 중심좌표를 찾음__
<br>

#### -
---
