using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button button;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick()
    {
        SceneManager.LoadScene("MainGame");
    }
}
