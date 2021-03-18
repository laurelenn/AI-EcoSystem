using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCamera : MonoBehaviour
{
    public Transform spawn1;
    public Transform mustLook;
    
    void Start()
    {
        gameObject.transform.position = spawn1.position;
        gameObject.transform.LookAt(mustLook);
    }

    
    void Update()
    {
        
    }
}
