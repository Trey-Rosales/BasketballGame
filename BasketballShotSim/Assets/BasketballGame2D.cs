using UnityEngine;
using TMPro;

public class BasketballGame2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rbDefense;
    public Transform spawnPoint;
    public Transform hoop;

    public TMP_Text shotText;
    public TMP_Text scoreText;

    private float power = 6f;
    private float angle = 70f;

    private int score = 0;
    private Vector3 defenderStartPos;
    private float defenderSpeed = 2f;
    private float defenderHeight = 2f;

    void Start()
    {
        ResetBall();
        UpdateScoreUI();
        defenderStartPos = rbDefense.transform.position;
    }

    void Update()
    {
        HandleInput();
        UpdateUI();
        MoveDefender();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBall();
        }
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            angle += 1f * Time.deltaTime;

        if (Input.GetKey(KeyCode.DownArrow))
            angle -= 1f * Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
            power += 1f * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
            power -= 1f * Time.deltaTime;

        power = Mathf.Clamp(power, 1f, 10f);
        angle = Mathf.Clamp(angle, 0f, 90f);
    }

    void Shoot()
    {
        float radians = angle * Mathf.Deg2Rad;

        Vector2 force = new Vector2(
            Mathf.Cos(radians),
            Mathf.Sin(radians)
        ) * power * 2f;

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
        ResetDefense();
    }

    void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = spawnPoint.position;
    }

    void ResetDefense()
    {
        rbDefense.angularVelocity = 0f;
        rbDefense.position = defenderStartPos;
        rbDefense.rotation = 0f;
    }

    void MoveDefender()
    {
        float yOffset = Mathf.Sin(Time.time * GetDefenderSpeed()) * defenderHeight;
        rbDefense.transform.position = new Vector3(
            defenderStartPos.x,
            defenderStartPos.y + yOffset,
            defenderStartPos.z
        );
    }

    void UpdateUI()
    {
        shotText.text =
            $"Power: {power:F1}\n" +
            $"Angle: {angle:F1}";
    }

    float GetDefenderSpeed() 
    {
        float baseSpeed = 2f;
        float speedUp = 0.5f;
        return baseSpeed + (score * speedUp);
    }

    void UpdateScoreUI()
    {
        scoreText.text = $"Score: {score}";
    }
}