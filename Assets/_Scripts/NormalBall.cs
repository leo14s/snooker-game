using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public bool finaldejogo = false;
    public bool caiu = false;
    protected bool ResetIt;
    protected Vector3 Startpos;
    private SphereCollider rigd;
    // Start is called before the first frame update
    void Start()
    {
        Startpos = transform.position;
        rigd = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (finaldejogo || ResetIt)
        {
            finaldejogo = false;
            rigd.isTrigger = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.position = Startpos;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pocket"))
        {
            Debug.Log("bola caiu na caçapa");
            caiu = true;
            var script = GetComponentInParent<GameController>();
            script.numeroDebolas++;
            rigd.isTrigger = true;
        }
    }
    
    public void ResetBall()
    {
        ResetIt = true;
    }
}
