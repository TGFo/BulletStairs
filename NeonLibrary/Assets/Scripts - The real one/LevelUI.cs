using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public TMP_Text foodAmountTxt;
    public TMP_Text waterAmountText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foodAmountTxt.text ="" + ResourceManager.instance.carriedFood;
        waterAmountText.text = "" + ResourceManager.instance.carriedWater;
    }
}
