using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BirdInput : MonoBehaviour
{
    [SerializeField] private Game _game;

    public event UnityAction JumpKeyPressed;
    public event UnityAction ShootKeyPressed;

    private void Update()
    {
        if (_game.IsActive == true)
        {
            if (Input.GetMouseButtonDown(0))
                ShootKeyPressed?.Invoke();
            if (Input.GetKeyDown(KeyCode.Space))
                JumpKeyPressed?.Invoke();
        }
    }
}
