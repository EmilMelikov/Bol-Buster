using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    public GameObject buildPrefab; // Префаб объекта
    private Transform shootingPoint; // Точка, из которой будут вылетать объекты
    public float reload;
    public float lifeTime;
    public bool bullet;

    void Start()
    {
        reload = PlayerPrefs.GetFloat("Скорость строительства" + "Боб" + "parameter");
        shootingPoint = GameObject.FindWithTag("Player").transform;
        // Запускаем корутину стрельбы
        StartCoroutine(ShootAutomatically());
    }

    IEnumerator ShootAutomatically()
    {
        while (true) // Бесконечный цикл для автоматической стрельбы
        {
            Shoot(); // Вызываем метод стрельбы
            yield return new WaitForSeconds(reload); // Ждем reload секунды
        }
    }
    void Shoot()
    {
        Vector3 spawnPosition = shootingPoint.position + shootingPoint.forward * 2;
        // Создаем объект
        GameObject craftBuild = Instantiate(buildPrefab, new Vector3(spawnPosition.x, spawnPosition.y-0.7f, spawnPosition.z), Quaternion.Euler(-90, shootingPoint.rotation.eulerAngles.y + 90, 0));
        Destroy(craftBuild, lifeTime);
    }
}
