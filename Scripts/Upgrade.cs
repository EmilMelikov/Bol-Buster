using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using YG;
using UnityEngine.SceneManagement;

public class Upgrade : MonoBehaviour
{
    public string nameEnemy;
    public string nameUpdate;
    public float price;
    public float gain;
    private float money;
    public float parameter;
    public Button button;
    public float profit;
    public string exclusive;
    public bool minus;
    public float lvl;
    public float maxLvl;
    public bool reward;


    public TextMeshProUGUI priceText;
    public TextMeshProUGUI gainText;

    private void Start()
    {
        if (!reward)
        {
            if (price < PlayerPrefs.GetFloat(nameUpdate + nameEnemy + "price"))
                price = PlayerPrefs.GetFloat(nameUpdate + nameEnemy + "price");
            if (lvl < PlayerPrefs.GetFloat(nameUpdate + nameEnemy + "lvl"))
                lvl = PlayerPrefs.GetFloat(nameUpdate + nameEnemy + "lvl");
            else if (lvl > PlayerPrefs.GetFloat(nameUpdate + nameEnemy + "lvl"))
                PlayerPrefs.SetFloat(nameUpdate + nameEnemy + "lvl", lvl);
            if (gain < PlayerPrefs.GetFloat(nameUpdate + nameEnemy + "gain"))
                gain = PlayerPrefs.GetFloat(nameUpdate + nameEnemy + "gain");
            if (parameter < PlayerPrefs.GetFloat(nameUpdate + nameEnemy + "parameter"))
                parameter = PlayerPrefs.GetFloat(nameUpdate + nameEnemy + "parameter");
            if (profit < PlayerPrefs.GetFloat(nameUpdate + nameEnemy + "profit"))
                profit = PlayerPrefs.GetFloat(nameUpdate + nameEnemy + "profit");
            UpdatePoint();
            if ((minus == true & parameter < gain) || (maxLvl <= lvl))
                DestroyObject();
            PlayerPrefs.SetFloat(nameUpdate + nameEnemy + "parameter", parameter);
            PlayerPrefs.SetFloat(nameUpdate + nameEnemy + "price", price);
            PlayerPrefs.SetFloat(nameUpdate + nameEnemy + "gain", gain);
            PlayerPrefs.SetFloat(nameUpdate + nameEnemy + "profit", profit);
        }
        else
            gainText.text = nameUpdate;
    }
    private void Update()
    {
        if(!reward)
            UpdateButtonColor();
    }
    void UpdatePoint()
    {
            priceText.text = price.ToString();
            if(nameUpdate != exclusive)
                gainText.text = "+" + gain + " " + nameUpdate + "\n<#FFBF66> +" + profit + " прибыли ";
            else    
            gainText.text = nameUpdate + "\n<#FFBF66> +" + profit + " прибыли ";
    }
    public void UpdateButtonColor()
    {

        money = PlayerPrefs.GetFloat("money");
        if (money < price)
        {
            ColorBlock colorBlock = button.colors;
            colorBlock.normalColor = Color.gray; // Устанавливаем серый цвет
            button.colors = colorBlock;
            button.interactable = false; // Делаем кнопку неактивной
        }
        else
        {
            ColorBlock colorBlock = button.colors;
            colorBlock.normalColor = Color.green;
            button.colors = colorBlock;
            button.interactable = true; // Делаем кнопку активной
        }
    }
    public void BuyUpdate()
    {
        if (!reward)
        {
            money -= price;
            if(minus == false)
                parameter += gain;
            else
                parameter -= gain;
            price *= 2;
            gain *= 2;
            profit *= 2;
            lvl++;
            PlayerPrefs.SetFloat("money", money);
            PlayerPrefs.SetFloat(nameUpdate + nameEnemy + "lvl", lvl);
            PlayerPrefs.SetFloat(nameUpdate + nameEnemy + "parameter", parameter);
            PlayerPrefs.SetFloat(nameUpdate + nameEnemy + "price", price);
            PlayerPrefs.SetFloat(nameUpdate + nameEnemy + "gain", gain);
            PlayerPrefs.SetFloat(nameUpdate + nameEnemy + "profit", profit);
            UpdatePoint();
            if ((minus == true & parameter < gain) || (maxLvl <= lvl))
                DestroyObject();
        }
        else
        {
            ExampleOpenRewardAd(1);
            SceneManager.LoadScene(0);
        }

    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
    void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }
    void Rewarded(int id)
    {
            PlayerPrefs.DeleteKey(nameUpdate + nameEnemy + "lvl");
            PlayerPrefs.DeleteKey(nameUpdate + nameEnemy + "parameter");
            PlayerPrefs.DeleteKey(nameUpdate + nameEnemy + "price");
            PlayerPrefs.DeleteKey(nameUpdate + nameEnemy + "gain");
            PlayerPrefs.DeleteKey(nameUpdate + nameEnemy + "profit");
    }
}
