using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoMenu : MonoBehaviour
{
    public void IniciaJogo()
    {
        GameData.elapsedTime = 0;
        GameConstroller.Init();
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
