using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Move_HS : MonoBehaviour
{
    GameObject destination;

    void Start()
    {
        destination = GameObject.Find("endpoint"); //endpoint 를 찾고
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, destination.transform.position, Time.deltaTime * 0.15f); // endpoint를 향해서 이동
    }
    private void OnDestroy()
    {
        Wall_Respawn_HS.instance.level_c--;
        Wallgame_manager_HS.instance.decisionflag = 1; //파괴될 시점 1인부분은 통과(콜라이더충돌) 아닌부분은 0이므로 0인부분만 못념겻다는 ui set active
    }
}
