using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button Button;

    private void OnEnable(){
        Button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisabe(){
        Button.onClick.RemoveListener(OnButtonClick);
    }
    protected abstract void OnButtonClick();

    protected abstract void Open();

    protected abstract void Close();
}
