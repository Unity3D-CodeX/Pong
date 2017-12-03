using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	public void LoadLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}

	public void LoadLevel(int levelIndex)
	{
		SceneManager.LoadScene(levelIndex);
	}
}
