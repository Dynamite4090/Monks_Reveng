using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public void OnApplicationQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}