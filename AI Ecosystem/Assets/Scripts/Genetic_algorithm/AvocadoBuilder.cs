using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvocadoBuilder : MonoBehaviour {

    [SerializeField] GameObject leaves;

    // void Start(){ //TEST
    //     buildAvocado(new Vector3(-2050, 0, 110),100,300);
    //     buildAvocado(12,200);
    // }

    public void buildAvocado(int height, int volume){ // Position = (0,0,0)
        // Height : 0_127
        // Volume : 0_511

        int heightAvocado =(int)((height+10)/10); // Number of ranges - Between 1_12
        int volumeAvocado = (int)((volume+100)/100); // Between 1 and 6 leaves by range
        int angle = (int)(360/volumeAvocado);

        GameObject plant = new GameObject("Avocado_Plant");
        //plant.transform.parent = terrainX?transform; --> Passer gameobject en paramètre de la fonction si besoin.

        for (int i=0; i<heightAvocado; i++){ // Each Range + 1.5y
            GameObject range = new GameObject("Range_"+i);
            range.transform.parent=plant.transform;
            range.transform.position = new Vector3 (0, 1.5f*i, 0);

            for (int j=0; j<volumeAvocado; j++){ // Each Leaves YRotation = 0+angle - Child of Range_i
                Quaternion angleLeaf = Quaternion.Euler(-90, angle*j, 0);
                GameObject leaf = Instantiate(leaves, range.transform.position, angleLeaf, range.transform);
                leaf.transform.name = "Leaf_"+j;
                int scaleLeaf = 50+50*(heightAvocado-i);
                leaf.transform.localScale = new Vector3(scaleLeaf,scaleLeaf,150);
                leaf.SetActive(true);
            }
            int rotate = Random.Range(10, 170);
            range.transform.rotation = Quaternion.Euler(0, rotate, 0);
        }
    }

    public void buildAvocado(Vector3 positionPlant, int height, int volume){
        int heightAvocado =(int)((height+10)/10);
        int volumeAvocado = (int)((volume+100)/100); 
        int angle = (int)(360/volumeAvocado);

        GameObject plant = new GameObject("Avocado_Plant");
        plant.transform.position = positionPlant;
        //plant.transform.parent = terrainX.transform; --> Passer gameobject en paramètre de la fonction si besoin.

        for (int i=0; i<heightAvocado; i++){
            GameObject range = new GameObject("Range_"+i);
            range.transform.parent=plant.transform;
            range.transform.position = new Vector3 (0, 1.5f*i, 0);

            for (int j=0; j<volumeAvocado; j++){
                Quaternion angleLeaf = Quaternion.Euler(-90, angle*j, 0);
                GameObject leaf = Instantiate(leaves, range.transform.position, angleLeaf, range.transform);
                leaf.transform.name = "Leaf_"+j;
                int scaleLeaf = 50+50*(heightAvocado-i);
                leaf.transform.localScale = new Vector3(scaleLeaf,scaleLeaf,150);
                leaf.SetActive(true);
            }
            int rotate = Random.Range(10, 170);
            range.transform.rotation = Quaternion.Euler(0, rotate, 0);
        }
    }
}