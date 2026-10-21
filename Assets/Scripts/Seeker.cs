using UnityEngine;

public class Seeker : MonoBehaviour
{
    public Transform target;
    public float forceMultiplier = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // FixedUpdate is called once per std interval
    void FixedUpdate()
    {
        //find out where jaiden is coming from jeremy
        Vector3 targetOffset = target.position - transform.position;
        Vector3 targetDirection = Vector3.Normalize(targetOffset);

        GetComponent<Rigidbody>().AddForce(targetDirection * forceMultiplier);
    }
}
