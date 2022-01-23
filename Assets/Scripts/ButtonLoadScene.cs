using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonLoadScene : MonoBehaviour
{
   public void LoadScene(string lvl)
    {
        SceneManager.LoadScene(lvl);
    }
}
