using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public Rigidbody SpherPrefab;
    public Transform cam;
    public float initalSpeed = 1f;
    
    void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Rigidbody SphereInstance;
            SphereInstance = Instantiate(SpherPrefab, cam.position, cam.rotation) as Rigidbody;
        }
        if(Input.GetMouseButtonDown(1))
        {
            Rigidbody SphereInstance;
            SphereInstance = Instantiate(SpherPrefab, cam.position, cam.rotation) as Rigidbody;
            SphereInstance.linearVelocity = initalSpeed*cam.forward;
        }
    }
}