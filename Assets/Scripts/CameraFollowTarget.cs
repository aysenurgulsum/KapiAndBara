using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    void LateUpdate()
    {
        if (player1 && player2)
        {
            Vector3 center = (player1.position + player2.position) / 2f;
            transform.position = new Vector3(center.x, center.y, transform.position.z);
        }
    }
}
