using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float projectilePower;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject healthPrefab;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip enemyHitSound;
    [SerializeField] private AudioClip playerHurtSound;
    [SerializeField] private AudioClip throwSound;
    private float horizontalMovement;
    private bool offCooldown;
    private float touch;
    private UnityEngine.UI.Image healthBar;
    public int score;
    public int health;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        healthBar = healthPrefab.GetComponent<UnityEngine.UI.Image>();
        offCooldown = true;

    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
        animator.SetBool("isWalking", true);

    }

    void Update()
    {
        rigidbody.linearVelocity = new Vector2(horizontalMovement * speed, rigidbody.linearVelocity.y);
        if (health == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (rigidbody.linearVelocity == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
        }
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (offCooldown)
        {
            PlaySound(throwSound, 0.8f);
            offCooldown = false;
            var bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * projectilePower, ForceMode2D.Force);
            animator.SetBool("isThrowing", true);
            StartCoroutine(ReturnAnim(0.5f, "isThrowing", false));
        }
    }
    public void Hit(GameObject enemy, int hitScore)
    {
        Destroy(enemy);
        score += hitScore;
        Debug.Log(score);
        PlaySound(enemyHitSound, 0.8f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "PlayerBullet")
        {
            Damage();
            Destroy(other.gameObject);
        }
    }
    public void Damage()
    {
        health--;
        Debug.Log("Took a hit");
        healthBar.fillAmount -= 0.335f;
        PlaySound(playerHurtSound, 0.8f);
        playerSprite.color = Color.red;
        StartCoroutine(ReturnSpriteColor(0.2f));
    }
    private void PlaySound(AudioClip sound, float volume)
    { 
        var audioSourceInstance = Instantiate(audioSource, gameObject.transform);
        audioSourceInstance.clip = sound;
        audioSourceInstance.volume = volume;
        audioSourceInstance.Play();
    }
    private IEnumerator ReturnAnim(float waitTime, string parameter, bool parameterValue)
    {
        yield return new WaitForSeconds(waitTime);
        animator.SetBool(parameter, parameterValue);
        offCooldown = true;
    }
    private IEnumerator ReturnSpriteColor(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        playerSprite.color = Color.white;
    }
}
