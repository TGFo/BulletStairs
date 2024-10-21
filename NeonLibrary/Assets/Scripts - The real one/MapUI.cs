using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{
    public TMP_InputField foodInput;
    public TMP_InputField waterInput;
    public TMP_Text foodTxt;
    public TMP_Text waterTxt;
    public TMP_Text cashText;
    public GameObject mapCanvas;
    public GameObject resourceSelectCanvas;
    public GameObject shopCanvas;
    public Button shotgunBtn;
    public TMP_Text validCheckTxt;
    public int foodInputNumber;
    public int waterInputNumber;

   
        
    
    public void ResourceSelection()
    {
        resourceSelectCanvas.SetActive(true);
        if (ResourceManager.instance.shotgunUnlocked == true)
        {
            shotgunBtn.enabled = true;
        }
        else
        {
            shotgunBtn.enabled = false;
        }
        mapCanvas.SetActive(false);

    }
    public void LoadExtractionLevel(int level)
    {
        if ((int.TryParse(foodInput.text, out foodInputNumber) && foodInputNumber >= 0 && foodInputNumber <= ResourceManager.instance.globalFood) && (int.TryParse(waterInput.text, out waterInputNumber) && waterInputNumber >= 0 && waterInputNumber <= ResourceManager.instance.globalWater))
        {
            ResourceManager.instance.globalFood -= foodInputNumber;
            ResourceManager.instance.globalWater -= waterInputNumber;
            ResourceManager.instance.carriedFood = foodInputNumber;
            ResourceManager.instance.carriedWater = waterInputNumber;
            SceneManager.LoadScene("Level");
        }
        else
        {
            validCheckTxt.text = "Please input a positive number\nthat is not a decimal\nalso make sure\nyou have enough resources to take";
        }
            
    }
    public void Start()
    {
        
        resourceSelectCanvas.SetActive(false);
        shopCanvas.SetActive(false);
        mapCanvas.SetActive(true);
        
        
    }
    private void Update()
    {
        foodTxt.text = ResourceManager.instance.globalFood.ToString();
        waterTxt.text = ResourceManager.instance.globalWater.ToString();
        cashText.text =ResourceManager.instance.globalCash.ToString();
        if (Input.GetKeyDown(KeyCode.S)) 
        { 
            mapCanvas.SetActive(false);
            resourceSelectCanvas.SetActive(false);
            shopCanvas.SetActive(true);
            
        }
    }
    public void ConfirmPurchase()
    {
        
        mapCanvas.SetActive(true);
        resourceSelectCanvas.SetActive(false);
        shopCanvas.SetActive(false);
    }
}
