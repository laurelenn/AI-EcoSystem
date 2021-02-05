using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickGenerate(){
        //appeler l'autre script
        Debug.Log("On appelle l'autre script");
        string planetName = GameObject.Find("PlanetNameText").GetComponent<UnityEngine.UI.Text>().text;
        if(planetName != ""){
            int planetSize = (int)GameObject.Find("sizeSlider").GetComponent<Slider>().value;
            int planetDistance = (int)GameObject.Find("DistanceSunSlider").GetComponent<Slider>().value;
            int indexRadioButton = 0;
            GameObject.Find("Manager").GetComponent<PlanetGenerator>().generatePlanet(planetName, planetSize, planetDistance, indexRadioButton);
        }else{
            Debug.Log("Planet name is empty !");
        }
        
    }
}
