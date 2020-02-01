using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillController : MonoBehaviour
{
    private float speed;
    public float power;
    BoxCollider2D collider;
    Block block;
    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }
    public void Update()
    {
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousePos);

            //transform.LookAt(new Vector3(mousePosition.x, mousePosition.y, transform.position.x));
            Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
            transform.rotation = rot;
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        }
    }

    public void MineBlock()
    {
        collider.enabled = !collider.enabled;
        collider.isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == gameObject.CompareTag("Clay"));
        {
            block = collision.GetComponent<Block>();
            block.TakeDamage(power);
        }
    }
}
