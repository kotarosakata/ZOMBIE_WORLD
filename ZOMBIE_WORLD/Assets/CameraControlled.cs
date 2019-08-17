using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraControlled : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    private Vector3 offset;      //相対距離取得用
    public GameObject UnityChan;

    private UnityChanController unityChanController;
    // Use this for initialization
    void Start ()
    {
        unityChanController = UnityChan.GetComponent<UnityChanController>();
        var position = obj.transform.position;
        offset = transform.position - position;
        Debug.Log(offset);
        offset = gameObject.transform.position - position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        var position = obj.transform.position;

        var o = gameObject;
        o.transform.position = position + offset;
        transform.RotateAround(position,Vector3.up,CrossPlatformInputManager.GetAxis("Mouse X")*10);
        offset = o.transform.position - position;
    }
}
