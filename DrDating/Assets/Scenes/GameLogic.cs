using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
	[SerializeField] private GameObject card;
	[SerializeField] private CardLogic cardLogic;
	SpriteRenderer spriteRenderer;

	private float bounceBackForce = 1f;

	private void Awake()
	{
		spriteRenderer = card.GetComponent<SpriteRenderer>();
	}

    private void Update()
    {
        if(Input.GetMouseButton(0) && cardLogic.isMouseOver)
		{
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			card.transform.position = pos;
		}
		else
		{
			card.transform.position = Vector2.MoveTowards(card.transform.position, new Vector2(0, 0), bounceBackForce);
		}

		if(card.transform.position.x > 2)
		{
			spriteRenderer.color = Color.green;
			if (!Input.GetMouseButton(0))
			{
				cardLogic.InduceRight();
			}
		}
		else if(card.transform.position.x < -2)
		{
			spriteRenderer.color = Color.red;
			if (!Input.GetMouseButton(0))
			{
				cardLogic.InduceLeft();
			}
		}
		else
		{
			spriteRenderer.color = Color.white;
		}
    }
}