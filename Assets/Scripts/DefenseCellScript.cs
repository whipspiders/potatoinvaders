using UnityEngine;

public class DefenseCellScript : MonoBehaviour
{
    [SerializeField] private int durability;
    private SpriteRenderer cellSprite;
    private float alphaLevel = 1;
    void Start()
    {
        cellSprite = gameObject.GetComponent<SpriteRenderer>();   
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.tag != "PlayerBullet")
        {
            if (durability > 0)
            {
                Damage();
            }
            else { Destroy(gameObject); }
        }
    }
    void Damage()
    {
        alphaLevel -= 0.36f;
        cellSprite.color = new Color(1f, 1f, 1f, alphaLevel);
    }
}
