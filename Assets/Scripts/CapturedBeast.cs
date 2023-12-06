using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CapturedBeast : MonoBehaviour
{
    private NavMeshAgent agent;
    private GridPoints grid;

    private GameObject target;


    private void Awake()
    {
        transform.GetComponentInParent<CellController>().OnCellOpen += CellOpenHandler;
        grid = GameObject.FindGameObjectWithTag("PlayerGrid").GetComponent<GridPoints>();
    }

    private void CellOpenHandler()
    {
        agent = gameObject.AddComponent<NavMeshAgent>();
        agent.enabled = true;

        target = grid.AddFolower();
    }

    private void Update()
    {
        if (agent != null && target != null)
        {
            agent.SetDestination(target.transform.position);
        }
    }

    private void OnDestroy()
    {
    }
}
