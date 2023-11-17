using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : Screen
{
    public event UnityAction RestartButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.gameObject.SetActive(false);
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.gameObject.SetActive(true);
    }

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}
