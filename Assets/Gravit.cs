using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Gravit : MonoBehaviour
{
    public float gravitationalForce = 1f;
    public float minDistance = 1f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 999999999);

        foreach (Collider collider in colliders)
        {
            if (collider.attachedRigidbody != null && collider.attachedRigidbody != rb)
            {
                Rigidbody otherRb = collider.attachedRigidbody;
                Vector3 direction = transform.position - otherRb.position;
                float distance = direction.magnitude;

                
                if (distance > minDistance)
                {
                    
                    float forceMagnitude = gravitationalForce * (rb.mass * otherRb.mass) / Mathf.Pow(distance, 2);
                    Vector3 force = direction.normalized * forceMagnitude;

                    
                    otherRb.AddForce(force);
                }
            }
        }
    }

    
    void OnDrawGizmosSelected()
    {        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minDistance);
    }
}