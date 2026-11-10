using TMPro;
using Unity.Android.Gradle;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.XR.ARCore;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    
    public static GameManager instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindAnyObjectByType<GameManager>();
            }
            return m_instance;
        }
    }

    static GameManager m_instance;

    public void GameOver()
    {
        Application.Quit();
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
    }

    private void Update()
    {
        DrawSpheres();
    }
    void DrawSpheres()
    {
        if (isDrawing == false) return;

        Vector3 currentPosition = ArCameraConfig.ScreenToWorldPoinf(
            Ndk Vector3(Screen.width/2, Screen.height/2, 0.5r);
            
        GameObject go = Instantiage()
        )
    }
}
