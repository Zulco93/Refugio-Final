using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // El CameraTarget del jugador
    public Vector2 sensitivity = new Vector2(100f, 100f);
    public Vector2 rotation = Vector2.zero;
    public float distance = 4f;
    public float height = 2f;

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity.x * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity.y * Time.deltaTime;

        rotation.x += mouseX;
        rotation.y -= mouseY;
        rotation.y = Mathf.Clamp(rotation.y, -30f, 60f);

        Quaternion rot = Quaternion.Euler(rotation.y, rotation.x, 0);
        Vector3 offset = rot * new Vector3(0, 0, -distance);

        transform.position = target.position + Vector3.up * height + offset;
        transform.LookAt(target.position + Vector3.up * height);
    }
}
