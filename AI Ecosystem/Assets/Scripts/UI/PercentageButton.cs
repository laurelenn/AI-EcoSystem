using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentageButton : MonoBehaviour
{

    private int value; 
    public bool percentage;
    
    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<UnityEngine.UI.Text>().text = transform.parent.gameObject.GetComponent<UnityEngine.UI.Slider>().value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float value = transform.parent.gameObject.GetComponent<UnityEngine.UI.Slider>().value;
        if(percentage){
            this.GetComponent<UnityEngine.UI.Text>().text =  value.ToString() + "%";
        }else{
            this.GetComponent<UnityEngine.UI.Text>().text =  value.ToString();
        }
        
    }
}
