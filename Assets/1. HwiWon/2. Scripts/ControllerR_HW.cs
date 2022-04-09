  using UnityEngine;
using Valve.VR;

public class ControllerR_HW : MonoBehaviour
{
    // 오른손 
    SteamVR_Behaviour_Skeleton rightHand;

    // 햅틱
    public SteamVR_Action_Vibration haptic;

    public GameObject buttonEffectPrefab;
    AudioSource myAudio;
    public AudioClip clip;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 만약 버튼에 닿았다면
        if (other.gameObject.tag == "Button")
        {
            // 오른손일 때
            if (gameObject.name.Contains("right") || gameObject.tag == "RH")
            {
                // 오른손 컨트롤러 진동
                haptic.Execute(0.15f, .5f, 1f, 1f, SteamVR_Input_Sources.RightHand);
            }
          
            // 오른손이 종료패널 닫기 버튼을 눌렀다면
            if (gameObject.name.Contains("right") && other.gameObject.name.Contains("Exit"))
            {
                GameObject.Find("vr_glove_left").GetComponent<ControllerL_HW>().ExitReturn();
            }
            else if (gameObject.name.Contains("right") && other.gameObject.name.Contains("Gameover"))
            {
                GameObject.Find("vr_glove_left").GetComponent<ControllerL_HW>().ExitGame();
            }

            // 이펙트 실행
            GameObject go = Instantiate(buttonEffectPrefab);
            go.transform.position = other.gameObject.transform.position;
            myAudio.PlayOneShot(clip);
            Destroy(go, 2f);
        }
    }

    private void Update()
    {
       
    }

    public void Haptic_RH()
    {
        haptic.Execute(0.15f, .5f, 1f, 1f, SteamVR_Input_Sources.RightHand);
    }
    public void Haptic_LH()
    {
        haptic.Execute(0.15f, .5f, 1f, 1f, SteamVR_Input_Sources.LeftHand);
    }
}
