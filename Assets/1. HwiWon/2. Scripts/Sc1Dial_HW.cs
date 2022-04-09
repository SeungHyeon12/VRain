using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc1Dial_HW : MonoBehaviour
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

    // 인덱스3(여기로 와보세요) 화살표마크
    public GameObject arrow;
    // 팔 드는지 확인용 컬라이더 오브젝트
    public GameObject h_leftObject, h_rightObject;
    // 다리 드는지 확인용 컬라이더 오브젝트
    public GameObject f_leftObject, f_rightObject;
    // 충돌오브젝트 생성 플래그
    bool collObjFlag;

    public GameObject coach;
    // 코치에 있는 애니메이터
    Animator anim;

    // 칼리브레이션 끝났는지 확인용변수
    bool isCaliFIn;
    // 시나리오1 끝났는지 확인용 변수
    public static bool isSc1Fin;


    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        arrow.SetActive(false);
        anim = coach.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 칼리브레이션 조절이 끝났다면
        if ( StartButton_HW.isBtnExit && !isCaliFIn)
        {
            isCaliFIn = true;
            anim.SetTrigger("isCaliFin");
            StartCoroutine(SoundPlay());
        }

        if (tIndex == 3)
        {
            arrow.SetActive(true);
        }
        // 오른손 들기
        else if(tIndex == 4 && !collObjFlag)
        {
            Destroy(arrow);
            anim.SetTrigger("RH");
            collObjFlag =true;
            h_rightObject.SetActive(true);
        }
        // 왼손들기
        else if (tIndex == 5 && collObjFlag)
        {
            anim.SetTrigger("LH");
            collObjFlag = false;
            h_leftObject.SetActive(true);
        }
        // 오른발 들기
        else if (tIndex == 6 && !collObjFlag)
        {
            anim.SetTrigger("RF");
            collObjFlag = true;
            f_rightObject.SetActive(true);
        }
        // 왼발 들기
        else if (tIndex == 7 && collObjFlag)
        {
            anim.SetTrigger("LF");
            collObjFlag = false;
            f_leftObject.SetActive(true);
        }

        // 끝났다면 원래 자리로 되돌아가기위해 디폴트 포지션 파티클 켜서 자리 안내해주기
        if (isSc1Fin)
        {
            GameObject.Find("DefaultPosition").transform.GetChild(0).gameObject.SetActive(true);
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

        // 인덱스 3까지 자동으로 호출
        if (tIndex < 3)
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
            isSc1Fin = true;
        }
    }
}
