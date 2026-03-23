using UnityEngine;
using TMPro;

public class BasketballGame2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform spawnPoint;
    public Transform hoop;

    public TMP_Text shotText;
    public TMP_Text scoreText;

    private float power = 6f;
    private float angle = 70f;

    private float hoopHeight;
    private float hoopDistance;

    private int score = 0;

    void Start()
    {
        ResetHoop();
        ResetBall();
        UpdateScoreUI();
    }

    void Update()
    {
        HandleInput();
        UpdateUI();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBall();
            ResetHoop();
        }
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            angle += 40f * Time.deltaTime;

        if (Input.GetKey(KeyCode.DownArrow))
            angle -= 40f * Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
            power += 5f * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
            power -= 5f * Time.deltaTime;

        power = Mathf.Clamp(power, 1f, 10f);
        angle = Mathf.Clamp(angle, 0f, 90f);
    }

    void Shoot()
    {
        float radians = angle * Mathf.Deg2Rad;

        Vector2 force = new Vector2(
            Mathf.Cos(radians),
            Mathf.Sin(radians)
        ) * power *2f;

        rb.linearVelocity = Vector2.zero;
        transform.position = spawnPoint.position;

        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void AddScore()
    {
        score++;
        UpdateScoreUI();

        Invoke(nameof(ResetAfterShot), 1.5f);
    }

    void ResetAfterShot()
    {
        ResetBall();
        ResetHoop();
    }

    void ResetHoop()
    {
        hoopHeight = Random.Range(2f, 4f);
        hoopDistance = Random.Range(4f, 8f);

        hoop.position = new Vector3(hoopDistance, hoopHeight, 0);
    }

    void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = spawnPoint.position;
    }

    void UpdateUI()
    {
        shotText.text =
            $"Power: {power:F1}\n" +
            $"Angle: {angle:F1}";
    }

    void UpdateScoreUI()
    {
        scoreText.text = $"Score: {score}";
    }
}