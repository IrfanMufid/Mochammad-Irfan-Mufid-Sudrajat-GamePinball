using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumberController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    public float score;

    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;

    private Renderer renderer;
    private Animator animator;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        renderer.material.color = color;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            //animasiin
            animator.SetTrigger("hit");

            //playsfx
            audioManager.playSFX(collision.transform.position);

            //playvfx
            vfxManager.playVFX(collision.transform.position);

            //score add
            scoreManager.AddScore(score);
        }
    }
}
