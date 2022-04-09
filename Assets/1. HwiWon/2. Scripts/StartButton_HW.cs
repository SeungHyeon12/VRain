using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 버튼캔버스 - BG에 달려있는 스크립트(테스트 시작 관리)
public class StartButton_HW : MonoBehaviour
{
    public GameObject startEffectPrefab;
    public static bool isBtnExit;
    public static bool isTestStart;

    Animator anim;

    Scene sc;

    // Start is called before the first frame update
    void Start()
    {
        isBtnExit = false;
        sc = SceneManager.GetActiveScene();
        isTestStart = false;
        anim = GameObject.Find("[CameraRig]_Player/CaliCanvas/AdjustUI").gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // 칼리브레이션 버튼이라면
        if (gameObject.name == "AdjustButton")
        {
            if (other.gameObject.name.Contains("vr_glove"))
            {
                GameObject.Find("[CameraRig]_Player/CaliCanvas/AdjustUI/AdjustPanel/Exit").gameObject.SetActive(true);
            }
        }
        // 나가기 버튼이라면
        else if (gameObject.name == "Exit")
        {
            if (other.gameObject.name.Contains("vr_glove"))
            {
                anim.SetTrigger("Exit");
                Invoke("BTN_Exit", 1f);
            }
        }
        // 시나리오2
        if (sc.name == "SC2")
        {
            // 두발을 올렸고 스타트버튼이라면
            if (gameObject.name == "StartButton" && FootStanceCheck_HW.instance.bothFootOn)
            {
                isTestStart = true;
                // 스타트패널 Off  (카메라리그 - 칼리캔버스안에 있음)
                GameObject.Find("[CameraRig]_Player").transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                // SC2일때 타이머 켬 
                GameObject.Find("TimerCanvasParent").transform.GetChild(0).gameObject.SetActive(true);
                CircleCount.isTimerOn = true;
            }
        }
        // 시나리오3
        else if (sc.name == "SC3")
        {
            // 머리(튜토리얼)가 닿았고 스타트버튼이라면 /// 현수수정
            if (gameObject.name == "StartButton" && Sc3Dial_HW.tIndex == 2 && !isTestStart)
            {
                isTestStart = true;
                // 스타트패널 Off  (카메라리그 - 칼리캔버스안에 있음)
                GameObject.Find("[CameraRig]_Player").transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                // 헤드컬라이더 스크립트 활성화
                GameObject.Find("HeadCollider").GetComponent<SphereCollider>().enabled = true;
                // 타이머 켬
                GameObject.Find("TimerCanvasParent").transform.GetChild(0).gameObject.SetActive(true);
                CircleCount.isTimerOn = true;
            }
            else
            {
                if(Sc3Dial_HW.tIndex >= 1)
                {
                    GameObject.Find("HeadCollider").GetComponent<SphereCollider>().enabled = false;
                }
            }
        }
        else if(sc.name == "SC4")
        {
            if (isTestStart)
            {

            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("vr_glove"))
        {
        }
    }

    // 버튼 눌렀을 때 효과
    //public void BTN_Pressed()
    //{
    //    GameObject go = Instantiate(startEffectPrefab);
    //    go.transform.position = GameObject.Find("[CameraRig]_Player").transform.GetChild(4).GetChild(0).GetChild(2).transform.position;
    //    Destroy(go, 2f);
    //}
    // 닫기버튼
    public void BTN_Exit()
    {
        GameObject.Find("[CameraRig]_Player").transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
        isBtnExit = true;
        if(sc.name == "Lobby")
        {
            GameObject.Find("LobbyPrefab").transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (sc.name == "Minigame_Menu")
        {
            GameObject.Find("MinigameIconCanvas").transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}