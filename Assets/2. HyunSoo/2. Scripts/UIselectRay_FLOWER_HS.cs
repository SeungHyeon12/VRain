using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

// Player가 징검다리를 건넌다
// 현재 tracker가 없으니 텔레포트로 이를 대신 하도록 하겠음
public class UIselectRay_FLOWER_HS : MonoBehaviour
{ // hand
    public Transform hand;
    void Start()
    {
        // 태어날때 라인을 안그리고 싶다.
        rightLR.enabled = false;
    }
    public SteamVR_Action_Boolean teleport;
    public LineRenderer rightLR;
    public int maxCurvePosition = 100;

    // 곡선형태의 텔레포트
    private void Update()
    {
        float maxDistance = 100;
        // 1. 점을 세개 만들어서 
        Vector3 a = hand.position;
        Vector3 b = hand.position + hand.forward * maxDistance * 0.7f;
        Vector3 c = hand.position + hand.forward * maxDistance + -hand.up * 20;
        // 2. 그 점으로 만들수있는 Bezier Curve를 만들고싶다.
        // 3. LineRenderer를 커브 형태로 그리고싶다.
        // 1. 만약 컨트롤러의 텔레포트 버튼을 누르면
        if (teleport.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            // 선을 보이게하고싶다.
            rightLR.enabled = true;
        }
        if (rightLR.enabled == true)
        {
            // ====================================
            rightLR.positionCount = maxCurvePosition;
            Vector3 prevPosition = Vector3.zero;
            for (float i = 0; i < maxCurvePosition; i++)
            {
                Vector3 curvePosition = Curve(a, b, c, i / maxCurvePosition);
                // 만약 i 가 0보다 크거나
                // 만약 prevPosition에서 curvePosition로 Ray를 쏴서 부딪힌것이 있다면
                Ray ray = new Ray(prevPosition, curvePosition - prevPosition);
                RaycastHit hitInfo;
                if (i > 0 && Physics.Raycast(ray, out hitInfo))
                {
                    print(hitInfo.transform.gameObject.name);
                    //그곳이 마지막 위치다.
                    rightLR.SetPosition((int)i, hitInfo.point);
                    rightLR.positionCount = (int)i + 1;
                    // 만약 부딪힌 물체가 돌이고 컨트롤러의 텔레포트 버튼을 떼면
                    if (hitInfo.transform.tag.Contains("Rock") && teleport.GetStateUp(SteamVR_Input_Sources.RightHand))
                    {
                        // 4. Ray가 닿은 Rock으로 이동하고싶다. 
                        transform.position = new Vector3(hitInfo.transform.position.x, transform.position.y , hitInfo.transform.position.z);
                        // SoundManager에게 소리를 내달라고 신호를 보내고싶다.
                        Soundmanager_HS.instance.issound = 1;
                    }
                    else if(hitInfo.transform.gameObject.name.Contains("restart") && teleport.GetStateUp(SteamVR_Input_Sources.RightHand))
                    {
                        UImanager_f_HS.instance.Re_gameOnclick();
                    }
                    else if (hitInfo.transform.gameObject.name.Contains("anothergame") && teleport.GetStateUp(SteamVR_Input_Sources.RightHand))
                    {
                        UImanager_f_HS.instance.Go_Menu();
                    }
                }
                else
                {
                    // 그렇지않다면
                    rightLR.SetPosition((int)i, curvePosition);
                }
                prevPosition = curvePosition;
            }
        }
        // ====================================

        // 만약 컨트롤러의 텔레포트 버튼을 떼면
        if (teleport.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            // 선을 안보이게 하고
            rightLR.enabled = false;
        }

        // 4. LineRenderer가 어딘가 부딪혔다면 그곳까지만 그리고싶다.
        // 5. 부딪힌 상태에서 만약 컨트롤러의 텔레포트 버튼을 누르면
        // 6. 만약 그곳이 타워라면 텔레포트 하고싶다.
    }

    Vector3 Curve(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);
        return Vector3.Lerp(ab, bc, t);
    }

}
