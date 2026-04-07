using UnityEngine;

public class TrapController : MonoBehaviour
{
    public GameObject ground; // Ground_Trap (object cha)
    public GameObject spike;  // Spike (có thể null)

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra Player
        if (collision.CompareTag("Player") && !triggered)
        {
            triggered = true;

            // Lấy Rigidbody và Collider
            Rigidbody2D rb = ground.GetComponent<Rigidbody2D>();
            BoxCollider2D col = ground.GetComponent<BoxCollider2D>();

            // Cho ground rơi
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = 10; // chỉnh tốc độ rơi
            }
            else
            {
                Debug.Log("Ground không có Rigidbody2D!");
            }

            // 🔥 Tắt collider để rơi xuyên map
            if (col != null)
            {
                col.enabled = false;
            }
            else
            {
                Debug.Log("Ground không có Collider!");
            }

            // Hiện spike (nếu có)
            if (spike != null)
            {
                spike.SetActive(true);
            }
        }
    }
}