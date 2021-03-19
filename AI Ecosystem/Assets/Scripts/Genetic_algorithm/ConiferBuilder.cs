using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConiferBuilder : MonoBehaviour
{
    [SerializeField] private GameObject trunk;
    [SerializeField] private GameObject leaves;
    [SerializeField] private Transform pt1;
    [SerializeField] private Transform pt2;

    void Start()
    {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("hey!");
        }
    }

    public void buildConifer(int height, int volume)
    {

    }
}
