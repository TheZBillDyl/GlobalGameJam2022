using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonLoadScene : MonoBehaviour
{
    public void LoadScene(string lvl)
    {
        if(lvl == "Quit")
        {
            Application.Quit();
        }
        SceneManager.LoadScene(lvl);
    }
}
