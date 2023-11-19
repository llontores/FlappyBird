using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _image;

    private void OnEnable(){
        _bird.HealthChanged += Display;
    }
    
    private void OnDisable(){
        _bird.HealthChanged -= Display;
    }

    private void Display(float health){
        _text.text = health.ToString();
        _image.SetActive(true);
    }
}
