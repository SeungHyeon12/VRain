using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc4Dial_HW : MonoBehaviour
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

    public GameObject coach;
    // 코치에 있는 애니메이터
    Animator anim;

    // 칼리브레이션 끝났는지 확인용변수
    bool isCaliFIn;

    // 시나리오4 끝났는지 확인용 변수
    public static bool isSc4Fin;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
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
        // 끝났다면 원래 자리로 되돌아가기위해 디폴트 포지션 파티클 켜서 자리 안내해주기
        if (isSc4Fin && PlayerActionManager_HW.fourMeterFlag)
        {
            GameObject.Find("DefaultPosition").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("DefaultPosition").transform.GetChild(0).GetComponent<SphereCollider>().enabled = true;
        }
    }

    // 음성대사 먼저 플레이
    public IEnumerator SoundPlay()
    {
        myAudio.PlayOneShot(clip[cIndex]);
        yield return new WaitForSeconds(.5f);
        StartCoroutine(Type());
    }

    // 타이핑 효과
    public IEnumerator Type()
    {
        //foreach (char letter in senteces[tIndex].ToCharArray())
        //{
        //    textDisplay.text += letter;
        //    yield return new WaitForSeconds(typingSpeed);
        //}

        textDisplay.text = senteces[tIndex].ToString();
        yield return new WaitForSeconds(typingSpeed);

        // 자동으로 호출이 아닌 동작 수행에 따른 호출로 변경해야 함
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
            isSc4Fin = true;
        }
    }
}
