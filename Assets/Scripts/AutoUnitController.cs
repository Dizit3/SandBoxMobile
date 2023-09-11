using UnityEngine;

public enum UnitState
{
    WaitingForInput,
    MovingToTarget,
    PickingItem,
    MovingToStorage,
    DroppingItem
}

public class AutoUnitController : MonoBehaviour
{
    public Transform holdPoint;
    public Transform storagePlatform;
    public float speed = 5.0f;

    private GameObject heldItem = null;
    private UnitState currentState = UnitState.WaitingForInput;
    private Vector3 targetPosition;

    void Update()
    {
        // Обработка кликов мыши
        if (Input.GetMouseButtonDown(0) && currentState == UnitState.WaitingForInput)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point;
                currentState = UnitState.MovingToTarget;
            }
        }

        // Конечный автомат
        switch (currentState)
        {
            case UnitState.WaitingForInput:
                // Ждем клика мыши
                break;

            case UnitState.MovingToTarget:
                MoveToTarget(targetPosition);
                if (IsCloseToTarget(targetPosition))
                {
                    currentState = UnitState.PickingItem;
                }
                break;

            case UnitState.PickingItem:
                // Подбор предмета (допустим, он уже находится в targetPosition)
                PickItem();
                currentState = UnitState.MovingToStorage;
                break;

            case UnitState.MovingToStorage:
                MoveToTarget(storagePlatform.position);
                if (IsCloseToTarget(storagePlatform.position))
                {
                    currentState = UnitState.DroppingItem;
                }
                break;

            case UnitState.DroppingItem:
                DropItem(storagePlatform.GetComponent<PlatformStorage>());
                currentState = UnitState.WaitingForInput;
                break;
        }
    }

    void MoveToTarget(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    bool IsCloseToTarget(Vector3 target)
    {
        return Vector3.Distance(transform.position, target) < 2f;
    }

    void PickItem()
    {
        float searchRadius = 2.5f;  // Радиус поиска вокруг юнита
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, searchRadius);  // Получаем все коллайдеры в радиусе

        foreach (var hitCollider in hitColliders)
        {
            // Проверяем, имеет ли объект нужный тег
            if (hitCollider.gameObject.tag == "Item")
            {
                // Если имеет, то поднимаем его
                heldItem = hitCollider.gameObject;
                heldItem.transform.position = holdPoint.position;
                heldItem.transform.parent = holdPoint;
                heldItem.GetComponent<Rigidbody>().isKinematic = true;  // Делаем объект статичным, чтобы он не падал

                // Выходим из цикла, так как предмет уже найден и поднят
                break;
            }
        }
    }

    void DropItem(PlatformStorage platform)
    {
        if (heldItem != null)
        {
            platform.PlaceItem(heldItem);
            heldItem = null;
        }
    }
}
