using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject bloodPref;
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
            Instantiate(bloodPref, gameObject.transform.position, gameObject.transform.rotation);

            Destroy(gameObject);

        }
    }
}
