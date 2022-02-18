using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D Player;
    private Animator PlayerAnimator;
    private Transform transform;
    private bool FallingDie = false;
    public AudioSource DieEffect;
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        Player = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (transform.position.y < -10f && !FallingDie)
        {
            FallingDie = true;
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            Die();
        }
    }

    private void Die()
    {
        Player.bodyType = RigidbodyType2D.Static;
        PlayerAnimator.SetTrigger("death");
        DieEffect.Play();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
