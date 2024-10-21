using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public TMP_Text foodAmountTxt;
    public GameObject heartfill3;
    public GameObject heartfill2;
    public GameObject heartfill1;
    public GameObject extractMenu;
    public TMP_Text cashPickedUpTxt;
    public TMP_Text foodPickedUpTxt;
    public TMP_Text waterPickedUpTxt;
    public Button noButton;

    private void Start()
    {
        AudioManager.instance.AddBGMClip("GameAudio", AudioManager.instance.audioClips[1]);
        AudioManager.instance.PlayBGM("GameAudio", 0.05f, true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (PlayerManager.instance.playerStats.health < 3 && PlayerManager.instance.playerStats.health > 0 && PlayerManager.instance.playerFood >0)
            {
                PlayerManager.instance.playerStats.health++;
                PlayerManager.instance.playerFood--;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) || EnemyManager.instance.enemiesKilled ==5)
        {
                Time.timeScale = 0;
                extractMenu.SetActive(true);
                if(EnemyManager.instance.enemiesKilled == 5)
                {
                noButton.interactable = false;
                }
                
        }
        if(extractMenu.activeSelf)
        {
            ResourceDisplay();
        }
        foodAmountTxt.text ="" + PlayerManager.instance.playerFood;
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
    public void ResourceDisplay()
    {
        cashPickedUpTxt.text = PlayerManager.instance.playerCash.ToString();
        foodPickedUpTxt.text = PlayerManager.instance.playerFood.ToString();
        waterPickedUpTxt.text = PlayerManager.instance.playerWater.ToString();
    }
    public void Yes()
    {
        PlayerManager.instance.Extract();
        SceneManager.LoadScene("World");
    }
    public void No()
    {
        Time.timeScale = 1;
        extractMenu.SetActive(false);
    }
}
