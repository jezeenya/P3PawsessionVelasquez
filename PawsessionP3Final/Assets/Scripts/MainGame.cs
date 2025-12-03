using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    private void OnEnable()
    {
        //Only specify the sceneName or sceneBuildIntex will load the scene with the single mode
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}

