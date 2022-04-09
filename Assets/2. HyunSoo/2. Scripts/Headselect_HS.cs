using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

// 헤드셋의 시선방향이 가리키는 곳으로(UI 버튼선택용) ui 충돌시 색이바뀌고 트리거를 누르면 onclick이 되게끔 ->추후 수정
public class Headselect_HS : MonoBehaviour
{
    public Material select_material;
    Material origin_material;
    RaycastHit temp; // 임시용 캐시
    public GameObject UI;
    public SteamVR_Action_Boolean trigger;

    int UI_layer;
    Material temp_material;
    
    // Start is called before the first frame update
    void Start()
    {
        origin_material = UI.GetComponent<Material>(); 
        UI_layer = 1 << LayerMask.NameToLayer("UI");
    }
    
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hitinfo;
       
        if(Physics.Raycast(ray,out hitinfo,UI_layer))
        {
           
           if( hitinfo.transform.name.Contains("anothergame"))//camerarig 의 ray가 ui 충돌하고 
            {
                temp = hitinfo; // 캐시에 hitinfo 저장하고
                hitinfo.transform.GetComponent<MeshRenderer>().material = select_material; // 충돌된 ui 의 색이바뀜으로서 인식이되고
                if (trigger.GetStateDown(SteamVR_Input_Sources.RightHand)) // 트리거버튼을 누를 시 ->사용된버튼 기능 사용
                {
                    UImanager_HS.instance.Go_Menu();
                }
            }
           else if (hitinfo.transform.name.Contains("restart"))
            {
                temp = hitinfo;
                hitinfo.transform.GetComponent<MeshRenderer>().material = select_material;
                if (trigger.GetStateDown(SteamVR_Input_Sources.RightHand))
                {
                    UImanager_HS.instance.Re_gameOnclick();
                }
            }
           else //  다른 ui 를 바라보았을 경우 색이 원래대로 돌아가게끔
            {
                temp.transform.GetComponent<MeshRenderer>().material = origin_material;
            }
        }


    }
}
