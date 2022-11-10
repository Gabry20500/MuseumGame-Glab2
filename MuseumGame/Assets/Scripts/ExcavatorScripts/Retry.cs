using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void RetryFunc()
    {
        SceneManager.LoadScene("EscavatorGame");

    }
}
