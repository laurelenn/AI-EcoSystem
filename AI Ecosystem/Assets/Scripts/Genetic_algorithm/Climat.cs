using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climat : MonoBehaviour {

    GameObject planet;
    int[] favoriteAttribute = new int[4];
    int planetBiom; // 0 = Grass | 1 = Lava | 2 = Ice
    int planetSize; // Between [;] 
    int planetDistance; // Between [;]
    int planetHumidity; // Between [0-100]

    // type de plante (2), hauteur (7), volume(9), espacement(6)
    //      [0,2]        , [0, 127]   , [0, 511] ,   [0, 63]

    void Init(GameObject gameobject,  int size, int distance, int humidity, int indexBiom){
        planet = gameobject;
        planetSize = size;
        planetDistance = distance;
        planetHumidity = humidity;
        planetBiom = indexBiom;
    }

 // send planet attribute to climat function
    void ChooseFavoritePlant(){
        favoriteAttribute[0] = FavoriteType();
        favoriteAttribute[1] = FavoriteHeight();
        favoriteAttribute[2] = FavoriteVolume();
        favoriteAttribute[3] = FavoriteSpread();
    }

    int FavoriteType(){
        return planetBiom;
    }

    int FavoriteHeight(){
        return 0;
    }

    int FavoriteVolume(){
        return 0;
    }

    int FavoriteSpread(){
        return 0;
    }

}