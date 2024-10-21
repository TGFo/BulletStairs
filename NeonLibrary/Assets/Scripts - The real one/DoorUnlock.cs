using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public GameObject[] doors = new GameObject[5];
    public bool[] doorRelock = new bool[5];

    public void Update()
    {
        
            switch (EnemyManager.instance.enemiesKilled)
            {
                case 0:
                    
                    break;
                case 1:
                if (doorRelock[0] ==false)
                {
                    //PlayerManager.instance.roomOpen[0].SetActive(true);
                    doors[0].SetActive(false);
                    //PlayerManager.instance.roomClosed[0].SetActive(false);

                }
                else
                {
                    
                }
                    break;
                case 2:
                if (doorRelock[1] == false)
                {
                    doors[1].SetActive(false);
                    //PlayerManager.instance.roomOpen[1].SetActive(true);
                    //PlayerManager.instance.roomClosed[1].SetActive(false);
                }
                break;
                case 3:
                if (doorRelock[2] == false)
                {
                    doors[2].SetActive(false);
                    //PlayerManager.instance.roomOpen[2].SetActive(true);
                    //PlayerManager.instance.roomClosed[2].SetActive(false);
                }
                break;
                case 4:
                if (doorRelock[3] == false && doorRelock[4] == false)
                {
                    doors[3].SetActive(false);
                    doors[4].SetActive(false);
                    //PlayerManager.instance.roomOpen[3].SetActive(true);
                    //PlayerManager.instance.roomOpen[4].SetActive(true);
                    //PlayerManager.instance.roomClosed[3].SetActive(false);
                    //PlayerManager.instance.roomClosed[4].SetActive(false);
                }
                break;
                default:
                    break;
            }
        
    }
}
