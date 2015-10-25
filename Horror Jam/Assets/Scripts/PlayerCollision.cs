using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    float health;
    int damage;

    public bool dead;

    public Image healthImage;

    public Image panel;
    float alpha;

	// Use this for initialization
	void Start ()
    {
        health = 1.0f;
        damage = 3;
        dead = false;
        alpha = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!dead)
            health += Time.deltaTime;

        healthImage.fillAmount = ((float)health / 10.0f);

        if (dead)
        {
            Color c = Color.red;
            if (alpha < 0.5f)
                alpha += Time.deltaTime * 0.1f;
            c.a = alpha;
            panel.color = c;

            if (alpha >= 0.5f)
            {
                Application.LoadLevel("Game Over");
                Destroy(gameObject);
            }

        }
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bad Stuff")
        {
            if (health > 0.0f)
                health -= damage;

            if (health <= 0.0f)
                Death();
        }
    }

    void Death()
    {
        dead = true;

        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        GetComponent<CharacterController>().enabled = false;

    }
}
