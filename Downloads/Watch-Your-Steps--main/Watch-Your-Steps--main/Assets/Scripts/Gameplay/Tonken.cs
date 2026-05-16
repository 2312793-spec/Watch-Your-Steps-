using UnityEngine;

public class Token : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (audioSource != null && collectSound != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            GameManager.Instance.AddToken(); // 👈 dòng quan trọng

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            Destroy(gameObject, 0.5f);
        }
    }
}