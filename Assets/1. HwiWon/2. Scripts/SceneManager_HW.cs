using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// 씬 이동간의 관리
// 메인화면 씬에서 시작
public class SceneManager_HW : MonoBehaviour
{
    public static SceneManager_HW instance;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            //DontDestroyOnLoad(instance);
        }
        //else
        //{
        //    Destroy(this);
        //}
        sc = SceneManager.GetActiveScene();

        if (firstTime == 0 && sc.name == "Lobby")
        {
            firstTime = 1;
        }
    }

    public static int firstTime;
    Scene sc;
    // 씬 불러오는 거 체크 플래그
    public bool LoadFin;    //현수 수정
    /// </summary>
    // 끝날 때 이펙트용 콘페티 
    public GameObject confettiParticle1, confettiParticle2;
    AudioSource myAudio;
    public AudioClip confettiClip;
    bool caliOff;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Sc1Dial_HW.isSc1Fin && !LoadFin && SpinZone_HW.isSpinZone)          //현수가 fade를 위해 수정한부분
        {
            Fade_Manager_HS.instance.isFade_start = true;
            LoadFin = true;
            Invoke("SC2_Load", 4f);
            Confetti();
        }
        else if (Sc2Dial_HW.isSc2Fin && LoadFin && SpinZone_HW.isSpinZone)
        {
            Fade_Manager_HS.instance.isFade_start = true;
            LoadFin = false;
            Invoke("SC3_Load", 4f);
            Confetti();
        }
        else if (Sc3Dial_HW.isSc3Fin && !LoadFin && SpinZone_HW.isSpinZone)
        {
            Fade_Manager_HS.instance.isFade_start = true;
            LoadFin = true;
            Invoke("SC4_Load", 4f);
            Confetti();
        }
        else if (Sc4Dial_HW.isSc4Fin && LoadFin && SpinZone_HW.isSpinZone) //&& !StartButton_HW.isTestStart )
        {
            Fade_Manager_HS.instance.isFade_start = true;
            LoadFin = false;
            Invoke("LobbyResult", 4f);
            firstTime = 2;
            Confetti();
        }

        // 테스트 끝나고 넘어왔다면 
        if (firstTime == 2 && !caliOff && sc.name != "MINI_Wall")
        {
            caliOff = true;
            // 캘리 안뜨게
            GameObject.Find("CaliCanvas").gameObject.SetActive(false);
        }

        if(sc.name == "MINI_Wall")
        {
            caliOff = false;
            GameObject.Find("CaliCanvas").gameObject.SetActive(true);
        }
    }

    void SC2_Load()
    {
        SceneManager.LoadScene("SC2");
        Sc1Dial_HW.isSc1Fin = false;
    }
    void SC3_Load()
    {
        SceneManager.LoadScene("SC3");
        Sc2Dial_HW.isSc2Fin = false;
    }
    void SC4_Load()
    {
        SceneManager.LoadScene("SC4");
        Sc3Dial_HW.isSc3Fin = false;
    }

    public void Confetti()
    {
        GameObject go1 = Instantiate(confettiParticle1);
        GameObject go2 = Instantiate(confettiParticle2);
        //if (sc.name == "SC1" || sc.name == "SC1" || sc.name == "SC2" || sc.name == "SC3")
        //{
        go1.transform.position = transform.GetChild(0).transform.position;
        go2.transform.position = transform.GetChild(1).transform.position;
        //}
        //else if(sc.name == "SC4")
        //{
        //    go1.transform.position = new Vector3(-1.156f,7.41f,-7.02f);
        //    go2.transform.position = new Vector3(-1.156f, 5.41f, -6.683f);
        //}
        myAudio.PlayOneShot(confettiClip);
    }

    void LobbyResult()
    {
        SceneManager.LoadScene("Lobby");
    }
}
