using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Flickering : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpAsset;
    private float setTransparency;
    private float newTransparency = 255;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("changeTransparency", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        tmpAsset.color = new Color(255, 255, 255, setTransparency);
        setTransparency = newTransparency;
    }
    private void changeTransparency()
    {
        if (setTransparency > 0)
        {
            newTransparency = 0f;
        }
        else if (setTransparency == 0) { newTransparency = 255f; }
    }

}
