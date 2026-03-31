using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Spike : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip deathSound;

    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.2f;

    private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            StartCoroutine(DeathEffect());
        }
    }

    void Restart()
    {
        GameManager.Instance.ResetToken(); // 👈 reset trước khi load lại
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator DeathEffect()
    {
        // 🔊 phát sound
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        // 🎥 lấy camera
        Transform cam = Camera.main.transform;
        Vector3 originalPos = cam.position;

        // ⏸ freeze game
        Time.timeScale = 0f;

        float elapsed = 0f;

        // 🔥 rung camera (dùng unscaled time vì game đang freeze)
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            cam.position = originalPos + new Vector3(x, y, 0);

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        // reset camera
        cam.position = originalPos;

        // ⏳ đợi thêm cho đủ 0.5s (freeze thật)
        yield return new WaitForSecondsRealtime(0.2f);

        // 🔄 bật lại time
        Time.timeScale = 1f;

        // reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}