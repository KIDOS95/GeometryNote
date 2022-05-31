using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Figure : SpeedSynchronization, IPointerDownHandler
{
    [SerializeField]
    private Sprite[] shapes;
    [SerializeField]
    private SpriteRenderer objectIcon;
    public static Action OnObjectClicked;
    
    private void Start()
    {
        LoadIcon();
    }

    private void LoadIcon()
    {
        int currentIcon = PlayerPrefs.GetInt("currentSprite");
        objectIcon.sprite = shapes[currentIcon];
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destr"))
        {
            Destroy(gameObject);
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        OnObjectClicked?.Invoke();
        gameObject.SetActive(false);
    }
}
