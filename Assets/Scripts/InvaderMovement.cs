using UnityEngine;

public class InvaderMovement : MonoBehaviour
{
    [SerializeField] private GameObject invaderContainer;
    [SerializeField] private float invaderSpeed = 1f;
    private float shift;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("MoveEnemies", 0f, invaderSpeed);
        shift = 0.3f;
    }
    void MoveEnemies()
    {
        Vector2 currentPos = invaderContainer.transform.position;
        invaderContainer.transform.position = currentPos + new Vector2(shift, 0);
        if (invaderContainer.transform.position.x >= 1.8)
        {
            Debug.Log("changing enemy direction to left");
            invaderContainer.transform.position = currentPos += new Vector2(0, -shift);
            shift *= -1;
            return;
        }
        if (invaderContainer.transform.position.x <= -0.8)
        {
            Debug.Log("changing enemy direction to right");
            invaderContainer.transform.position = currentPos += new Vector2(0, -shift);
            shift *= -1;
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Debug.Log("Changing enemy direction");
            Vector2 currentPos = invaderContainer.transform.position;
            shift *= -1;
            currentPos = invaderContainer.transform.position;
            invaderContainer.transform.position = currentPos += new Vector2(0, shift*=-1);

    }
}
