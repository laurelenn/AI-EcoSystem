using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguierBuilder : MonoBehaviour {

    [SerializeField] GameObject leaves;

    // void Start(){ //TEST
    // buildFiguier(new Vector3(-2050, 0, 110),100,300);
    // buildFiguier(50,200);
    // }

    public void buildFiguier(int height, int volume){
        buildFiguier(new Vector3(0, 0, 0),height,volume);
    }

    public void buildFiguier(Vector3 positionPlant, int height, int volume){ // Position = (0,0,0)
        // Height : 0_127
        // Volume : 0_511

        int heightFiguier =(int)((height+25)/25); // Number of leaves - Between 1_5
        int volumeFiguier = (int)((volume+50)/50); // Between 1 and 11 branch
        int angle = (int)(360/volumeFiguier);
        int prec = 0;

        GameObject plant = new GameObject("Figuier_Plant");
        //plant.transform.parent = terrainX?.transform; --> Passer gameobject en paramètre de la fonction si besoin.
        for (int i=0; i<volumeFiguier; i++){
            GameObject branch = new GameObject("Branch_"+i);
            branch.transform.parent=plant.transform;

            for (int j=0; j<heightFiguier; j++){
                int scaleLeaf = 50*heightFiguier-50*j;
                Debug.Log(scaleLeaf);
                Vector3 positionLeaf;
                if (j!=0){
                    positionLeaf = new Vector3(0, prec+heightFiguier+1-j, 0);
                    prec = prec+heightFiguier+1-j;
                    } else {
                    positionLeaf = new Vector3(0, 0, 0);
                    prec = 0;
                }
                int rotate = Random.Range(10, 170);
                GameObject leaf = Instantiate(leaves, positionLeaf, Quaternion.Euler(-90, rotate, 0), branch.transform);
                leaf.transform.name = "Leaf_"+j;
                leaf.transform.localScale = new Vector3(scaleLeaf,scaleLeaf,scaleLeaf);
                leaf.SetActive(true);
                
            }
            prec = 0;

            float scale = Random.Range(0.5f,1);
            int rotateX = Random.Range(-45, -15);
            int rotateY = Random.Range(0, 360);
            branch.transform.rotation = Quaternion.Euler(rotateX, rotateY, 0);
            branch.transform.localScale = new Vector3(scale,scale,1);
        }
    }
}