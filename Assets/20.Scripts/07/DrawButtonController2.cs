using UnityEngine;
using TMPro;

public class DrawButtonController2 : MonoBehaviour
{
    public TextMeshProUGUI drawText;
    public DrawLines drawLines;

    int toggle = 0;

    public void ChangeMode()
    {
        toggle = (toggle + 1) % 2;

        if(toggle == 1)
        {
            drawText.text = "Stop";
            drawLines.AllowDraw(true);
        }
        else
        {
            drawText.text = "Draw";
            drawLines.AllowDraw(false);
        }
    }
}
