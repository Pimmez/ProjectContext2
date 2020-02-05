using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardLogic : MonoBehaviour
{
	public Card card;
	public bool isMouseOver = false;
	[SerializeField] private TextMeshProUGUI text;

	private void OnMouseOver()
	{
		isMouseOver = true;
	}

	private void OnMouseExit()
	{
		isMouseOver = false;
	}
}