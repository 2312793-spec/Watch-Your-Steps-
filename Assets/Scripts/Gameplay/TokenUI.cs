using UnityEngine;
using TMPro;

public class TokenUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = "Token: " + GameManager.Instance.tokenCount + " / 3";
    }
}