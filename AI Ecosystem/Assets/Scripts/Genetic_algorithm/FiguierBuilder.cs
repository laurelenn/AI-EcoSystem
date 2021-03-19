using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguierBuilder : MonoBehaviour {

    [SerializeField] GameObject leaves;

     void Start(){ //TEST
    //     buildFiguier(new Vector3(-2050, 0, 110),100,300);
    buildFiguier(125,300);
     }


        public void buildFiguier(int height, int volume){ // Position = (0,0,0)
        // Height : 0_127
        // Volume : 0_511

        int heightFiguier =(int)((height+25)/25); // Number of ranges - Between 1_5
        int volumeFiguier = (int)((volume+100)/100); // Between 1 and 6 leaves by range
        int angle = (int)(360/volumeFiguier);
        int prec = 0;

        GameObject plant = new GameObject("Figuier_Plant");
        //plant.transform.parent = terrainX?.transform; --> Passer gameobject en paramètre de la fonction si besoin.
        Debug.Log("Nbranges : "+heightFiguier);
        for (int i=0; i<heightFiguier; i++){ // Each Range + 1.5y
            int scaleRange = 50*heightFiguier-50*i;
            Debug.Log(scaleRange);
            Vector3 positionRange;
            if (i!=0){
                positionRange = new Vector3(0, prec+heightFiguier+1-i, 0);
                prec = prec+heightFiguier+1-i;
                } else {
                positionRange = new Vector3(0, 0, 0);
                prec = 0;
            }
            GameObject range = Instantiate(leaves, positionRange, Quaternion.Euler(-90, 0, 0), plant.transform);
            range.transform.name = "Range_"+i;
            range.transform.localScale = new Vector3(scaleRange,scaleRange,scaleRange);
            range.SetActive(true);

            // for (int j=0; j<volumeFiguier; j++){ // Each Leaves YRotation = 0+angle - Child of Range_i 
            //     Quaternion angleLeaf = Quaternion.Euler(-45, 90, 0);
            //     float diffLeaves = range.transform.position.y/4f;
            //     Vector3 positionLeaf = new Vector3(range.transform.position.x, range.transform.position.y+0.5f, range.transform.position.z);
            //     GameObject leaf = Instantiate(leaves, positionLeaf, angleLeaf, range.transform);
            //     leaf.transform.name = "Leaf_"+j;
            //     leaf.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            //     leaf.SetActive(true);
            // }
            //int rotate = Random.Range(10, 360);
            //range.transform.rotation = Quaternion.Euler(0, rotate, 0);
        }
    }
}