using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlanetController : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, speed*Time.deltaTime, 0.0f, Space.Self);
        transform.RotateAround(this.transform.parent.position, this.transform.parent.up, speed*Time.deltaTime);
    }
}
