using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Enemy invader;
    [SerializeField] private GameObject invaderContainer;
    [SerializeField] private Enemy[] invaderList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemies();
    }
    void Update()
    {
        if (invaderContainer.transform.childCount == 0)
        {
            Debug.Log("respawning new enemies");
            SpawnEnemies();
        }
    }
    void SpawnEnemies()
    {
        var offset = 0f;
        var offset2 = 0f;
        for (int j = 0; j < 10; j++)
        {
            offset += 0.2f;
            offset2 = 0f;
            for (int i = 0; i < invaderList.Length; i++)
            {
                Vector2 pos = new Vector2(j - 5 + offset, i + 1.8f + offset2);
                var enemy2 = Instantiate(invaderList[i], pos, invaderContainer.transform.rotation);
                enemy2.transform.SetParent(invaderContainer.transform);
                offset2 += 0.2f;
            }
        }
    }
}
