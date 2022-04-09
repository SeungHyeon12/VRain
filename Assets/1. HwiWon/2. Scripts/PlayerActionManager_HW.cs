using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RootMotion.Demos;

public class PlayerActionManager_HW : MonoBehaviour
{
    public static PlayerActionManager_HW instance;

    private void Awake()
    {
        instance = this;
    }

    Sc1Dial_HW sc1;
    Sc2Dial_HW sc2;
    Sc3Dial_HW sc3;
    Scene sc;

    // 0 defalut, 1 노말, 2 반일렬, 3 일렬 
    int missionState;

    // 미션 중인지 아닌지 판단 플래그
    public static bool isMissionStart;

    // 4m트리거 끝지점 닿은 플래그
    public static bool fourMeterFlag;

    public static int chairCount = 6;

    // Start is called before the first frame update
    void Start()
    {
        sc = SceneManager.GetActiveScene();
        // 시나리오1 씬이라면
        if (sc.name == "SC1")
        {
            // 다이얼로그매니저에서 Sc1Dial스크립트 가져옴
            sc1 = GameObject.Find("DialogueManager").GetComponent<Sc1Dial_HW>();
        }
        else if(sc.name == "SC2")
        {
            // 다이얼로그매니저에서 Sc2Dial스크립트 가져옴
            sc2 = GameObject.Find("DialogueManager").GetComponent<Sc2Dial_HW>();
        }
        else if (sc.name == "SC3")
        {
            // 다이얼로그매니저에서 Sc2Dial스크립트 가져옴
            sc3 = GameObject.Find("DialogueManager").GetComponent<Sc3Dial_HW>();
        }
   }

    // Update is called once per frame
    void Update()
    {
    }

    // 오른손 들기 체크함수
    public void rHandUp()
    {
        Sc1Dial_HW.tIndex = 4;
        sc1.NextDial();
    }
    // 왼손 들기 체크함수
    public void lHandUp()
    {
        Sc1Dial_HW.tIndex = 5;
        sc1.NextDial();
    }
    public void rFootUp()
    {
        Sc1Dial_HW.tIndex = 6;
        sc1.NextDial();
    }
    public void lFootUp()
    {
        Sc1Dial_HW.tIndex = 7;
        sc1.NextDial();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (sc.name == "SC1")
        {
            // 오른발 왼발 트래커가 화살표에 닿았다면
            if (other.gameObject.name.Contains("Arrow") && (gameObject.name.Contains("_left") || gameObject.name.Contains("_right")))
            {
                if (sc != null)
                {
                    sc1.NextDial();
                }
            }
            // 이 스크립트가 들어있는 오브젝트가 오른손 컨트롤러이고 RCollider라면
            if (gameObject.tag == "RH" && other.gameObject.tag == "RH")
            {
                rHandUp();
            }
            // 이 스크립트가 들어있는 오브젝트가 왼손 컨트롤러이고 LCollider라면
            if (gameObject.tag == "LH" && other.gameObject.tag == "LH")
            {
                lHandUp();
            }
            // 이 스크립트가 들어있는 오브젝트가 오른 다리이고 RightFootCollider라면
            if (gameObject.tag == "RF" && other.gameObject.tag == "RF")
            {
                rFootUp();
            }
            // 이 스크립트가 들어있는 오브젝트가 왼 다리이고 leftFootCollider라면
            if (gameObject.tag == "LF" && other.gameObject.tag == "LF")
            {
                lFootUp();
            }
        }
        // 씬2일 때
        else if (sc.name == "SC2")
        {

        }
        else if (sc.name == "SC4")
        {
            /////////////////현수가 짠 코딩부분  // 태그설정확인요망
            if (other.gameObject.tag == "4m_trigger" && StartButton_HW.isBtnExit) // 시작부분 태그
            {
                // 스톱워치에서 저장   
                print("걷기 측정 시작");
                // 대화 캔버스 끔
                GameObject.Find("Coach").transform.GetChild(3).gameObject.SetActive(false);
                // 테스트 시작 알림
                StartButton_HW.isTestStart = true;
                // 대화 끝
                Sc4Dial_HW.isSc4Fin = true;
            }
            // 4m_trigger end 라면
            if (other.gameObject.tag.Contains("end"))
            {
                StartButton_HW.isTestStart = false;//현수수정 
                // 대화 끝
                fourMeterFlag = true;
                print("걷기 측정 끝");
                GameObject.Find("4mHall").transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
                // 결과 저장
                TestScores_HW.resultSave = true;
            }
            ///////////////////////////////////////////////////////////////////////////////

        }
        // 칼리브레이션 버튼일 때
        if (other.gameObject.name.Contains("Adjust"))
        {
            //male에 들어있는 칼리브레이션 스크립트에서 calibrateFlag를 true로 바꿔줌 -> 칼리브레이션 실행
            VRIKAvatarScaleCalibrationSteamVR ik = GameObject.Find("[CameraRig]_Player").transform.GetChild(0).GetComponent<VRIKAvatarScaleCalibrationSteamVR>();
            ik.calibrateFlag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (sc.name == "SC3")
        {
            // HMD가 Collider에 닿았다면 
            if (gameObject.tag == "MainCamera" && other.gameObject.name.Contains("HeadCol") && isMissionStart && chairCount > 1 && FootCheck_SC3_HW.bothFootOn)
            {
                // 첫 튜토리얼 시만 칼리캔버스- 스타트패널 On
                if (Sc3Dial_HW.tIndex != 2)
                {
                    GameObject.Find("[CameraRig]_Player").transform.GetChild(4).GetChild(1).gameObject.SetActive(true);  ///현수수정
                }
                Sc3Dial_HW.tIndex = 1;
                chairCount--;
                if (Sc3Dial_HW.tIndex < 2 && !Sc3Dial_HW.isSc3Fin)
                {
                    sc3.NextDial();
                }
            }
            // 의자 테스트를 5번 다 진행했다면   
            else if (chairCount == 1)
            {
                GameObject.Find("DialogueManager").GetComponent<Sc3Dial_HW>().CanvasOff();
                GameObject.Find("MainUImanager").GetComponent<CircleCount>().TimerCanvasOff();
            }
        }
    }
    //void Timer()
    //{
    //    sc2.Timer();
    //}
}
