using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc2Dial_HW : MonoBehaviour
{
    // 텍스트 띄울 텍스트ui (코치한테 있음)
    public Text textDisplay;
    // 대사문장 인스펙터에서 입력
    [TextArea]
    public string[] senteces;
    // 진행 대사 인덱스
    public static int tIndex;
    // 타이핑 속도 
    float typingSpeed = 0.03F;
    // 오디오클립 인덱스
    int cIndex = 0;
    AudioSource myAudio;
    public AudioClip[] clip;

    public GameObject downArrow;
    public GameObject timer;

    // 화살표 한번실행 플래그
    bool arrowFlag;

    FootStanceCheck_HW fsc;

    public GameObject coach;
    // 코치에 있는 애니메이터
    Animator anim;

    // 칼리브레이션 끝났는지 확인용변수
    bool isCaliFIn;

    // 칼리캔버스 - 스타트패널
    public GameObject startPanel;
    public Text tindexCanvas;

    // 시나리오2 끝났는지 확인용 변수
    public static bool isSc2Fin;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        downArrow.SetActive(false);
        anim = coach.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 칼리브레이션 조절이 끝났다면
        if (StartButton_HW.isBtnExit && !isCaliFIn)
        {
            isCaliFIn = true;
            anim.SetTrigger("isCaliFin");
            StartCoroutine(SoundPlay());
        }
        if (FootHeelCheck_HW.bothHeelOn && FootPrintTrigger_HW.bothToeOn)
        {
            FootStanceCheck_HW.instance.StartCoroutine("BothFootOn");
        }

        if (tIndex == 1 && !arrowFlag && !StartButton_HW.isTestStart)
        {
            arrowFlag = true;
            downArrow.SetActive(true);
            // 스타트 패널 켬
            startPanel.SetActive(true);
        }

        //// SBS 테스트
        //if(tIndex == 1 && arrowFlag && StartButton_HW.isTestStart)
        //{
        //    //FootStanceCheck_HW.instance.Test_SBS();
        //    arrowFlag = false;
        //}
        //// ST 테스트
        //else if (tIndex == 2 && !arrowFlag && StartButton_HW.isTestStart)
        //{
        //    arrowFlag = true;
        //}
        //// T 테스트
        //else if (tIndex == 3 && arrowFlag && StartButton_HW.isTestStart)
        //{
        //    arrowFlag = false;
        //}

        else if (tIndex == 4 && arrowFlag)
        {
            arrowFlag = false;
            textDisplay.text = "";
            isSc2Fin = true;
            anim.SetTrigger("isTestFin");
            print("isSc2Fin" + isSc2Fin);
        }

        // 애니메이션 전환용 
        if (tIndex == 1 && !StartButton_HW.isTestStart)
        {
            startPanel.SetActive(true);
            anim.SetTrigger("SBS");
            FootStanceCheck_HW.instance.Test_SBS();

        }
        else if (tIndex == 2 && !StartButton_HW.isTestStart)
        {
            startPanel.SetActive(true);
            anim.SetTrigger("ST");
            FootStanceCheck_HW.instance.Test_ST();

        }
        else if (tIndex == 3 && !StartButton_HW.isTestStart)
        {
            startPanel.SetActive(true);
            anim.SetTrigger("T");
            FootStanceCheck_HW.instance.Test_T();
        }

        // 끝났다면 원래 자리로 되돌아가기위해 디폴트 포지션 파티클 켜서 자리 안내해주기
        if (isSc2Fin)
        {
            GameObject.Find("DefaultPosition").transform.GetChild(0).gameObject.SetActive(true);
        }
        // 티인덱스 표시용 ************************************
        tindexCanvas.text = tIndex.ToString();
    }

    // 음성대사 먼저 플레이
    public IEnumerator SoundPlay()
    {
        myAudio.PlayOneShot(clip[cIndex]);
        yield return new WaitForSeconds(.5f);
        StartCoroutine(Type());
    }

    // 타이핑 효과
    IEnumerator Type()
    {
        //foreach (char letter in senteces[tIndex].ToCharArray())
        //{
        //    textDisplay.text += letter;
        //    yield return new WaitForSeconds(typingSpeed);
        //}

        textDisplay.text = senteces[tIndex].ToString();
        yield return new WaitForSeconds(typingSpeed);

        // 인덱스 1까지 자동으로 호출
        if (tIndex < 1)
        {
            Invoke("NextDial", 4f);
        }

    }

    // 다음 문장 진행
    public void NextDial()
    {
        // 음성대사 인덱스 증가
        cIndex++;
        FootStanceCheck_HW.instance.testAuraEffectOn = false;
        // 현재진행대사 인덱스가 총문장길이보다 작다면
        if (tIndex < senteces.Length - 1)
        {
            // 인덱스 증가
            tIndex++;
            textDisplay.text = "";
            // 음성대사 호출
            StartCoroutine(SoundPlay());
        }
        // 더 이상 진행할 대사가 없다면 (다음시나리오 호출)
        else
        {
            textDisplay.text = "";
            isSc2Fin = true;
        }
    }

    // 일단 안쓰임
    public void Timer()
    {
        downArrow.SetActive(false);
        // 켜져있는 타이머 있으면 초기화 후 재생
        timer.SetActive(false);
        timer.SetActive(true);
        // 타이머 시작
        CircleCount.isTimerOn = true;
    }
}
