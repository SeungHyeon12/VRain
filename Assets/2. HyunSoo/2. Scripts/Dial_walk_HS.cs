using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dial_walk_HS : MonoBehaviour
{
    // 텍스트 띄울 텍스트ui (코치한테 있음)
    public Text textDisplay;
    // 대사문장 인스펙터에서 입력
    public string[] senteces;
    // 진행 대사 인덱스
    public static int tIndex;
    // 타이핑 속도 
    float typingSpeed = 0.03F;
    // 오디오클립 인덱스
    int cIndex = 0;
    AudioSource myAudio;
    public AudioClip[] clip;



    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        StartCoroutine(SoundPlay());   
    }

    // Update is called once per frame
    void Update()
    {
       
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
        foreach (char letter in senteces[tIndex].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        Invoke("NextDial", 2f);
    }
     
    // 다음 문장 진행
    public void NextDial()
    {
        // 음성대사 인덱스 증가
        cIndex++;

        // 현재진행대사 인덱스가 총문장길이 마지막보다 작다면
        if (tIndex < senteces.Length -21)
        {
            // 인덱스 증가
            tIndex++;
            textDisplay.text = "";
            // 음성대사 호출
            StartCoroutine(SoundPlay());
        }
       if(Soundmanager_HS.instance.isfinish == 1) // isfinish가 1이면 마지막대사를 하도록
        {
            // 인덱스 증가
            tIndex++;
            textDisplay.text = "";
            // 음성대사 호출
            StartCoroutine(SoundPlay());
        }
    }
}
