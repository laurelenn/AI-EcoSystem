using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinesBuilder : MonoBehaviour
{
    [SerializeField] GameObject pineLeaves;


    public GameObject buildPine(int height, int volume)
    { // Position = (0,0,0)
        return buildPine(new Vector3(0, 0, 0), height, volume);
    }

    public GameObject buildPine(Vector3 positionPlant, int height, int volume)
    {
        int heightPine = (int)((height + 10) / 7);
        int volumePine = (int)((volume + 100) / 100);
        int angle = (int)(360 / (volumePine + 1));

        GameObject plant = new GameObject("Conifer_Plant");
        plant.transform.position = positionPlant;

        for (int i = 0; i < heightPine; i++)
        {
            //position in height
            Vector3 newPos = new Vector3(plant.transform.position.x, 2f * i + 3, plant.transform.position.z);
            Quaternion angleLeaf = Quaternion.Euler(-90, angle * i, 0);
            GameObject leaf = Instantiate(pineLeaves, newPos, angleLeaf, plant.transform);
            leaf.transform.name = "Leaf_" + i;
            //scaling
            int scaleLeaf = 10 * (heightPine - i + 1) * (volumePine + 1);
            leaf.transform.localScale = new Vector3(scaleLeaf, scaleLeaf, 150);
            leaf.SetActive(true);
        }

        return plant;
    }
}
