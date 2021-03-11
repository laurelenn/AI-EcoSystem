using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//When button is clicked, switches camera display to the right planet
public class SwitchButton : MonoBehaviour
{
    public Camera cam;
    public Camera cam2;
    public int idButton;
    // Start is called before the first frame update
    void Start()
    {
        
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        cam2 = GameObject.Find("TerrainCamera").GetComponent<Camera>();

        cam2.enabled = false;
        cam.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchDisplay()
    {
        if (!cam2.enabled)
        {
            cam.enabled = !cam.enabled;
            cam2.enabled = !cam2.enabled;
        }
       
        updateCameraPos();
       
    }

    public void updateCameraPos()
    {
        GameObject matchingTerrain;
        GameObject[] terrains = GameObject.FindGameObjectsWithTag("Closeup");
        foreach(GameObject go in terrains)
        {
            if (go.GetComponent<TerrainGround>().idTerrain == idButton)
            {
                matchingTerrain = go;
                cam2.gameObject.transform.position = matchingTerrain.transform.Find("CameraSpawn").transform.position;
                cam2.gameObject.transform.LookAt(matchingTerrain.transform.Find("LookingPoint"));
            }
        }           
    }
    
}
