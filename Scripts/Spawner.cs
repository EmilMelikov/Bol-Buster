using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public string SpawnType;
    public GameObject spawnableObjects; // Описание объектов, которые можно спавнить
    public Transform[] spawnPos;
    public float delay;
    public float total;
    private void Start()
    {

            if (SpawnType == "Шутанчик")
            {
                total = PlayerPrefs.GetFloat("Враг" + SpawnType + "parameter");
            }
            else if (SpawnType == "Ракетка")
            {
            total = PlayerPrefs.GetFloat("Враг" + SpawnType + "parameter");
            }
            else if (SpawnType == "Призрак")
            {
                total = PlayerPrefs.GetFloat("Враг" + SpawnType + "parameter");
            }
            else if (SpawnType == "Боб")
            {
                total = PlayerPrefs.GetFloat("Враг" + SpawnType + "parameter");
            }
            else if (SpawnType == "Подрывалка")
            {
                total = PlayerPrefs.GetFloat("Враг" + SpawnType + "parameter");
            }
            else if (SpawnType == "Собака-Кусака")
            {
                total = PlayerPrefs.GetFloat("Враг" + SpawnType + "parameter");
            }

        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (total > 0)
        {
                // Ждем задержку до спавна
                yield return new WaitForSeconds(delay);
            int random = Random.Range(0, spawnPos.Length);
            // Спавним объект в рандомной позиции
            Instantiate(spawnableObjects, spawnPos[random].position , Quaternion.identity);
            total--;
        }
    }
}