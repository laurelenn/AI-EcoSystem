using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant {
    public enum PlantType
    {
       Conifer,
       Leafy,
       Cactus
    }

    public PlantType type;
    public int size;
    public int volume;
    public int space;
    //modèles 
    // public GameObject coniferBase;
    // public GameObject coniferCone;

    public Plant(char[] adn) {
        //interprétation séquence adn en type, taille, volume et espacement
        string adnString = new string(adn);
        Debug.Log(adnString);
        type = (PlantType)System.Convert.ToInt32(adnString.Substring(0,2), 2);
        Debug.Log(type);
        size = System.Convert.ToInt32(adnString.Substring(2,7), 2);
        Debug.Log(size);
        volume = System.Convert.ToInt32(adnString.Substring(9,9), 2);
        Debug.Log(volume);
        space = System.Convert.ToInt32(adnString.Substring(18), 2);
        Debug.Log(space);
    }

    public GameObject PlantBuilder() {
        //fait des choses avec des prefabs pour construire la plante, en attendant
        //il faudra les mettres tous dans une liste / map pour pouvoir supprimer la plante une fois morte
        //en attendant test avec des phrases :
        string message = "This plant is a " + System.Enum.GetName(typeof(PlantType), type) + " of size " + size.ToString() + ", volume " + volume.ToString() + " and needs " + space.ToString() + " space."; 
        Debug.Log(message);
        
        //switch qui utilise le type de la plante pour utiliser le bon builder
        //rajouter component PlantInfo à la plante créée
        Debug.Log("Done");

        GameObject newPlant = null; // temporaire
        return newPlant;
    }

}
