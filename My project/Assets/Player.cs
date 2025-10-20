using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
//moved enemy code here too
//removed text for hurt cause eh
//moved hurtSound code here, changed enemy collision to a player collision. Makes more sense?
public class Player : MonoBehaviour
{
    public float speed;
    public AudioSource theSauce;
    public AudioClip hurtSound;
    public float health = 10;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        if (health is 0)
        {
            SceneManager.LoadScene("DEAD");
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            health -= 1;
            theSauce.PlayOneShot(hurtSound);
        }
    }

}
