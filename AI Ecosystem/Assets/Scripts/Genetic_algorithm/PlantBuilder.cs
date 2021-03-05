using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBuilder : MonoBehaviour
{
    [SerializeField] GameObject coniferBase;
    [SerializeField] GameObject coniferCone;
    public GameObject BuildPlant(Plant plant) {
        float x = Random.Range(0, 200);
        float y = Random.Range(0, 200);
        float volume = plant.volume / 200;
        Vector3 scale = new Vector3(volume+1, 1, volume+1);
        GameObject newPlant = Instantiate(new GameObject(), new Vector3(x, 0, y), new Quaternion());
        newPlant.name = System.Enum.GetName(typeof(Plant.PlantType), plant.type);
        GameObject temp = Instantiate(coniferBase, new Vector3(x, 0, y), new Quaternion());
        temp.transform.localScale = scale;
        temp.transform.parent = newPlant.transform;
        for(int i = 1; i < plant.size/2; ++i) {
            temp = Instantiate(coniferCone, new Vector3(x, i*5, y), new Quaternion());
            temp.transform.localScale = scale;
            temp.transform.parent = newPlant.transform;
        }
        return newPlant;
    }

    private void BuildConifer(Plant plant) {

    }
}
