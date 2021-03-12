using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject RadioButtons;
    [SerializeField] private int maxPlanets;
    public Camera cam1;
    public Camera cam2;
    public GameObject prefabButton;
    public Transform canvas;
    private int nbPlanets;

    //ground materials
    [SerializeField] private Material ice;
    [SerializeField] private Material lava;
    [SerializeField] private Material grass;



    // Start is called before the first frame update
    void Start()
    {
        cam2.enabled = false;
        cam1.enabled = true;
        nbPlanets = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This function gets called when "Generate" is clicked
    public void clickGenerate(){
        if (nbPlanets < maxPlanets)
        {
            //Planet Name must me set in order to create a planet
            string planetName = GameObject.Find("PlanetNameText").GetComponent<UnityEngine.UI.Text>().text;
            if (planetName != "")
            {

                //Get user input to adjust planet parameters
                int planetSize = (int)GameObject.Find("sizeSlider").GetComponent<Slider>().value;
                int planetDistance = (int)GameObject.Find("DistanceSunSlider").GetComponent<Slider>().value;
                int waterPercentage = (int)GameObject.Find("WaterSlider").GetComponent<Slider>().value;
                int indexRadioButton = GetIndexClickedRadioButton();

                //Calls a script called Planet Generator but you can load your own script using same parameters
                GameObject.Find("Manager").GetComponent<PlanetGenerator>().generatePlanet(planetName, planetSize, planetDistance, waterPercentage, indexRadioButton);

                //Generate button for the new planet
                var newButton = Instantiate(prefabButton);
                
                //Button position
                newButton.transform.SetParent(canvas, false);

                RectTransform rt = newButton.GetComponent<RectTransform>();
                rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 20 + 60 * nbPlanets, 50);
                rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 50, 200);

                //Setting text
                var buttonTxt = newButton.transform.Find("Cap/Text").gameObject;
                if (buttonTxt != null)
                {
                    buttonTxt.GetComponent<UnityEngine.UI.Text>().text = planetName;
                }
                newButton.GetComponent<SwitchButton>().idButton = nbPlanets;

                //Change ground material according to planet type
                changeGroundMaterial(indexRadioButton);

                nbPlanets++;
            }
            else
            {
                Debug.Log("Planet name is empty !");
            }
        }
        
    }

    //Returns the Index of the selected Radio Button to determine Planet ground type
    private int GetIndexClickedRadioButton(){
        int result = 0;
        bool found = false;
        while(result < RadioButtons.transform.childCount && !found){
            if (RadioButtons.transform.GetChild(result).GetComponent<LeanToggle>().On)
                found = true;

            if(!found)
                result ++;
        }
        return result;
    }

    private void changeGroundMaterial(int type)
    {
        Material mat;
        switch (type)
        {
            case 0:
                mat = grass;
                break;
            case 1:
                mat = lava;
                break;
            case 2:
                mat = ice;
                break;
            default:
                mat = grass;
                break;
        }
        GameObject matchingTerrain;
        GameObject[] terrains = GameObject.FindGameObjectsWithTag("Closeup");
        foreach (GameObject go in terrains)
        {
            if (go.GetComponent<TerrainGround>().idTerrain == nbPlanets)
            {
                matchingTerrain = go;
                go.transform.Find("Plane").GetComponent<Renderer>().material = mat;
            }
        }
    }
}
