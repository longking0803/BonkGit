using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private DataManager dataManager;
    public void ContinueGame()
    {
        dataManager.Load();
        player.position = dataManager.data.position;
        SceneManager.LoadScene(dataManager.data.currentLevel);
    }
    public void SaveGame()
    {
        dataManager.data.position = new Vector2(player.position.x, player.position.y);
        dataManager.data.currentLevel = SceneManager.GetActiveScene().name;
        dataManager.Save();
    }
    public void ExitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    } public void StartGame()
    {
        Debug.Log("Load Scene");
        SceneManager.LoadScene("Minh.Nhut");
    }
}
