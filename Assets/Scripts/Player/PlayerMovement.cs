using UnityEngine;
using System;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer spriteRendererBody;
    public SpriteRenderer spriteRendererFrontFoot;
    public SpriteRenderer spriteRendererBackFoot;
    public Sprite[] spriteArray;
    public float jumpForce;
    public float jumpCooldown;
    public float duckForce;
    public float duckDuration;
    public Vector3 initialPlayerScale;
    public Vector3 miniPlayerScale;

    private GameController gameController;
    private ScoreController scoreController;
    private SpeedController speedController;
    private PlayerShooting playerShooting;
    private Rigidbody2D rigidBody2D;
    private int jumpCount;
    private float lastJumpTime;
    private bool isDucked;
    private bool invincible;

    private void Start()
    {
        GameObject gameControllerGameObject = GameObject.FindWithTag("GameController");
        if (gameControllerGameObject == null)
        {
            Debug.LogError("Game Object with tag \"GameController\" not found.");
        }
        else
        {
            gameController = gameControllerGameObject.GetComponent<GameController>();
            if (gameController == null)
            {
                Debug.Log("GameController not found.");
            }
            scoreController = gameControllerGameObject.GetComponent<ScoreController>();
            if (scoreController == null)
            {
                Debug.Log("ScoreController not found.");
            }
            speedController = gameControllerGameObject.GetComponent<SpeedController>();
            if (speedController == null)
            {
                Debug.Log("SpeedController not found.");
            }
        }
        playerShooting = GetComponent<PlayerShooting>();
        if (playerShooting == null)
        {
            Debug.Log("PlayerShooting not found.");
        }
        rigidBody2D = GetComponent<Rigidbody2D>();
        if (rigidBody2D == null)
        {
            Debug.Log("Rigidbody2D not found.");
        }

        invincible = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InvincibleItem"))
        {
            StartInvincibleMode();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("BulletsItem"))
        {
            playerShooting.RefillBullets();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherGameObject = other.gameObject;
        Collider2D otherCollider = other.GetContact(0).collider;

        if (otherGameObject.CompareTag("Roof") || otherCollider.CompareTag("Roof"))
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
                gameController.Gameover();
            }
        }
    }

    private IEnumerator DoAfterDelay(float delaySeconds, Action thingToDo)
    {
        yield return new WaitForSeconds(delaySeconds);
        thingToDo();
    }

    public void OnJump()
    {
        if (Time.time - lastJumpTime < jumpCooldown) return;
        if (Time.timeScale != 0 && jumpCount < 2)
        {
            if (isDucked)
            {
                isDucked = false;
                transform.localScale = initialPlayerScale;
            }
            rigidBody2D.linearVelocity = new Vector2(0, jumpForce);
            jumpCount++;
        }
        lastJumpTime = Time.time;
    }

    public void OnDuck()
    {
        if (Time.timeScale != 0)
        {
            isDucked = true;
            transform.localScale = miniPlayerScale;
            rigidBody2D.linearVelocity = new Vector2(0, duckForce);
            StartCoroutine(DoAfterDelay(duckDuration, () =>
            {
                if (!transform.localScale.Equals(initialPlayerScale))
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
}
