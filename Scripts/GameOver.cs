using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using YG;
using System;

public class GameOver : MonoBehaviour
{
    public GameObject panel;
    private bool isSpawning = true;
    public GameObject panelWin;
    public TextMeshProUGUI profitText;
    private float profit;
    private float profitShoot;
    private float profitRocket;
    private float profitGhost;
    private float profitBob;
    private float profitKusaka;
    private float profitBoom;
    void Start()
    {
        profitShoot = PlayerPrefs.GetFloat("profit" + "Шутанчик");
        profitRocket = PlayerPrefs.GetFloat("profit" + "Ракетка");
        profitGhost = PlayerPrefs.GetFloat("profit" + "Призрак");
        profitBob = PlayerPrefs.GetFloat("profit" + "Боб");
        profitKusaka = PlayerPrefs.GetFloat("profit" + "Собака-Кусака");
        profitBoom = PlayerPrefs.GetFloat("profit" + "Подрывалка");
        profit = profitShoot + profitRocket + profitGhost + profitBob + profitKusaka + profitBoom;
        profitText.text = "Прибыль: " + profit;
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(10);
            // Проверяем, есть ли еще враги на сцене
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                isSpawning = false;
                panelWin.SetActive(true);
                yield break; // Выходим из корутины
            }
            
        }
    }
    public void Win()
    {
        if (profit > PlayerPrefs.GetFloat("liderProfit"))
        {
            int intProfit = Convert.ToInt32(profit);
            YandexGame.NewLeaderboardScores("lider", intProfit);
            PlayerPrefs.SetFloat("LiderProfit", profit);
        }
        profit = profit + PlayerPrefs.GetFloat("money");
        PlayerPrefs.SetFloat("money", profit);
        SceneManager.LoadScene(1);
    }
    public void GameOverButton()
    {
        //Добавить рекламу
        //
        //
        //
        //
        profit = 20 + PlayerPrefs.GetFloat("money");
        PlayerPrefs.SetFloat("money", profit);
        YandexGame.FullscreenShow();
        SceneManager.LoadScene(1);
    }
    public void ClosePanel()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        panel.SetActive(false);
    }
}
