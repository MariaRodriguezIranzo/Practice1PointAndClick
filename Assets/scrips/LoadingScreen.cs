using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Button playButton;

    void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnPlayButtonClick()
    {
        MusicManager musicManager = FindObjectOfType<MusicManager>();
        if (musicManager != null)
        {
            musicManager.StopMusic(); // Detener la música
        }
        // Inicia la carga de la escena Level1
        SceneManager.LoadScene("Level1");
    }
}
