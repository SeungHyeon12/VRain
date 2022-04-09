using UnityEngine;
using Valve.VR;

public class ControllerL_HW : MonoBehaviour
{
    // 왼손
    SteamVR_Behaviour_Skeleton leftHand;

    // 그립버튼
    public SteamVR_Action_Boolean grip;
    // 햅틱
    public SteamVR_Action_Vibration haptic;

    // 종료 캔버스
    GameObject exitCanvas;
    bool isExitPanelOn;

    public GameObject buttonEffectPrefab;
    AudioSource myAudio;
    public AudioClip clip;

    private void Start()
    {
        // 왼손이라면
        if (gameObject.name.Contains("glove_left"))
        {
            // 종료캔버스 할당
            exitCanvas = transform.GetChild(3).gameObject;
        }
        myAudio = GetComponent<AudioSource>();

        if (gameObject.name.Contains("glove_left"))
        {
            leftHand = GameObject.Find("[CameraRig]_Player/vr_glove_left").GetComponent<SteamVR_Behaviour_Skeleton>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 만약 버튼에 닿았다면
        if (other.gameObject.tag == "Button")
        {
            // 왼손일 때
            if (gameObject.name.Contains("left") || gameObject.tag == "LH")
            {
                // 왼손 컨트롤러 진동
                haptic.Execute(0.15f, .5f, 1f, 1f, SteamVR_Input_Sources.LeftHand);
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
        // exitPanel이 안켜져있고 왼손 그립버튼을 눌렀을 때
        if (!isExitPanelOn && grip.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            // 종료 패널 켬
            isExitPanelOn = true;
        }
        else if (isExitPanelOn && grip.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            // 종료 패널 끔
            isExitPanelOn = false;
        }

        // 왼손일 때
        if (exitCanvas != null)
        {
            if (isExitPanelOn)
            {
                exitCanvas.SetActive(true);
            }
            else if (!isExitPanelOn)
            {
                exitCanvas.SetActive(false);
            }
        }
    }

    public void Haptic_RH()
    {
        haptic.Execute(0.15f, .5f, 1f, 1f, SteamVR_Input_Sources.RightHand);
    }
    public void Haptic_LH()
    {
        haptic.Execute(0.15f, .5f, 1f, 1f, SteamVR_Input_Sources.LeftHand);
    }

    public void ExitGame()
    {
        print("종료");
        Application.Quit();
    }

    public void ExitReturn()
    {
        isExitPanelOn = false;
    }
}
