using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string nameEnemy;
    private Transform player; // Ссылка на игрока
    public float moveSpeed; // Скорость движения противника
    public float rotationSpeed; // Скорость поворота противника
    public float lifeTime;
    public bool follow;
    public bool ghost;
    public bool rocketMan;
    private Rigidbody rb;
    public GameObject ghostObject;

    private void Start()
    {

            if (nameEnemy == "Шутанчик")
            {
                rb = GetComponent<Rigidbody>();
                moveSpeed = PlayerPrefs.GetFloat("Скорость перемещения" + nameEnemy + "parameter");
                if(PlayerPrefs.GetFloat("Научить летать" + nameEnemy + "parameter") < 2)
                    rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            }
            else if (nameEnemy == "Ракетка")
            {
                lifeTime = PlayerPrefs.GetFloat("Здоровье" + nameEnemy + "parameter");
            }
            else if (nameEnemy == "Призрак")
            {
                moveSpeed = PlayerPrefs.GetFloat("Скорость перемещения" + nameEnemy + "parameter");
                if (PlayerPrefs.GetFloat("Сделать невидимым" + nameEnemy + "parameter") < 2)
                    ghostObject.SetActive(false);
            }
            else if (nameEnemy == "Боб")
            {
                lifeTime = PlayerPrefs.GetFloat("Здоровье" + nameEnemy + "parameter");
            }
            else if (nameEnemy == "Собака-Кусака")
            {
                lifeTime = PlayerPrefs.GetFloat("Здоровье" + nameEnemy + "parameter");
            }
            else if (nameEnemy == "Подрывалка")
            {
                moveSpeed = PlayerPrefs.GetFloat("Скорость перемещения" + nameEnemy + "parameter");
            }

   player = GameObject.FindWithTag("Player").transform;
        Destroy(gameObject,lifeTime);
    }
    void Update()
    {
        if (follow)
            FollowI();
        if (ghost)
            FollowGhost();
        if (rocketMan)
            FollowRocket();
    }
    void FollowRocket()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    void FollowI()
    {
        // Вычисляем направление к игроку
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // Игнорируем вертикальную составляющую

        // Если противник находится в пределах видимости (например, 10 единиц)
        if (direction.magnitude > 1f)
        {
            // Поворачиваем противника к игроку
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Двигаем противника в сторону игрока
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
    void FollowGhost()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        // Двигаем бомбу в направлении игрока
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
