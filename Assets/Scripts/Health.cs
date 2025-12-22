using UnityEngine;

public class Health : MonoBehaviour
{
    public float hp = 100;
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    
    public void ChangeHP(float value)
    {
        hp -= value;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
