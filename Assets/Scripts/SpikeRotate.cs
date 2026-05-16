using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotateSpeed = 100f;

    [Tooltip("true = quay cùng chiều kim đồng hồ")]
    public bool clockwise = true;

    [Tooltip("Số vòng quay. Nếu bật Infinite Rotation thì bỏ qua.")]
    public int rotationCount = 1;

    public bool infiniteRotation = false;

    [Header("Activation")]
    public bool activateOnStart = false;

    [Tooltip("Player chạm vào mới quay")]
    public bool activateByTrigger = true;

    private bool activated = false;

    private float rotatedAngle = 0f;

    void Start()
    {
        activated = activateOnStart;
    }

    void Update()
    {
        if (!activated) return;

        float direction = clockwise ? -1f : 1f;

        float rotationThisFrame =
            rotateSpeed * Time.deltaTime;

        transform.Rotate(0, 0, direction * rotationThisFrame);

        // Nếu quay vô hạn thì không kiểm tra số vòng
        if (infiniteRotation) return;

        rotatedAngle += rotationThisFrame;

        // 360 độ = 1 vòng
        if (rotatedAngle >= rotationCount * 360f)
        {
            activated = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activateByTrigger) return;

        if (other.CompareTag("Player"))
        {
            activated = true;
        }
    }
}