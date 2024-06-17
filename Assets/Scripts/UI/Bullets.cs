using TMPro;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public TextMeshProUGUI bulletText;

    private int bullets;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBulletCount();
    }

    public void AddBullets(int amount)
    {
        bullets += amount;
        UpdateBulletCount();
    }

    private void UpdateBulletCount()
    {
        
        bulletText.text = bullets.ToString();
    }
}
