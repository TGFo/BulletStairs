using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.LowLevel;

public class DayCycle : MonoBehaviour
{
    public TMP_Text daysPassedTxt;
    // Start is called before the first frame update
    void Start()
    {
        daysPassedTxt.text = daysPassedTxt.text + "" +ResourceManager.instance.daysPassed;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
