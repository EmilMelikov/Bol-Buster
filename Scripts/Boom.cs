using System.Collections;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float explosionDelay = 3f; // Время до взрыва
    public float explosionRadius = 5f; // Радиус взрыва
    public float explosionForce = 700f; // Сила взрыва
    public int damage = 50; // Урон игроку
    public GameObject explosionEffect; // Префаб эффекта взрыва

    private void Start()
    {
        explosionRadius = PlayerPrefs.GetFloat("Площадь поражения" + "Подрывалка" + "parameter");
        StartCoroutine(ExplodeAfterDelay());
    }

    private IEnumerator ExplodeAfterDelay()
    {
        // Ждем заданное время
        yield return new WaitForSeconds(explosionDelay);

        // Создаем эффект взрыва
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // Получаем все коллайдеры в радиусе взрыва
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            // Проверяем, является ли объект Rigidbody
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Применяем силу взрыва
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            // Проверяем, является ли объект игроком и наносим урон
            PlayerController Player = collider.GetComponent<PlayerController>();
            if (Player != null)
            {
                Player.TakeDamage(damage);
            }
        }

        // Уничтожаем объект после взрыва
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        // Отображаем радиус взрыва в редакторе
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}