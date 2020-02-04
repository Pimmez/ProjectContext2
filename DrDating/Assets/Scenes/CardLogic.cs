using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardLogic : MonoBehaviour
{
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

	public void InduceRight()
	{
		text.text = "You have swiped right!";
	}

	public void InduceLeft()
	{
		text.text = "You have swiped left!";
	}
}