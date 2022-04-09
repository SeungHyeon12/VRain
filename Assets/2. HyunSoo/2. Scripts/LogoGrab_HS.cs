using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class LogoGrab_HS : MonoBehaviour
{
    public SteamVR_Action_Boolean trigg;
    public SteamVR_Behaviour_Pose RH;

    private void Start()
    {

    }
    private void Update()
    {

        GameObject temp_object = null;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Flower"))
            {
                temp_object = transform.GetChild(i).gameObject; // 꽃 게임오브젝트를 temp 에 저장
            }
        }
        /*  if (null != temp_object && trigger.GetState(SteamVR_Input_Sources.RightHand)&&RH.GetVelocity().magnitude >0.2) // 손을 흔들때
          {
              Debug.Log("꽃이 떨어진다");
              ps.Play();
          }
          else if(null != temp_object && trigger.GetState(SteamVR_Input_Sources.RightHand) && RH.GetVelocity().magnitude < 0.2)
          {
              Debug.Log("꽃이 멈춘다");    
              ps.Stop();
          }*/
        if (null != temp_object && trigg.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            temp_object.GetComponent<Rigidbody>().isKinematic = false;     // 트리거버튼을 때면 꽃이 없어지게
            temp_object.transform.parent = null;
        }



    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Flower") && trigg.GetStateDown(SteamVR_Input_Sources.RightHand)) // tag가 flower이고 오른손의 트리거버튼을 누르면
        {
            print(other.gameObject.name);
            other.transform.parent = this.transform; // 자식이되게끔
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}