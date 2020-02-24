using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicBall : MonoBehaviour
{
    public float force;
    public bool finaldejogo = false;
    public new Rigidbody rigidbody;
    protected bool ResetIt;
    protected Vector3 Startpos;

    
    // Use this for initialization
    void Start()
    {
        Startpos = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                //var white = hit.collider.CompareTag("WhiteBall");
                //if (white)
                //{
                    rigidbody.AddForceAtPosition((rigidbody.position - hit.point).normalized * force, hit.point);
                //}
            }
        }
        if (ResetIt || finaldejogo)
        {
            ResetIt = false;
            finaldejogo = false;
            transform.position = Startpos;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pocket"))
        {
            Debug.Log("bola branca caiu na caçapa");
            
            ResetBall();
        }
    }

    public void ResetBall()
    {
        ResetIt = true;
    }
}
