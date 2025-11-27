using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneManagement : MonoBehaviour
{
    public GameObject[] panels; // Массив с вашими панелями (3 панели)
    public TextMeshProUGUI moneyText;
    private float money;
    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        money = PlayerPrefs.GetFloat("money");
        moneyText.text = money.ToString();
    }

    // Метод для переключения на игровую сцену
    public void SwitchScene(int NumScene)
    {
        SceneManager.LoadScene(NumScene);
    }

    // Метод для открытия/закрытия панели по указанному номеру
    public void TogglePanel(int panelIndex)
    {
        // Получаем панель по индексу и переключаем её активность
        for (int i = 0; i < panels.Length; i++)
        {
            if (panelIndex == i)
                panels[i].SetActive(true);
            else
                panels[i].SetActive(false);

        }
    }
}