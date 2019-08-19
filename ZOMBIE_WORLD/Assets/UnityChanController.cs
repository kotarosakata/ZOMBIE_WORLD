using System;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

using UnityEngine;

public class UnityChanController : MonoBehaviour
{    
    private Vector3 lastMousePosition;
    //回転の計算用
    [SerializeField]
    private CreateSwordTrail swordTrail;

    private Vector3 newAngle = new Vector3(0, 0, 0);
    private float   m_turnSpeed = 0.0f;
    private float   m_turnSpeedScale    = 180.0f;
    private float Horizontal;
    private float Vertical;
    public GameObject obj;
    private bool isrunning1 = false;
    private bool isrunning2 = false;

    private bool isrunning3 = false;
    
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private bool isrolling = false;
    private bool isattacking = false;
    public void unityChanattacking()
    {
        isattacking = true;
    }
    public void UnityChanrolling()
    {
        isrolling = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon2"))
        {
            var transform1 = transform;
            transform1.position = transform1.position - (transform1.forward * 1f);
            StartCoroutine(Coroutine3());
        }
    }

    IEnumerator Coroutine3()
    {
        if (isrunning1)
        {
            yield break;
        }
        Debug.Log("aaaa");
        animator.SetBool("isdameged",true);
        isrunning1 = true;
        Debug.Log(animator.GetBool("isdameged"));
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("isdameged",false);
        isrunning1 = false;
    }
    IEnumerator Coroutine2()
    {
        if (isrunning2)
        {
            yield break;
        }
        swordTrail.SetSwordTrail(true);
        animator.SetBool("isattacking",true);
        isrunning2 = true;
        yield return new WaitForSeconds(2.0f);
        animator.SetBool("isattacking",false);
        swordTrail.SetSwordTrail(false);
        isrunning2 = false;
    }
    IEnumerator Coroutine()
    {
        if(isrunning3) yield break;
        isrunning3 = true;

        yield return new WaitForSeconds(0.2f);
        animator.SetBool("isrolling",false);
        isrunning3 = false;
    }

    void Update()
    {
        Horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        Vertical = CrossPlatformInputManager.GetAxis("Vertical");
        if (isrolling||isattacking)
        {
            if (isrolling)
            {
                animator.SetBool("isrolling", true);
                isrolling = false;
                StartCoroutine(Coroutine());
            }
            else
            {
                
                isattacking = false;
                
                StartCoroutine(Coroutine2());
            }

        }else if (Horizontal != 0 || Vertical != 0)
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
            if (angle2 > 0&&angle2<180) angle *= -1;
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
