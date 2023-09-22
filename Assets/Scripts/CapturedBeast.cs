using UnityEngine;
using UnityEngine.AI;

public class CapturedBeast : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform player;
    public static int activatedUnits = 0;

    private void Awake()
    {
        transform.GetComponentInParent<CellController>().OnCellOpen += CellOpenHandler;
    }

    private void CellOpenHandler()
    {
        agent = gameObject.AddComponent<NavMeshAgent>();
        agent.enabled = true;

    }

    private void Update()
    {
        if (agent != null)
        {
            // Вычисляем позицию в сетке на основе номера активированного юнита
            int row = activatedUnits / 3;  // Предположим, что у нас 3 колонны
            int col = activatedUnits % 3;

            Vector3 targetPosition = player.position + new Vector3(row * 2, 0, col * 2);
            agent.SetDestination(targetPosition);
        }
    }

    private void OnDestroy()
    {
        // Уменьшаем счетчик активированных юнитов, если юнит уничтожается
        activatedUnits--;
    }
}
