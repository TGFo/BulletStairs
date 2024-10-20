using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapUI : MonoBehaviour
{
    public TMP_Text foodTxt;
    public TMP_Text waterTxt;
    public TMP_Text cashText;
    public void LoadExtractionLevel(int level)
    {
        SceneManager.LoadScene("Level");
    }
    private void Update()
    {
        foodTxt.text = ResourceManager.instance.globalFood.ToString();
        waterTxt.text = ResourceManager.instance.globalWater.ToString();
        cashText.text = ResourceManager.instance.globalCash.ToString();
    }
}
