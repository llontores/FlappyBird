using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;
    private BirdMover _mover;
    private int _score;
    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    public void ResetPlayer()
    {
        _mover.Reset();
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    public void IncreaseScore(){
        _score++;
        ScoreChanged?.Invoke(_score);
    }
}
