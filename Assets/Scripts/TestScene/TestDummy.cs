using UnityEngine;
using UnityEngine.AI;

public class TestDummy : MonoBehaviour
{
    private NavMeshAgent agent;

    private GameObject targetFlag;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        targetFlag = GameObject.FindGameObjectWithTag("Flag");
    }

    private void Update()
    {
        agent.SetDestination(targetFlag.transform.position);
    }

}
