using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gain : MonoBehaviour
{
    private float profit = 0;
    public string nameEnemy;
    public TextMeshProUGUI profitText;
    private float profitReload;
    private float profitExclusive1;
    private float profitExclusive2;
    private float profitLife;
    private float profitMoveSpeed;
    private float profitMoveCreate;
    private float profitRadius;
    private float profitEnemy;
    private float profitDamage;
    void Update()
    {
        if (PlayerPrefs.GetFloat("Враг" + nameEnemy + "lvl") > 0)
        {
            if (profitEnemy < PlayerPrefs.GetFloat("Враг" + nameEnemy + "profit") & PlayerPrefs.GetFloat("Враг" + nameEnemy + "lvl") > 0)
                profitEnemy = PlayerPrefs.GetFloat("Враг" + nameEnemy + "profit");
            if (profitReload < PlayerPrefs.GetFloat("Скорость стрельбы" + nameEnemy + "profit") & PlayerPrefs.GetFloat("Скорость стрельбы" + nameEnemy + "lvl") > 0)
                profitReload = PlayerPrefs.GetFloat("Скорость стрельбы" + nameEnemy + "profit");
            if (profitExclusive1 < PlayerPrefs.GetFloat("Разрешить падать" + nameEnemy + "profit") & PlayerPrefs.GetFloat("Разрешить падать" + nameEnemy + "lvl") > 0)
                profitExclusive1 = PlayerPrefs.GetFloat("Разрешить падать" + nameEnemy + "profit");
            if (profitExclusive2 < PlayerPrefs.GetFloat("Сделать невидимым" + nameEnemy + "profit") & PlayerPrefs.GetFloat("Сделать невидимым" + nameEnemy + "lvl") > 0)
                profitExclusive2 = PlayerPrefs.GetFloat("Сделать невидимым" + nameEnemy + "profit");
            if (profitLife < PlayerPrefs.GetFloat("Здоровье" + nameEnemy + "profit") & PlayerPrefs.GetFloat("Здоровье" + nameEnemy + "lvl") > 0)
                profitLife = PlayerPrefs.GetFloat("Здоровье" + nameEnemy + "profit");
            if (profitMoveSpeed < PlayerPrefs.GetFloat("Скорость перемещения" + nameEnemy + "profit") & PlayerPrefs.GetFloat("Скорость перемещения" + nameEnemy + "lvl") > 0)
                profitMoveSpeed = PlayerPrefs.GetFloat("Скорость перемещения" + nameEnemy + "profit");
            if (profitMoveCreate < PlayerPrefs.GetFloat("Скорость строительства" + nameEnemy + "profit") & PlayerPrefs.GetFloat("Скорость строительства" + nameEnemy + "lvl") > 0)
                profitMoveCreate = PlayerPrefs.GetFloat("Скорость строительства" + nameEnemy + "profit");
            if (profitRadius < PlayerPrefs.GetFloat("Площадь поражения" + nameEnemy + "profit") & PlayerPrefs.GetFloat("Площадь поражения" + nameEnemy + "lvl") > 0)
                profitRadius = PlayerPrefs.GetFloat("Площадь поражения" + nameEnemy + "profit");
            if (profitDamage < PlayerPrefs.GetFloat("Урон" + nameEnemy + "profit") & PlayerPrefs.GetFloat("Урон" + nameEnemy + "lvl") > 0)
                profitDamage = PlayerPrefs.GetFloat("Урон" + nameEnemy + "profit");
            if (profit < (profitReload + profitExclusive1 + profitExclusive2 + profitLife + profitMoveSpeed + profitMoveCreate + profitRadius + profitEnemy + profitDamage))
            {
                profit = profitReload + profitExclusive1 + profitExclusive2 + profitLife + profitMoveSpeed + profitMoveCreate + profitRadius + profitEnemy + profitDamage;
                profitText.text = "Прибыль: +" + profit;
                PlayerPrefs.SetFloat("profit" + nameEnemy, profit);
            }
        }
        else
            profitText.text = "Персонаж не разблокирован";
    }
}
