using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    //[SerializeField] private Transform player;
    //[SerializeField] private DataManager dataManager;
    //public void ContinueGame()
    //{
    //    dataManager.Load();
    //    SceneManager.LoadScene("The Level");
    //    //SceneManager.LoadScene(dataManager.data.currentLevel);
    //    //player.position = dataManager.data.position;        
    //}
    //public void SaveGame()
    //{
    //    dataManager.data.position = new Vector2(player.position.x, player.position.y);
    //    dataManager.data.currentLevel = SceneManager.GetActiveScene().name;
    //    dataManager.Save();
    //    SceneManager.LoadScene("TheBonkMenu");
    //}
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
