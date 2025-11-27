using System.Collections;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public string nameEnemy;
    public GameObject bulletPrefab; // Префаб пули
    public Transform shootingPoint; // Точка, из которой будут вылетать пули
    public float bulletSpeed = 20f; // Скорость пули
    public float reload;
    public float lifeTime;
    public bool bullet;

    void Start()
    {
        if (nameEnemy == "Шутанчик")
        {
            reload = PlayerPrefs.GetFloat("Скорость стрельбы" + nameEnemy + "parameter");
        }
        else if (nameEnemy == "Собака-Кусака")
        {
            reload = PlayerPrefs.GetFloat("Скорость стрельбы" + nameEnemy + "parameter");
        }
        // Запускаем корутину стрельбы
        StartCoroutine(ShootAutomatically());
    }

    IEnumerator ShootAutomatically()
    {
        while (true) // Бесконечный цикл для автоматической стрельбы
        {
            Shoot(); // Вызываем метод стрельбы
            yield return new WaitForSeconds(reload); // Ждем 0.3 секунды
        }
    }
    void Shoot()
    {
        // Создаем пулю
        GameObject craftBullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        Destroy(craftBullet, lifeTime);
        if (bullet)
            {
                // Получаем компонент Rigidbody и задаем скорость
                Rigidbody rb = craftBullet.GetComponent<Rigidbody>();
                if (rb != null)
                    {
                        rb.velocity = shootingPoint.forward * bulletSpeed; // Устанавливаем скорость пули
                    }
                // Опционально: уничтожаем пулю через некоторое время, чтобы не загромождать сцену
                
            }
    }
}
