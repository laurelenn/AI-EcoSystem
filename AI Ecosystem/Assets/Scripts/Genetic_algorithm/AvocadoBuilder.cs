using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvocadoBuilder : MonoBehaviour {

    [SerializeField] GameObject leaves;

    void Start(){

    }

    void Update(){

    }

    public void buildAvocado(int height, int volume){
        // Height : 0_127
        // Volume : 0_511

        int heightAvocado =(int)((height+10)/10) ; // Number of ranges - Between 1_12
        int volumeAvocado = (int)((volume+100)/100); // Between 1 and 6 leaves by range
        int angle = (int)(360-(360/volumeAvocado)/volumeAvocado);

        //Create gameObject "Avocado_Plant"
        for (int i=0; i<heightAvocado; i++){ // Each Range + 1.5y // scale X, Y = 50+50*(heightAvocado-i)
        //Create gameObject Range_i
            for (int j=0; j<volumeAvocado; j++){ // Each Leaves YRotation = 0+angle - Child of Range_i
                //Instantiate leaves
            }
        }
    }


    public void buildAvocado(Vector3 position, int height, int volume){

    }
}