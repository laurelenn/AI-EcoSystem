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

    public void Init(GameObject gameobject,  int size, int distance, int humidity, int indexBiom){
        planet = gameobject;
        planetSize = size;
        planetDistance = distance;
        planetHumidity = humidity;
        planetBiom = indexBiom;
    }

 // send planet attribute to climat function
    public void ChooseFavoritePlant(){
        favoriteAttribute[0] = FavoriteType();
        favoriteAttribute[1] = FavoriteHeight();
        favoriteAttribute[2] = FavoriteVolume();
        favoriteAttribute[3] = FavoriteSpread();
    }

    int FavoriteType(){
        Debug.Log("planete biom");
        Debug.Log(planetBiom);
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
        string typeStg= System.Convert.ToString(favoriteAttribute[0], 2);
        if(typeStg.Length < 2) {
            typeStg = typeStg.PadLeft(2, '0');
        }
        string heightStg = System.Convert.ToString(favoriteAttribute[1], 2);
        if(heightStg.Length < 7) {
            heightStg = heightStg.PadLeft(7, '0');
        }
        string volStg = System.Convert.ToString(favoriteAttribute[2], 2);
        if(volStg.Length < 9) {
            volStg = volStg.PadLeft(9, '0');
        }
        string spaceStg = System.Convert.ToString(favoriteAttribute[3], 2);
        if(spaceStg.Length < 6) {
            spaceStg = spaceStg.PadLeft(6, '0');
        }
        string dna = typeStg + heightStg + volStg + spaceStg;
        Debug.Log(dna);
        return dna;
    }
}