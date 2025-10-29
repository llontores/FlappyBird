using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _text;

    private void OnEnable(){
        _bird.ScoreChanged += Display;
    }
    
    private void OnDisable(){
        _bird.ScoreChanged -= Display;
    }

    private void Display(int score){
        _text.text = score.ToString();
    }
}
