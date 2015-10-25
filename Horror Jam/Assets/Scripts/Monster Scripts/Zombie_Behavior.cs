using UnityEngine;
using System.Collections;

public class Zombie_Behavior : MonoBehaviour {

    public Animator Anim;
    private bool IsAsleep = true;
    //private bool IsAlive = true;
    private Vector3 TargetPosition;
    private Vector3 ToTarget;
    public float moveSpeed;
    public float DistanceToTarget;
    public float WakeUpDistance = 11.0f;
    public float AttackProxomity = 1.75f;
    private AudioSource m_AudioSource;
    public AudioClip m_WalkSound;           
    public AudioClip m_AttackSound;

    float timer;
      
	// Use this for initialization
	void Start () 
    {
        DistanceToTarget = 100.0f;
        WakeUpDistance = 11.0f;
        //DistanceToTarget = 100.0f;
        //WakeUpDistance = 11.0f;
        m_AudioSource = GetComponent<AudioSource>();
        timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        // If the Zombie is asleep check to see if the player is close enough to wake them
        if (IsAsleep == true && DistanceToTarget < WakeUpDistance)
        {
            IsAsleep = false;
            Anim.SetTrigger("WakeUp");
        }

        // Calculate the targets position, the vector towards the target, and the distance to the target
        TargetPosition = GameObject.Find("Player").transform.position;
        ToTarget = (TargetPosition - transform.position);
        DistanceToTarget = ToTarget.magnitude;


        // if the Zombie is awake
        if (IsAsleep == false)
        {
            TargetPosition.y = 0;
            transform.LookAt(TargetPosition);
            //ToTarget.Normalize();
            if (DistanceToTarget > AttackProxomity)
            {
                m_AudioSource.clip = m_WalkSound;
                if (!m_AudioSource.isPlaying)
                {
                  m_AudioSource.PlayOneShot(m_AudioSource.clip);
                }
                Walk(ToTarget);
            }

            // If the Zombie is close enough to the player, attack!
            if (DistanceToTarget < AttackProxomity)
            {
                m_AudioSource.clip = m_AttackSound;
                if (!m_AudioSource.isPlaying)
                {
                  m_AudioSource.PlayOneShot(m_AudioSource.clip);
                }
                Attack();
            }

            if (DistanceToTarget > 15)
            {
                m_AudioSource.Stop();
            }

        }

        timer += Time.deltaTime;

        if (timer >= 40.0f)
        {
            Destroy(gameObject);
        }
	}








    void Walk (Vector3 _target)
    {
       // _target.y = 0.0f;
        transform.position = (transform.position + (_target/500 * moveSpeed));
        transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
    }


    void Attack()
    {
        Anim.SetTrigger("Attack");
    }


}
