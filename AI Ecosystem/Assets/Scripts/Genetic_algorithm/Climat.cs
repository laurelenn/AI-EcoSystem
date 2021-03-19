using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climat : MonoBehaviour {

    GameObject planet;
    int[] favoriteAttribute = new int[4];
    int planetBiom; // 0 = Grass | 1 = Lava | 2 = Ice
    int planetSize; // Between [5;30] 
    int planetDistance; // Between [20;80]
    int planetHumidity; // Between [0-100]

    // type de plante (2), hauteur (7), volume(9), espacement(6)
    //      [0,2]        , [0, 127]   , [0, 511] ,   [0, 63]
    //0 sapin
    //1 avocat
    //2 cactus

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
        return (int)((planetHumidity*2+planetDistance)/2);
    }

    int FavoriteVolume(){
        return (int)((planetBiom+1)*10+planetHumidity-3);
    }

    int FavoriteSpread(){
        return planetSize*2;
    }

    public string AttributeToBit(){
        string dna = "";
        dna+= System.Convert.ToString(favoriteAttribute[0], 2);
        dna+= System.Convert.ToString(favoriteAttribute[1], 2);
        dna+= System.Convert.ToString(favoriteAttribute[2], 2);
        dna+= System.Convert.ToString(favoriteAttribute[3], 2);
        return dna;
    }
}