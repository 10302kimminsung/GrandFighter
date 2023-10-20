using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput agentInput;
    private Rigidbody2D rigid;
    private Animator animator;
    private float playerSpeed = 5;
    [SerializeField] float jumpPower = 40f;
    [SerializeField] private LayerMask _layerMask;
    
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void PlayerMovement(float xVel)
    {
        rigid.velocity = new Vector2(xVel * playerSpeed, rigid.velocity.y);
        
        if (xVel == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }   
        else if(xVel == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void PlayerAnimation(Vector2 move)
    {
        animator.SetFloat("velocity",move.magnitude);
    }
    
    public void PlayerJump()
    {
        if (rigid.velocity.y <= 0)
        {
            Debug.DrawRay(rigid.position, Vector2.down, new Color(0, 1, 0));
            RaycastHit2D _rayHit = Physics2D.Raycast(rigid.position, Vector2.down, 0.3f, _layerMask);
        }
        
        print(_PlayerJump());
        
        if (_PlayerJump())
        {
            rigid.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);
        }
    }

    public GameObject _PlayerJump()
    {
        return Physics2D.Raycast(rigid.position, Vector2.down, 0.3f, _layerMask).transform.gameObject;
    }
}
