using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackGroundMove : MonoBehaviour
{
    public GameObject moveBackGround;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (gameObject.name)
            {
                case "Left":
                    moveBackGround.transform.position = new Vector2(collision.transform.position.x + 10, collision.transform.position.y);
                    break;
                case "Right":
                    moveBackGround.transform.position = new Vector2(collision.transform.position.x - 10, collision.transform.position.y);
                    break;
                case "Up":
                    moveBackGround.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + 10);
                    break;
                case "Down":
                    moveBackGround.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y - 10);
                    break;
            }
        }
    }


}
