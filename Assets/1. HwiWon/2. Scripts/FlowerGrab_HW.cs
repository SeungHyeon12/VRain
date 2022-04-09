using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FlowerGrab_HW : MonoBehaviour
{
    public SteamVR_Action_Boolean trigger;
    public SteamVR_Behaviour_Pose RH;
    //public GameObject flower_petal;
    
    bool isFlowerGrab;
    bool isGrabbing;
    bool isVibration;

    bool flowerCreated;
    GameObject go;

    public SteamVR_Action_Vibration haptic;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 꽃을 들고 있고 트리거를 놓았을 때
        if (isFlowerGrab && trigger.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            // 꽃 잡기 false
            isFlowerGrab = false;
            isVibration = false;
            Destroy(GameObject.Find("flower(Clone)"));
        }

        if (trigger.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            isGrabbing = true;
        }
        else if (trigger.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            isGrabbing = false;
        }

        //if (isFlowerGrab && trigger.GetState(SteamVR_Input_Sources.RightHand) && RH.GetVelocity().magnitude > 0.2 && !flowerCreated) // 손을 흔들때
        //{
        //    flowerCreated = true;
        //    go = Instantiate(flower_petal);
        //    go.transform.position = new Vector3(4.34f,4.047f,-0.69f);
        //}
        //else if (trigger.GetState(SteamVR_Input_Sources.RightHand) && RH.GetVelocity().magnitude < 0.2)
        //{
        //    flowerCreated = false;
        //    Destroy(go, 5f);
        //}
    }

    // 꽃을 잡고 있을 때
    private void OnTriggerStay(Collider other)
    {
        // 꽃이고 오른손 트리거버튼을 누르면 
        if (other.transform.CompareTag("Flower") && isGrabbing)
        {
            isFlowerGrab = true;
            // 자식으로 만듦
            other.transform.parent = this.transform;
            Destroy(other.GetComponent<Rigidbody>());


            if (!isVibration)
            {
                isVibration = true;
                haptic.Execute(0.15f, .5f, 1f, 1f, SteamVR_Input_Sources.RightHand);
            }
        }
    }
}
