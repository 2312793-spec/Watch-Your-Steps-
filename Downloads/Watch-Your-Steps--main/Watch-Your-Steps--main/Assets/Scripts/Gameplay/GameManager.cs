using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int tokenCount = 0;

    void Start()
    {
        ResetToken();
    }

    private void Awake()
    {
        Instance = this;
    }

    public void AddToken()
    {
        tokenCount++;
        Debug.Log("Token: " + tokenCount);
    }

    public void ResetToken()
    {
        tokenCount = 0;
    }
}