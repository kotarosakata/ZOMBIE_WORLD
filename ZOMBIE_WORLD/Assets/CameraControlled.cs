using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraControlled : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(obj.transform.position,Vector3.up,CrossPlatformInputManager.GetAxis("Mouse X")*10);
   //     this.transform.Rotate ( 0, ( CrossPlatformInputManager.GetAxis( "Mouse X" ) * 10 ), 0 );
    }
}
