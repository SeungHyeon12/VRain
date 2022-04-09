using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_syllabel : MonoBehaviour
{
    public Material mat;
    Renderer origin_mat;
    private void Start()
    {
        origin_mat = GetComponent<Renderer>();
    }
    int isalreadyarrive = 0;// 이미 한발이 미리 도착해있는가?
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("LF") || other.tag.Contains("RF"))
        {
            if (isalreadyarrive == 0) // 양발중 한발이 먼져 도착
            {
                origin_mat.material = mat; // 도착시 색이바뀌게끔;
                Soundmanager_HS.instance.issound = 1;
                isalreadyarrive = 1;
            }
        }
    }
}
