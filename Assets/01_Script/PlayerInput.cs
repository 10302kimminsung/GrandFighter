
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<float> onMove;
    public UnityEvent onJump;
    
    private void Update()
    {
        GetMovement();
        GetJump();
    }

    private void GetMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        
        onMove?.Invoke(x);
    }

    private void GetJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onJump?.Invoke();
        }
    }
    
}
