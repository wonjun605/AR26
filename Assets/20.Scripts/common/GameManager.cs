using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public bool isDrawing;
    [SerializeField] Camera arCamera;
    [SerializeField] GameObject spherePrefab;
    [SerializeField] Transform parentTransform;
    [SerializeField, Min(0.001f)] float drawSpacing = 0.02f;

    Vector3? lastDrawPosition;
    
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
        if (messageText != null) messageText.text = message;
    }

    private void Update()
    {
        DrawSpheres();
    }
    void DrawSpheres()
    {
        if (!isDrawing)
        {
            lastDrawPosition = null;
            return;
        }

        var camera = arCamera != null ? arCamera : Camera.main;
        if (camera == null || spherePrefab == null) return;

        var screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0.5f);
        var position = camera.ScreenToWorldPoint(screenCenter);
        if (lastDrawPosition.HasValue &&
            (position - lastDrawPosition.Value).sqrMagnitude < drawSpacing * drawSpacing)
            return;

        Instantiate(spherePrefab, position, Quaternion.identity, parentTransform);
        lastDrawPosition = position;
    }
}
