using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_rightfoot : MonoBehaviour
{   
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("RF"))
            {
                Debug.Log("오른다리 충돌");
                Wallgame_manager_HS.instance.isright_f = 0;
            }
        }
    
}
