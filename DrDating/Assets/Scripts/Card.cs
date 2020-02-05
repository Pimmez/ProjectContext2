using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject
{
	public Sprite cardIcon;
	public int cardID;
	public string cardName;
	public CardSprite cardSprite;
	public string dialogue;
	public string leftQuote;
	public string rightQuote;

	public void Right()
	{
		Debug.Log(cardName + " Swiped right");
	}

	public void Left()
	{
		Debug.Log(cardName + " Swiped left");
	}
}

public enum CardSprite
{
	MAN,
	WOMAN,
	KNIGHT
}