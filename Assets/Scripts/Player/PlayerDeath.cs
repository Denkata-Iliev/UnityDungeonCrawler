using UnityEngine;
using UnityEngine.SceneManagement;
using Vitals;

public class PlayerDeath : MonoBehaviour
{
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (health.Value <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
