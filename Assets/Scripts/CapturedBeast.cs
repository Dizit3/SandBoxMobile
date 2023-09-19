using UnityEngine;
using UnityEngine.AI;

public class CapturedBeast : MonoBehaviour
{

    private NavMeshAgent agent;
    [SerializeField] private Transform player;
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
        agent.SetDestination(player.position + new Vector3(2,0,2));
    }

}
