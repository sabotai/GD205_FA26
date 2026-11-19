using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class BasicNav : MonoBehaviour
{
    public Transform destination;
    NavMeshAgent basicAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basicAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        basicAgent.SetDestination(destination.position);
    }
}
