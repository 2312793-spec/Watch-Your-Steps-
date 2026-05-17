using UnityEngine;
using UnityEngine.SceneManagement;

public class levelmenu : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);
    }
}
