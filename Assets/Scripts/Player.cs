using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _jumpForce = 10;
    [SerializeField] GameObject _gameOverUI;

    Rigidbody2D _rb;
    [SerializeField] SpriteRenderer _sr;

    [SerializeField] string _currentColor;

    [SerializeField] Color _colorCyan;
    [SerializeField] Color _colorYellow;
    [SerializeField] Color _colorMagenta;
    [SerializeField] Color _colorPink;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        _gameOverUI.SetActive(false);

        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _rb.velocity = Vector2.up * _jumpForce;
        }

        if (transform.position.y > 78)
        {
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(other.gameObject);
            return;
        }

        if (other.tag != _currentColor)
        {
            GameOver();
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                _currentColor = "Cyan";
                _sr.color = _colorCyan;
                break;
            case 1:
                _currentColor = "Yellow";
                _sr.color = _colorYellow;
                break;
            case 2:
                _currentColor = "Magenta";
                _sr.color = _colorMagenta;
                break;
            case 3:
                _currentColor = "Pink";
                _sr.color = _colorPink;
                break;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _gameOverUI.SetActive(true);
    }
}
