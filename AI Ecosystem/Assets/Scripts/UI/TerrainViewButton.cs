using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainViewButton : MonoBehaviour
{

    public int idButton;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("TerrainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //placer la cam au bon endroit
    //switch sur la camera
}
