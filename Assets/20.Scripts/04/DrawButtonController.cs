using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class DrawButtonController : MonoBehaviour
public bool isDrawing = false;
{
    public TextMeshProUGUI drawText;

    int i = 0; 

    public void changeDrawMode()
    {
        i = (i+1) % 2;

        if(i == 0)
        {
            drawText.text = "Strop";
            GameManager.instance.isDrawing = true;
            GameManager.instance.ShowMessage("Start Draqin");
        }
        else
        {
            drawText.text = "Draw";
            GameManager.instance.isDrawing
        }
    }
}
