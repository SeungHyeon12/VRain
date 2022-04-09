using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager_HS : MonoBehaviour
{
    public GameObject Music; // 계이름이 들어잇는 빈오브젝트
    private List<GameObject> syllable = new List<GameObject>();
    private AudioSource temp_AudioSource;
    public int syllable_index = 0;
    public int issound = 0;
    public int isfinish = 0;
    public static Soundmanager_HS instance;
    public GameObject UI;//게임오버 UI

    public GameObject confetti;
    public GameObject reback;
    public bool comebackchecker = false;
    public bool last_rock_checker = false;

    public int lv;
    public GameObject lv1;
    public GameObject lv2;
    public GameObject lv3;

    // Start is called before the first frame update

    void Start()
    {
        confetti.SetActive(false);
        reback.SetActive(false);
        lv = PlayerPrefs.GetInt("MINI_lv");
        Debug.Log(lv); 
        
        switch(lv)     //lv 설정
        {
            case 1: lv1.SetActive(true);
                break;
            case 2:
                lv2.SetActive(true);
                break;
            case 3:
                lv3.SetActive(true);
                break;
        }


        instance = this;
        for (int i = 0; i < Music.transform.childCount; i++)//child 갯수만큼 syllable에 저장
        {
            syllable.Add(Music.transform.GetChild(i).gameObject);  // 도레미파솔라시도 8개
                    
        }
    }

    // Update is called once per frame
    void Update()
    {
          
        if(syllable_index == Music.transform.childCount) // syllable _index가 마지막 계이름 도를 가리킬때
        {
            reback.SetActive(true);
            last_rock_checker = true;

            //  UI.SetActive(true);
        }
        if (syllable_index == Music.transform.childCount && comebackchecker)
        {
            UI.SetActive(true);
            confetti.SetActive(true);
        }
            if (1 == issound ) // playermove 스크립트에서 요청
        {
            temp_AudioSource = syllable[syllable_index].GetComponent<AudioSource>(); // 캐시에 징검다리의 index값에맞는 오디오소스를 가져옴
            temp_AudioSource.Play();
            syllable_index = (syllable_index+1); // 음계수가 도~도~도 로 반복이되게끔
            issound = 0;

        }
    }
}
