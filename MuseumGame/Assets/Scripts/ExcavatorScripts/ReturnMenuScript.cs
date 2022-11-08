using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenuScript : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Home");
            
    }
}
