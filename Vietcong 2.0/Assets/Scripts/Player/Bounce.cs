using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float force;
    private Rigidbody rb_Player;
    private StateHandler handler;
    private const float DEFAULTSTUN = 0.25f;
    private AudioClip PlayBounceSound;
    private AudioSource BounceSource;
    private Animator Anim;

    void Awake()
    {
        BounceSource = GetComponent<AudioSource>();
        PlayBounceSound = BounceSource.clip;
        rb_Player = GetComponentInParent<Rigidbody>();
        handler = GetComponentInParent<StateHandler>();
        Anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks if the players collide with eachother
        if (PlayerTotal.PlayerList.Contains(other.gameObject))
        {
            Anim.SetBool("IsBounce", true);
            Anim.SetBool("IsRunning", false);
            Anim.SetBool("IsMud", false);
            other.GetComponent<Movement>()._canMove = false;
            BounceSource.PlayOneShot(PlayBounceSound, 0.7f);
            handler.SetCanAct(DEFAULTSTUN);
            StartCoroutine(Delay(other.gameObject));
        }
    }

    IEnumerator Delay(GameObject other)
    {
        yield return new WaitForSeconds(0.35f);
        Vector3 direction = (transform.position - other.transform.position).normalized;
        rb_Player.AddForce(direction * force, ForceMode.Impulse);
        yield return new WaitForSeconds(2.5f);
        Anim.SetBool("IsBounce", false);
        //Check if there is more the one player left after the bounce before allowing the player to move again.
        if(PlayerTotal.PlayerList.Count != 1)
        {
            other.GetComponent<Movement>()._canMove = true;
        }       
    }
}
