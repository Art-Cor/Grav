using UnityEngine;

public class Trial : MonoBehaviour
{
    public float updateInterval = 0.1f;
    public int maxPositions = 50;

    private LineRenderer lineRenderer;
    private float timer;
    private Vector3 lastPosition;
    private Rigidbody rb;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.positionCount = 0;
        
        lastPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(0, 0, 5);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= updateInterval)
        {
            lineRenderer.positionCount++;
        	lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);
            timer = 0f;
        }

        if (lineRenderer.positionCount > maxPositions)
        {
            for (int i = 1; i < lineRenderer.positionCount; i++)
        	{
            	lineRenderer.SetPosition(i - 1, lineRenderer.GetPosition(i));
        	}
        	lineRenderer.positionCount--;
        }
    }
}
