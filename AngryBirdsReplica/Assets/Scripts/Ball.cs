using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public int attempt = 1;
    private Vector3 initialPosition;
    private Vector2 initialPos;
    private Quaternion initialRotation;
    [HideInInspector]
    public bool isLaunched = false;
    private bool isPressed = false;
    private bool abilityUsed = false;
    private bool tripleabilityUsed = false;
    private float idleTime;
    public Sprite red;
    public Sprite yellow;
    public Sprite blue;
    public GameObject redUI;
    public GameObject yellowUI;
    public GameObject blueUI;
    public GameManager gm;

    [SerializeField]
    private float launchPower = 500;

    private void Awake()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialPos = transform.position;
    }

    private void Start()
    {
        GetComponent<TrailRenderer>().enabled = false;
        FindObjectOfType<AudioManager>().Play("ChangeBall");
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, initialPosition);
        GetComponent<LineRenderer>().SetPosition(1, transform.position);

        if (isPressed)
        {
            if (!isLaunched)
            {
                Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                float x = Vector3.Distance(newPosition, initialPos);
                if (x > 5f)
                {
                    return;
                }
                transform.position = newPosition;
            }
        }

        if (isLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.7)
        {
            idleTime += Time.deltaTime;
        }

        if (transform.position.y > 7.10 || transform.position.y < -8 || transform.position.x > 17.25 || transform.position.x < -20.5 || idleTime > 5)
        {
            if(!gm.EnemiesDestroyed)
            {
                ResetPlayer();
            }
        }

        if ((isLaunched) && (attempt == 1))
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                return;
            }
        }
        else if ((isLaunched) && (attempt == 2))
        {
            if (isLaunched)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    if (!abilityUsed)
                    {
                        GetComponent<Rigidbody2D>().gravityScale = 2;
                        GetComponent<Rigidbody2D>().mass = 4;
                        abilityUsed = true;
                    }
                }
            }

        }
        else if ((isLaunched) && (attempt == 3))
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                if (!tripleabilityUsed)
                {
                    var instantiatedUp = Instantiate(this, new Vector3(transform.position.x + 0.3f, transform.position.y + 1f, transform.position.z), transform.rotation);
                    instantiatedUp.GetComponent<Rigidbody2D>().velocity = instantiatedUp.GetComponent<Rigidbody2D>().transform.TransformDirection(Vector3.right * 15);

                    var instantiatedDown = Instantiate(this, new Vector3(transform.position.x + 0.3f, transform.position.y + -0.5f, transform.position.z), transform.rotation);
                    instantiatedDown.GetComponent<Rigidbody2D>().velocity = instantiatedDown.GetComponent<Rigidbody2D>().transform.TransformDirection(Vector3.right * 15);

                    tripleabilityUsed = true;
                }
            }


        }

    }

    private void OnMouseDown()
    {
        isPressed = true;
        if (!isLaunched)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<LineRenderer>().enabled = true;
        }
        else
        {
            return;
        }
    }

    private void OnMouseUp()
    {
        if(!isLaunched)
        {
            FindObjectOfType<AudioManager>().Play("Throw");
            GetComponent<LineRenderer>().enabled = false;
            GetComponent<TrailRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().color = Color.white;

            Vector2 directionToInitialPosition = initialPosition - transform.position;

            GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * launchPower);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            isLaunched = true;
        }
    }

    void ResetPlayer()
    {
            attempt++;

            if (attempt == 2)
            {
                GetComponent<SpriteRenderer>().sprite = yellow;
                redUI.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
                FindObjectOfType<AudioManager>().Play("ChangeBall");
            }
            else if (attempt == 3)
            {
                GetComponent<SpriteRenderer>().sprite = blue;
                yellowUI.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
                FindObjectOfType<AudioManager>().Play("ChangeBall");
            }
            else if (attempt >3)
            {
                blueUI.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            }

            if (attempt < 4)
            {

                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                GetComponent<Rigidbody2D>().angularVelocity = 0;
                GetComponent<Rigidbody2D>().gravityScale = 0;
                GetComponent<Rigidbody2D>().mass = 1;
                transform.rotation = initialRotation;
                transform.position = new Vector3(initialPosition.x, initialPosition.y);
                isLaunched = false;
                isPressed = false;
                idleTime = 0;
            }
        }

    
}
