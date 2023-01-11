using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{

    private int selectedItem;
    private int extraHealth;
    private int healthRegen;
    private int numCoins;
    public GameObject notEnoughMoney;
    public GameObject alreadyMaxed;


    // Start is called before the first frame update
    void Start()
    {
        extraHealth = PlayerPrefs.GetInt("extraHealth");
        healthRegen = PlayerPrefs.GetInt("healthRegen");
    }

    void Update()
    {
        selectedItem = PlayerPrefs.GetInt("purchase");
        numCoins = PlayerPrefs.GetInt("coins");
    }

    public void BuyItems()
    {
        PlayerPrefs.SetInt("purchase", 0);

        if (selectedItem == 1)
        {
            if (numCoins - 150 >= 0 && extraHealth < 20)
            {
                numCoins -= 150;
                extraHealth += 1;
                PlayerPrefs.SetInt("extraHealth", extraHealth);
                PlayerPrefs.SetInt("coins", numCoins);
            }
            else if (extraHealth == 20)
            {
                alreadyMaxed.SetActive(true);
            }
            else if (numCoins < 150)
            {
                notEnoughMoney.SetActive(true);
            }
            
        }

        if (selectedItem == 2)
        {
            if (numCoins - 100 >= 0 && healthRegen < 15)
            {
                numCoins -= 100;
                healthRegen += 1;
                PlayerPrefs.SetInt("healthRegen", healthRegen);
                PlayerPrefs.SetInt("coins", numCoins);
            }
            else if (healthRegen == 15)
            {
                alreadyMaxed.SetActive(true);
            }
            else if (numCoins <= 100)
            {
                notEnoughMoney.SetActive(true);
            }
        }

        if (selectedItem == 3)
        {
            if (numCoins - 500 >= 0)
            {
                numCoins -= 500;
                PlayerPrefs.SetInt("item3Purchased", 1);
                PlayerPrefs.SetInt("coins", numCoins);
            }
            else
            {
                notEnoughMoney.SetActive(true);
   
            }
        }

        if (selectedItem == 4)
        {
            if (numCoins - 1500 >= 0)
            {
                numCoins -= 1500;
                PlayerPrefs.SetInt("item4Purchased", 1);
                PlayerPrefs.SetInt("coins", numCoins);
            }
            else
            {
                notEnoughMoney.SetActive(true);
   
            }
        }

        if (selectedItem == 5)
        {
            if (numCoins - 1500 >= 0)
            {
                numCoins -= 1500;
                PlayerPrefs.SetInt("item5Purchased", 1);
                PlayerPrefs.SetInt("coins", numCoins);
            }
            else
            {
                notEnoughMoney.SetActive(true);
   
            }
        }

        if (selectedItem == 6)
        {
            if (numCoins - 2500 >= 0)
            {
                numCoins -= 2500;
                PlayerPrefs.SetInt("item6Purchased", 1);
                PlayerPrefs.SetInt("coins", numCoins);
            }
            else
            {
                notEnoughMoney.SetActive(true);
   
            }
        }

        if (selectedItem == 7)
        {
            if (numCoins - 5000 >= 0)
            {
                numCoins -= 5000;
                PlayerPrefs.SetInt("item7Purchased", 1);
                PlayerPrefs.SetInt("coins", numCoins);
            }
            else
            {
                notEnoughMoney.SetActive(true);
            }
        }
    }
    
    public void EquipSkins()
    {
        PlayerPrefs.SetInt("purchase", 0);

        if (selectedItem == 3)
        {
            PlayerPrefs.SetInt("skinEquipped", 1);
        }

        if (selectedItem == 4)
        {
            PlayerPrefs.SetInt("skinEquipped", 2);
        }

        if (selectedItem == 5)
        {
            PlayerPrefs.SetInt("skinEquipped", 3);
        }
        
        if (selectedItem == 6)
        {
            PlayerPrefs.SetInt("skinEquipped", 4);
        }   

        if (selectedItem == 7)
        {
            PlayerPrefs.SetInt("skinEquipped", 5);
        }
    }

    public void UnequipSkins()
    {
        PlayerPrefs.SetInt("purchase", 0);
        PlayerPrefs.SetInt("skinEquipped", 0);
    }

}
