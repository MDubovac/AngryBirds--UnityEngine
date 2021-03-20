using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;
    private int _levelIndex = 1;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        foreach (Enemy enemy in _enemies)
        {
            if(enemy != null)
            {
                return;
            }
        }

        _levelIndex++;
        string currentLevelName = "Level" + _levelIndex;
        SceneManager.LoadScene(currentLevelName);
    }
}
