using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillController : MonoBehaviour
{
    private float speed;
    private float power = 10;
    private float strength = 10;
    private float strengthModifier;
    private Vector3 forward;
    BoxCollider2D collider;
    Block block;

    private DrillType type;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        GameEventManager.GameStart += GameStart;
        type = DrillType.STONE;
        
    }
    public void Update()
    {
        {
            Vector2 mousePos = Input.mousePosition;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
            forward = -(transform.position - mousePosition);
            //transform.LookAt(new Vector3(mousePosition.x, mousePosition.y, transform.position.x));
            Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
            transform.rotation = rot;
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        }
    }

    public void Mine()
    {
        if(!collider.enabled)
        collider.enabled = true;
    }
    public void StopMine()
    {
        if(collider.enabled)
        collider.enabled = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if ((collision == gameObject.CompareTag("Dirt")) || (collision == gameObject.CompareTag("Clay")) || (collision == gameObject.CompareTag("Stone")) || (collision == gameObject.CompareTag("Steel")))
        if (collision.GetComponent<Block>())
        {

            if (type == DrillType.STONE)
                strengthModifier = 1.0f;
            if (type == DrillType.IRON)
                strengthModifier = 1.5f;
            if (type == DrillType.STEEL)
                strengthModifier = 2.0f;
            if (type == DrillType.DIAMOND)
                strengthModifier = 2.5f;

            block = collision.gameObject.GetComponent<Block>();
            block.TakeDamage(strength * strengthModifier);
        }
    }

    private void GameStart()
    {
        type = DrillType.STONE;
    }

    public void SetType(DrillType nType)
    {
        type = nType;
    }

    public DrillType GetType()
    {
        return type;
    }

    public Vector3 GetForward()
    {
        return forward;
    }
}
