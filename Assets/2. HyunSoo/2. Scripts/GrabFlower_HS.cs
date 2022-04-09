using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class GrabFlower_HS : MonoBehaviour
{
    public SteamVR_Action_Boolean trigger;
    public SteamVR_Behaviour_Pose RH;
    public GameObject flower_petal;

    // 휘원수정
    GameObject go;
    bool isFlowerGrab;
    bool flowerCreated;

    ParticleSystem ps;
    private void Start()
    {
        ps = flower_petal.GetComponent<ParticleSystem>();
        ps.Stop();
    }
    private void Update()
    {
        flower_petal.transform.position = RH.transform.position;
        GameObject temp_object = null;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Flower"))
            {
                temp_object = transform.GetChild(i).gameObject; // 꽃 게임오브젝트를 temp 에 저장
                isFlowerGrab = true;
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

        if (null != temp_object && trigger.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            isFlowerGrab = false;
            Destroy(temp_object);     // 트리거버튼을 때면 꽃이 없어지게
        }

        // 꽃잎 휘원수정
        if (isFlowerGrab && trigger.GetState(SteamVR_Input_Sources.RightHand) && RH.GetVelocity().magnitude > 0.2 && !flowerCreated) // 손을 흔들때
        {
            flowerCreated = true;
            go = Instantiate(flower_petal);
            go.transform.position = new Vector3(4.34f, 4.047f, -0.69f);
        }
        else if (trigger.GetState(SteamVR_Input_Sources.RightHand) && RH.GetVelocity().magnitude < 0.2)
        {
            flowerCreated = false;
            Destroy(go, 5f);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Flower") && trigger.GetStateDown(SteamVR_Input_Sources.RightHand)) // tag가 flower이고 오른손의 트리거버튼을 누르면
        {
            other.transform.parent = this.transform; // 자식이되게끔
            //other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

}