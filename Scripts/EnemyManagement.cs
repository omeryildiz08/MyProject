using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    [SerializeField] public GameObject Player;
    public float speed;
    public float distance;
    public Animator anim;

    private void Start()
    {
        FindPlayer();
        
    }

    private void FixedUpdate()
    {
        //   transform.Translate(Mathf.Sign(Player.transform.position.x - this.gameObject.transform.position.x), Mathf.Sign(Player.transform.position.y - this.gameObject.transform.position.y), Mathf.Sign(Player.transform.position.z - this.gameObject.transform.position.z) *Time.deltaTime);

        Vector3 Scale = transform.localScale;
        Scale.x = Mathf.Sign(Player.transform.position.x - transform.position.x) * 0.3f;
        transform.localScale = Scale;

        if (Vector3.Distance(Player.transform.position, transform.position) > distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
    }
    void FindPlayer()
    {
        
        Player = GameObject.Find("Player");
    }

}
