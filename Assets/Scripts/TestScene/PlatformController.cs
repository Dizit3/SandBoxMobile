using UnityEngine;

public class PlatformStorage : MonoBehaviour
{
    public int rows = 2;  // Количество рядов в хранилище
    public int columns = 2;  // Количество колонн в хранилище
    public float spacing = 1.0f;  // Расстояние между объектами в хранилище

    private GameObject[,] storageGrid;  // Двумерный массив для хранения объектов на платформе

    void Start()
    {
        storageGrid = new GameObject[rows, columns];  // Инициализация хранилища
    }

    // Метод для изъятия предмета с платформы
    public GameObject TakeItem(Vector3 unitPosition)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (storageGrid[i, j] != null)  // Проверяем, есть ли предмет в ячейке
                {
                    GameObject item = storageGrid[i, j];  // Получаем объект из ячейки
                    storageGrid[i, j] = null;  // Освобождаем ячейку
                    item.GetComponent<Rigidbody>().isKinematic = false;  // Включаем физику для объекта
                    item.transform.parent = null;  // Убираем родительский объект
                    return item;  // Возвращаем объект
                }
            }
        }
        return null;  // Если пусто, возвращаем null
    }

    // Метод для размещения предмета на платформе
    public bool PlaceItem(GameObject item)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (storageGrid[i, j] == null)  // Проверяем, свободна ли ячейка
                {
                    storageGrid[i, j] = item;  // Размещаем объект в ячейке
                    Vector3 itemPosition = transform.position + new Vector3(i * spacing, 2f, j * spacing);  // Вычисляем позицию для объекта
                    item.transform.position = itemPosition;  // Перемещаем объект
                    item.transform.parent = transform;  // Устанавливаем эту платформу как родительский объект для объекта
                    item.GetComponent<Rigidbody>().isKinematic = true;  // Выключаем физику для объекта
                    return true;  // Успешно разместили объект
                }
            }
        }
        return false;  // Хранилище полно
    }
}