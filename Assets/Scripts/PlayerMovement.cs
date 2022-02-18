using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Player;
    private SpriteRenderer Sprite;
    private Animator PlayerAnimator;
    private PolygonCollider2D PlayerColli;
    public AudioSource JumpSoundEffect;

    private float dirX = 0f;
    public float MoveSpeed = 7f;
    public float JumpForce = 14f;
    private enum MovementState { idle, running, jump, fall };

    public LayerMask JumpAble;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
        PlayerColli = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //di chuyen ngang
        dirX = Input.GetAxisRaw("Horizontal");
        Player.velocity = new Vector2(dirX * MoveSpeed, Player.velocity.y);

        //Jump
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && IsGrounded())
        {
            JumpSoundEffect.Play();
            Player.velocity = new Vector2(Player.velocity.x, JumpForce);
        }
        AnimationState();
    }

    void AnimationState()
    {
        MovementState state;
        if (dirX > 0)
        {
            state = MovementState.running;
            Sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            Sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (!IsGrounded())
            if (Player.velocity.y > 0f)
            {
                state = MovementState.jump;
            }
            else if (Player.velocity.y < 0f)
            {
                state = MovementState.fall;
            }

        PlayerAnimator.SetInteger("state", (int)state);
    }
    //Kiem tra cham dat
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(PlayerColli.bounds.center, PlayerColli.bounds.size, 0f, Vector2.down, .1f, JumpAble);
    }
}
