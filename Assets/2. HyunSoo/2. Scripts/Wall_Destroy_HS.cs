using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Destroy_HS : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.transform.parent.gameObject);  //콜라이더처리한부분이 자식이므로 부모가죽게 ㄱㄱ
       
    }
}
