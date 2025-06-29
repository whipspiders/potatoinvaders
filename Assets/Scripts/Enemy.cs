using UnityEngine;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject explosion;
    [SerializeField] private int getScore;
    [SerializeField] private float speed;
    [SerializeField] private float projectilePower;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;
    private GameObject invaderContainer;
    private PlayerScript playerScript;
    private float timer;
    private float timer2;
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float num1 = 30f;
        float num2 = 1f;
        InvokeRepeating("Shoot", UnityEngine.Random.Range(num1, num2), UnityEngine.Random.Range(num1, num2));
        GameObject Player = GameObject.Find("Player");
        invaderContainer = GameObject.Find("Invaders");
        playerScript = Player.GetComponent<PlayerScript>();
        score = playerScript.score;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void Shoot()
    {
        var bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * projectilePower, ForceMode2D.Force);
        PlaySound(shootSound, 0.8f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            playerScript.Hit(gameObject, getScore);
            var explosionParticle = Instantiate(explosion, transform.position, Quaternion.identity);
            explosionParticle.transform.SetParent(invaderContainer.transform);
            Destroy(other.gameObject);
        }
    }
    private void PlaySound(AudioClip sound, float volume)
    { 
        var audioSourceInstance = Instantiate(audioSource, gameObject.transform);
        audioSourceInstance.clip = sound;
        audioSourceInstance.volume = volume;
        audioSourceInstance.Play();
    }
}
