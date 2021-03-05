using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject sun;
    public GameObject[] PrefabPlanet = new GameObject[3];
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject planet in PrefabPlanet){
            planet.GetComponent<Planet>().GeneratePlanet();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void generatePlanet(string planetName, int planetSize, int planetDistance, int waterPercentage, int indexBiom){

        //Setting name + Instantiate biom
        Debug.Log("Generate " + planetName);

        // Générer l'objet
        var gameObject = Instantiate(
            PrefabPlanet[indexBiom], 
            new Vector3(0,0,-(planetDistance+planetSize)), 
            Quaternion.identity, 
            sun.transform);
        gameObject.SetActive(true);

        // Taille
        gameObject.transform.localScale = new Vector3(planetSize/100f,planetSize/100f, planetSize/100f);

    }
}
