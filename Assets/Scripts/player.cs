using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] float invincibilityTime = 1.0f;
    GameObject lifeColor1;
    GameObject lifeColor2;
    GameObject lifeColor3;
    GameObject dieText;
    GameObject jojo;
    GameObject jojo2;
    GameObject impossible;
    GameObject impossible2;
    GameObject impossible3;
    private bool dead = false;
    private bool invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        lifeColor1 = GameObject.Find("life1");
        lifeColor2 = GameObject.Find("life2");
        lifeColor3 = GameObject.Find("life3");
        dieText = GameObject.Find("die");
        jojo = GameObject.Find("Jojopose1");
        jojo2 = GameObject.Find("Jojopose2");
        impossible = GameObject.Find("impossible");
        impossible2 = GameObject.Find("impossible2");
        impossible3 = GameObject.Find("impossible3");
        jojo.SetActive(false);
        jojo2.SetActive(false);
        dieText.SetActive(false);
        impossible.SetActive(false);
        impossible2.SetActive(false);
        impossible3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        reiniciar();
    }

    public void reiniciar()
    {
        if (Input.GetKey("space"))
        {
            life = 3;
            dieText.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "win")
        {
            impossible.SetActive(true);
        }
        else if (collision.gameObject.tag == "impossible")
        {
            impossible2.SetActive(true);
        }
        else if (collision.gameObject.tag == "impossible2")
        {
            impossible3.SetActive(true);
        }
        else if (collision.gameObject.tag == "impossible3")
        {
            jojo.SetActive(true);
            jojo2.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!invincible)
        {
            if (collision.gameObject.tag == "wall")
            {
                Destroy(collision.gameObject);
                invincible = true;
                StartCoroutine(resetInvulnerability());
                if (life > 0)
                {
                    life--;
                    if (life == 2)
                    {
                        lifeColor3.GetComponent<Renderer>().material.color = Color.red;
                    }
                    else if (life == 1)
                    {
                        lifeColor2.GetComponent<Renderer>().material.color = Color.red;
                    }
                    else if (life == 0)
                    {
                        lifeColor1.GetComponent<Renderer>().material.color = Color.red;
                        dead = true;
                    }
                }
            }
            else if(collision.gameObject.tag == "vidaExtra")
            {
                invincible = true;
                StartCoroutine(resetInvulnerability());
                Destroy(collision.gameObject);
                if (life < 3)
                {
                    life++;
                    if (life == 2)
                    {
                        lifeColor2.GetComponent<Renderer>().material.color = Color.green;
                    }
                    else
                    if (life == 1)
                    {
                        lifeColor1.GetComponent<Renderer>().material.color = Color.green;
                    }
                    else
                    if (life == 3)
                    {
                        lifeColor3.GetComponent<Renderer>().material.color = Color.green;
                        dead = true;
                    }
                }
            }
        }
        
        if (life == 0 && dead)
        {
            dieText.SetActive(true);
            Destroy(gameObject);
        }

        IEnumerator resetInvulnerability()
        {
            yield return new WaitForSeconds(invincibilityTime);
            invincible = false;
        }
    }
}
