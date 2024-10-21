using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public TMP_Text foodAmountTxt;
    public GameObject heartfill3;
    public GameObject heartfill2;
    public GameObject heartfill1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (PlayerManager.instance.playerStats.health < 3 && PlayerManager.instance.playerStats.health > 0)
            {
                PlayerManager.instance.playerStats.health++;
                ResourceManager.instance.carriedFood--;
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
                PlayerManager.instance.playerStats.health--;
        }
        foodAmountTxt.text ="" + ResourceManager.instance.carriedFood;
        switch(PlayerManager.instance.playerStats.health)
        {
            case 3:
                heartfill3.SetActive(true);
                break;
            case 2:
                heartfill3.SetActive(false);
                heartfill2.SetActive(true);
                break;       
            case 1:
                heartfill2.SetActive(false);
                heartfill1.SetActive(true);
                break;
            case <= 0:
                heartfill1.SetActive(false);
                SceneManager.LoadScene("World");
                ResourceManager.instance.NextDay();
                break;
                default:

                break;

        }
    }
}
