using System;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

using UnityEngine;

public class UnityChanController : MonoBehaviour
{    
    private Vector3 lastMousePosition;
    //回転の計算用
    private Vector3 newAngle = new Vector3(0, 0, 0);
    private float   m_turnSpeed = 0.0f;
    private float   m_turnSpeedScale    = 180.0f;
    private float Horizontal;
    private float Vertical;
    public GameObject obj;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    //Update　毎フレーム呼ばれる命令　60fpsなら1秒間に大体60回(必ずではない)
/*    private void Update () {
//
//        m_turnSpeed     = CrossPlatformInputManager.GetAxis( "Mouse X" ) * m_turnSpeedScale;
//        Debug.logger.Log(m_turnSpeed);
//        transform.rotation *= Quaternion.AngleAxis( m_turnSpeed * Time.deltaTime, Vector3.up );
//        Vector3 vec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"),0,CrossPlatformInputManager.GetAxis("Vertical"));
//        Debug.DrawRay(transform.position,vec,Color.red);
//        float angle = Vector3.Angle (vec,  transform.root.gameObject.transform.forward);
//        Debug.Log(angle); 
//        transform.rotation = Quaternion.AngleAxis(angle,  transform.root.gameObject.transform.up);
        Horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        Vertical = CrossPlatformInputManager.GetAxis("Vertical");
        if (Horizontal != 0 || Vertical != 0)
        {
            Vector3 vec = new Vector3(Horizontal,0,Vertical);
            float angle2 = Vector3.Angle(transform.root.gameObject.transform.forward, obj.transform.forward);
            var axis2 = Vector3.Cross( transform.root.gameObject.transform.forward,obj.transform.forward  );
            if (axis2.y < 0) angle2 *= -1;
            else if(axis2.y!=0) vec.x *= -1;
            vec=vec.normalized;
            float angle = Vector3.Angle (vec,  transform.root.gameObject.transform.forward);
            
            var axis = Vector3.Cross( transform.root.gameObject.transform.forward,vec  );
            if (axis.y < 0) angle *= -1;
            Debug.Log(vec+" , "+transform.root.gameObject.transform.forward);
            if (angle2 > 45&&angle2<135) angle *= -1;
            transform.rotation = Quaternion.AngleAxis(angle+angle2,transform.up);
            animator.SetBool("isrunning",true);
            transform.Translate(0,0,vec.magnitude*0.05f);
       
        }
        else
        {
            animator.SetBool("isrunning",false);
        }
        

//transform.Translate(transform.forward*vec.magnitude*0.01f);

    }*/

     void Update()
    {
        Horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        Vertical = CrossPlatformInputManager.GetAxis("Vertical");
        if (Horizontal != 0 || Vertical != 0)
        {
            Vector3 vec = new Vector3(Horizontal,0,Vertical);
            float angle2 = Vector3.Angle(transform.root.gameObject.transform.forward, obj.transform.forward);
            var axis2 = Vector3.Cross( transform.root.gameObject.transform.forward,obj.transform.forward  );
            if (axis2.y < 0) angle2 *= -1;
            else if(axis2.y!=0) vec.x *= -1;
            vec=vec.normalized;
            float angle = Vector3.Angle (vec,  transform.root.gameObject.transform.forward);
            var axis = Vector3.Cross( transform.root.gameObject.transform.forward,vec  );
            if (axis.y < 0) angle *= -1;
            if (angle2 > 45&&angle2<180) angle *= -1;
            Debug.Log(angle2);
            transform.rotation = Quaternion.AngleAxis(angle+angle2,transform.up);
            animator.SetBool("isrunning",true);
            transform.Translate(0,0,vec.magnitude*0.05f);
       
        }
        else
        {
            animator.SetBool("isrunning",false);
        }
    }
    
}
