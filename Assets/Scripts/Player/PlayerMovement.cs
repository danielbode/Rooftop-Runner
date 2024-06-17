using UnityEngine;
using System.Collections;
using static UnityEngine.InputSystem.InputAction;
using System;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    private GameController gameControl;
    private ScoreController scoreController;
    private SpeedController speedController;

    public float jumpForce;
    public float jumpCooldown;
    private int jumpCount;
    private float lastJumpTime;

    public float duckForce;
    public float duckDuration;
    private bool isDucked;

    public Vector3 initialPlayerScale;
    public Vector3 miniPlayerScale;

    private bool invincible;
    private PlayerShooting playerShooting;

    public Sprite[] spriteArray;
    private SpriteRenderer spriteRendererBody;
    private SpriteRenderer spriteRendererFrontFoot;
    private SpriteRenderer spriteRendererBackFoot;

    void Start()
    {
        invincible = false;
        rb2D = GetComponent<Rigidbody2D>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameControl = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControl == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        scoreController = gameControllerObject.GetComponent<ScoreController>();
        speedController = gameControllerObject.GetComponent<SpeedController>();
        playerShooting = GetComponent<PlayerShooting>();

        spriteRendererBody = transform.GetChild(0).GetComponent<SpriteRenderer>();
        spriteRendererFrontFoot = transform.GetChild(1).GetComponent<SpriteRenderer>();
        spriteRendererBackFoot = transform.GetChild(2).GetComponent<SpriteRenderer>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("unsterblich"))
        {
            StartInvincibleMode();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("patronen"))
        {
            playerShooting.RefillBullets();
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherGameObject = other.gameObject;
        Collider2D otherCollider = other.GetContact(0).collider;

        if (otherGameObject.CompareTag("roof") || otherCollider.CompareTag("roof"))
        {
            jumpCount = 0;
        }
        else if (otherCollider.CompareTag("Head"))
        {
            Destroy(otherGameObject);
        }
        else if (otherCollider.CompareTag("Body"))
        {
            if (invincible)
            {
                Destroy(otherGameObject);
            }
            else
            {
                gameControl.Gameover();
            }
        }
    }

    public void OnJump()
    {

        if (Time.time - lastJumpTime < jumpCooldown) return;
        if (Time.timeScale != 0 && jumpCount < 2)
        {
            if (isDucked)
            {
                isDucked = false;
                this.transform.localScale = initialPlayerScale;
            }
            rb2D.velocity = new Vector2(0, jumpForce);
            jumpCount++;
        }
        lastJumpTime = Time.time;
    }

    public void OnDuck()
    {
        if (Time.timeScale != 0)
        {
            isDucked = true;
            this.transform.localScale = miniPlayerScale;
            rb2D.velocity = new Vector2(0, duckForce);
            StartCoroutine(DoAfterDelay(duckDuration, () =>
            {
                if (!this.transform.localScale.Equals(initialPlayerScale))
                {
                    transform.localScale = initialPlayerScale;
                }
            }));
        }
    }

    public void StartInvincibleMode()
    {
        invincible = true;

        scoreController.StartInvincibleMode();
        speedController.StartInvincibleMode();

        spriteRendererBody.sprite = spriteArray[3];
        spriteRendererFrontFoot.sprite = spriteArray[4];
        spriteRendererBackFoot.sprite = spriteArray[5];
        
        StartCoroutine(DoAfterDelay(5, StopInvincibleMode));
    }

    public void StopInvincibleMode()
    {
        spriteRendererBody.sprite = spriteArray[0];
        spriteRendererFrontFoot.sprite = spriteArray[1];
        spriteRendererBackFoot.sprite = spriteArray[2];

        scoreController.StopInvincibleMode();
        speedController.StopInvincibleMode();

        invincible = false;
    }

    IEnumerator DoAfterDelay(float delaySeconds, Action thingToDo)
    {
        yield return new WaitForSeconds(delaySeconds);
        thingToDo();
    }
}
