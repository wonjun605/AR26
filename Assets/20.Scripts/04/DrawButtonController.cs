using TMPro;
using UnityEngine;

public class DrawButtonController : MonoBehaviour
{
    public TextMeshProUGUI drawText;

    public void changeDrawMode()
    {
        var manager = GameManager.instance;
        if (manager == null) return;

        manager.isDrawing = !manager.isDrawing;
        if (drawText != null)
            drawText.text = manager.isDrawing ? "Stop" : "Draw";

        manager.ShowMessage(manager.isDrawing ? "Start drawing" : "Stop drawing");
    }
}
