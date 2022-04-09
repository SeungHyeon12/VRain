using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCulling_HW : MonoBehaviour
{
    Camera CameraMirror;
    private void Awake()
    {
        CameraMirror = GetComponent<Camera>();
    }

    public void OnPreCull()
    {
        CameraMirror.ResetProjectionMatrix();
        CameraMirror.projectionMatrix = CameraMirror.projectionMatrix * Matrix4x4.Scale(new Vector3(-1, 1, 1));
    }
    public void OnPreRender()
    {
        GL.invertCulling = true;
    }

    public void OnPostRender()
    {
        GL.invertCulling = false;
    }

    
    

}
