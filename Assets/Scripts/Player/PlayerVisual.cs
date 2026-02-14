using UnityEngine;

public class PlayerVissual : MonoBehaviour
{
    public PlayerMovement movement;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(movement.currentSpeed > 0.1)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }
}
