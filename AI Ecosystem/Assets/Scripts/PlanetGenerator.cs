using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetGenerator : MonoBehaviour
{
     public Mesh objectToCreate;
     public GameObject sun;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void generatePlanet(string planetName, int planetSize, int planetDistance, int waterPercentage, int indexRadioButton){

        //Setting name
        Debug.Log("Generate " + planetName);
        var gameObject = new GameObject(planetName);

        //Cree une sphere par défaut
        var meshFilter = gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        meshFilter.sharedMesh = objectToCreate;

        //Child from sun 
        gameObject.transform.parent = sun.transform;
        
        //Distance and scale
        //gameObject.transform.position = new Vector3(0,0,-100);
        gameObject.transform.position = new Vector3(0,0,-planetDistance);
        //gameObject.transform.localScale = new Vector3(1,1,1);
        gameObject.transform.localScale = new Vector3(planetSize/100f,planetSize/100f, planetSize/100f);

        //set planet speed rotation around the sun
        gameObject.AddComponent<PlanetController>();
        gameObject.GetComponent<PlanetController>().speed = 30;

    }
}
