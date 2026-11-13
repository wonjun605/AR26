using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindAnyObjectByType<GameManager2>();
            }
            return m_instance;
        }
    }

    // 수정: GameManager -> GameManager2
    static GameManager2 m_instance; 

    public void GameOver()
    {
        Application.Quit();
    }
}
