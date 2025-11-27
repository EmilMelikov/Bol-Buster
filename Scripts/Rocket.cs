using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Transform player; // Ссылка на игрока
    public float moveSpeed; // Скорость движения
    public int damage;
    private void Start()
    {
        float damage = PlayerPrefs.GetFloat("Урон" + "Ракетка" + "parameter");
        player = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        FollowGhost();
    }
    void FollowGhost()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        // Двигаем бомбу в направлении игрока
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider collision)
    {
            if (collision.CompareTag("Player"))
            {
                PlayerController Player = collision.GetComponent<PlayerController>();
                if (Player != null)
                {
                    Player.TakeDamage(damage);
                    Destroy(gameObject);
                }
            }
    }
}
