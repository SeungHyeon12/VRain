using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// BGM, 효과음 등 오디오 관리
// 메인화면부터 시작
public class AudioManager_HW : MonoBehaviour
{
    public static AudioManager_HW instance;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this);
        }
    }

    AudioSource myAudio;
    public AudioClip[] bgm;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        // 0: 메인화면, 1:테스트씬, 2:미니게임
        myAudio.Play();
        myAudio.loop = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 현재씬이 라면
        if(SceneManager.GetActiveScene().name  == "")
        {
            myAudio.PlayOneShot(bgm[1]);
            myAudio.loop = true;
        }
        else if(SceneManager.GetActiveScene().name == "")
        {
            myAudio.PlayOneShot(bgm[2]);
            myAudio.loop = true;
        }
    }
}
