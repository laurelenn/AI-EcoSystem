using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{

    public Camera cam1;
    public Camera cam2;
    Vector3 initialPos;
   
    void Start()
    {
        initialPos = gameObject.transform.position;
    }
    void Update()
    {
        if (cam1.enabled)
        {
            gameObject.transform.position = new Vector3(initialPos.x, initialPos.y-8000, initialPos.z);
        }
        else
        {
            gameObject.transform.position = initialPos;
        }
       
    }

    
    public void goBackToSolarSystem()
    {
        if (cam2.enabled && !cam1.enabled)
        {
            cam2.enabled = !cam2.enabled;
            cam1.enabled = !cam1.enabled;
            gameObject.transform.position = new Vector3(initialPos.x, initialPos.y - 8000, initialPos.z);
        }
        
        
    }
}
