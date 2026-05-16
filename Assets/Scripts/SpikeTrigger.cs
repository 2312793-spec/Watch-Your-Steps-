using UnityEngine;
using System.Collections;

public class SpikeTrigger : MonoBehaviour
{
    [Header("Spike Settings")]
    public Transform[] spikes;

    [Header("Movement")]
    public Vector2 moveDirection = Vector2.up;
    public float moveDistance = 2f;
    public float moveSpeed = 5f;

    [Header("Screen Shake")]
    public bool enableShake = false;
    public float shakeDuration = 0.3f;
    public float shakeMagnitude = 0.15f;

    [Header("Delay Before Spike")]
    public float spikeDelay = 0.5f;

    private Vector3[] targetPositions;
    private bool activated = false;

    void Start()
    {
        targetPositions = new Vector3[spikes.Length];

        for (int i = 0; i < spikes.Length; i++)
        {
            Vector3 direction =
                new Vector3(moveDirection.x, moveDirection.y, 0).normalized;

            targetPositions[i] =
                spikes[i].position + direction * moveDistance;
        }
    }

    void Update()
    {
        if (!activated) return;

        for (int i = 0; i < spikes.Length; i++)
        {
            spikes[i].position = Vector3.MoveTowards(
                spikes[i].position,
                targetPositions[i],
                moveSpeed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActivateTrap());
        }
    }

    IEnumerator ActivateTrap()
    {
        GetComponent<Collider2D>().enabled = false;

        if (enableShake)
        {
            CameraShake shake =
                Camera.main.GetComponent<CameraShake>();

            if (shake != null)
            {
                yield return StartCoroutine(
                    shake.Shake(shakeDuration, shakeMagnitude)
                );
            }
        }

        yield return new WaitForSeconds(spikeDelay);

        activated = true;
    }
}