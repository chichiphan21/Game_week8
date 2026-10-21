
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Popup UI")]
    public Canvas GameMenu;

    public TMP_Text Title;
    public TMP_Text Message;

    public Button EnterButton;
    public Button RestartButton;

    [Header("Scene Settings")]
    public string nextSceneName = "NextLevel";

    void Start()
    {
        // Ẩn popup khi mới chạy game
        GameMenu.enabled = false;

        // Gán nội dung từ C#
        Title.text = "Welcome to Unity!";
        Message.text = "Do you want to continue?";

        // Gán text cho hai Button
        EnterButton
            .GetComponentInChildren<TMP_Text>()
            .text = "Enter";

        RestartButton
            .GetComponentInChildren<TMP_Text>()
            .text = "Restart";
    }

    // Chuyển sang Scene tiếp theo
    public void NextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // Chạy lại Scene hiện tại
    public void RestartScene()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
