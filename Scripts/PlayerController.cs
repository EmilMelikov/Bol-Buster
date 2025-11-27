using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа
    public float lookSpeed = 2f; // Скорость поворота камеры
    public Transform playerCamera; // Ссылка на камеру

    private CharacterController characterController;
    private float verticalRotation = 0f;

    public float jumpForce = 5f; // Сила прыжка
    private Rigidbody rb;
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    public float Health = 10;
    public Slider slider; // Слайдер, который мы будем заполнять
    public float fillAmount = 0.1f; // Значение, на которое будет увеличиваться слайдер каждые 2 секунды
    public float fillInterval = 2f; // Интервал заполнения в секундах

    public GameObject panelGameOver;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        RotateCamera();
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0; // Сбросить скорость падения при приземлении
        }

        // Движение по горизонтали
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);

        // Прыжок
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Применение гравитации
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            float damage = PlayerPrefs.GetFloat("Урон" + "Шутанчик" + "parameter");
                TakeDamage(damage);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Ghost"))
        {
            float damage = PlayerPrefs.GetFloat("Урон" + "Призрак" + "parameter");
                TakeDamage(damage);
        }
        if (collision.CompareTag("Dead"))
        {
                TakeDamage(100);
        }
        if (collision.CompareTag("Finish"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(1);
        }
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        slider.value += damage/10; // Увеличиваем значение слайдера
        CheckHP();
    }
    public void CheckHP()
    {
        if (Health <= 0)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            panelGameOver.SetActive(true);
        }
    }
    void RotateCamera()
    {
        if (Input.GetMouseButton(1)) // Проверяем, нажата ли правая кнопка мыши
        {
            float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f); // Ограничиваем вертикальный угол

            playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0, 0); // Поворачиваем камеру
            transform.Rotate(Vector3.up * mouseX); // Поворачиваем персонажа
        }
    }
}
