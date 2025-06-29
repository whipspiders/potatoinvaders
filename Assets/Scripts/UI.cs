using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject healthPrefab;
    [SerializeField] private PlayerScript playerScript;
    private UnityEngine.UI.Image healthBar;
    private int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = playerScript.health;
        healthBar = healthPrefab.GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
