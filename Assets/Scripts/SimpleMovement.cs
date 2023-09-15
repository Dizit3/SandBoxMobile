using UnityEngine;

public class SimpleMovement : MonoBehaviour
{

    public float speed = 5.0f; // Скорость движения
    private Rigidbody rb;

    // Инициализация
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Обновление физических компонентов
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Получаем движение по горизонтали
        float moveVertical = Input.GetAxis("Vertical"); // Получаем движение по вертикали

        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical); // Создаем вектор движения

        rb.velocity = movement * speed; // Применяем движение
    }

}
