using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int numeroDebolas = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numeroDebolas == 15)
        {
            numeroDebolas = 0;

            var white = GetComponentInChildren<PhysicBall>();
            white.finaldejogo = true;
            
            var childComponents = GetComponentsInChildren<NormalBall>();
            foreach (var component in childComponents)
            {
                component.finaldejogo = true;
            }
        }
    }
}
