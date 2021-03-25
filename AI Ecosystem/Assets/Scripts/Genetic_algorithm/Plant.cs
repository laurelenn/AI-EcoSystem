using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant {
    public enum PlantType
    {
       Leafy, //avocat, on grass
       Cactus, //cactus, on lava
       Conifer //sapin, on ice
    }

    public PlantType type;
    public int size;
    public int volume;
    public int space;

    private Random rand = new Random();


    public Plant(char[] adn) {
        //interprétation séquence adn en type, taille, volume et espacement
        string adnString = new string(adn);
        // Debug.Log(adnString);
        type = (PlantType)System.Convert.ToInt32(adnString.Substring(0,2), 2);
        if((int)type>2) {
            type = (PlantType)Random.Range(0, 3);
        }
        // Debug.Log(type);
        size = System.Convert.ToInt32(adnString.Substring(2,7), 2);
        // Debug.Log(size);
        volume = System.Convert.ToInt32(adnString.Substring(9,9), 2);
        // Debug.Log(volume);
        space = System.Convert.ToInt32(adnString.Substring(18), 2);
        // Debug.Log(space);
    }

    public GameObject PlantBuilder(FiguierBuilder figuierBuilder, AvocadoBuilder avocadoBuilder, PinesBuilder pinesBuilder, GameObject terrain) {
        //fait des choses avec des prefabs pour construire la plante, en attendant
        //il faudra les mettres tous dans une liste / map pour pouvoir supprimer la plante une fois morte
        //en attendant test avec des phrases :
        string message = "This plant is a " + System.Enum.GetName(typeof(PlantType), type) + " of size " + size.ToString() + ", volume " + volume.ToString() + " and needs " + space.ToString() + " space."; 
        // Debug.Log(message);

        GameObject plant = null;
        float x = Random.Range(-5f, 5f);
        float z = Random.Range(-5f, 5f);
        Vector3 position = new Vector3(x, 0, z);
        
        //switch qui utilise le type de la plante pour utiliser le bon builder
        switch (type)
        {
            case PlantType.Conifer:
                plant = pinesBuilder.buildPine(position, size, volume, terrain);
                break;
            case PlantType.Leafy:
                plant = avocadoBuilder.buildAvocado(position, size, volume, terrain);
                break;

            case PlantType.Cactus:
                plant = figuierBuilder.buildFiguier(position, size, volume, terrain);
                break;
            
            default:
                plant = avocadoBuilder.buildAvocado(position, size, volume, terrain);
                break;
        }
        //rajouter component PlantInfo à la plante créée
        plant.AddComponent<PlantInfo>();
        plant.GetComponent<PlantInfo>().plant = this;

        return plant;
    }

}
