using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawRope : MonoBehaviour
{
    public Transform target;
    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.green;
        lr.endColor = Color.green;
    }

    void Update()
    {
        if (target != null)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, target.position);
        }
    }
}
