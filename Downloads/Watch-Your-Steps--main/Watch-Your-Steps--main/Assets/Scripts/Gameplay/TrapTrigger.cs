using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public GameObject groundTrap;
    public GameObject spike;

    private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;

            // Làm mặt đất rơi xuống
            Rigidbody2D rb = groundTrap.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }

            // Hoặc đơn giản: tắt luôn mặt đất
            // groundTrap.SetActive(false);

            // Hiện spike (nếu đang tắt)
            if (spike != null)
            {
                spike.SetActive(true);
            }
        }
    }
}