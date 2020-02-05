using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
	//GameObjects
	public GameObject cardGameObject;
	public CardLogic cardLogic;
	public SpriteRenderer cardSpriteRenderer;
	public ResourceManager resourceManager;

	//Tweaking Variables
	public float bounceBackForce = 1f;
	public float sideMargin = 0.5f;
	public float sideTrigger = 2f;
	private float alphaText;
	private Color textColor;
	private Vector3 pos;
	public float divideValue = 3f;

	//UI
	public TMP_Text display;
	public TMP_Text characterDialogue;
	public TMP_Text actionDialogue;

	//Card Variables
	private string leftQuote;
	private string rightQuote;
	public Card currentCard;
	public Card testCard;

	private void Awake()
	{
		cardSpriteRenderer = cardGameObject.GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		LoadCard(testCard);
	}

	private void UpdateDialogue()
	{
		actionDialogue.color = textColor;
		if (cardGameObject.transform.position.x < 0)
		{
			actionDialogue.text = leftQuote;
		}
		else
		{
			actionDialogue.text = rightQuote;
		}
	}

	private void Update()
    {
		//Dialogue Text Handeling
		textColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - sideTrigger) / divideValue, 1);
		if (cardGameObject.transform.position.x > sideTrigger)
		{	
			if (Input.GetMouseButtonUp(0))
			{
				currentCard.Right();
				NewCard();
			}
		}
		else if(cardGameObject.transform.position.x > -sideTrigger)
		{

		}
		else if (cardGameObject.transform.position.x > -sideTrigger)
		{
			textColor.a = 0;
		}
		else if(cardGameObject.transform.position.x > -sideTrigger)
		{
			
		}
		else
		{
			if (Input.GetMouseButtonUp(0))
			{
				currentCard.Left();
				NewCard();
			}
		}

		UpdateDialogue();

		//Movement
		if (Input.GetMouseButton(0) && cardLogic.isMouseOver)
		{
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			cardGameObject.transform.position = pos;
		}
		else
		{
			cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, new Vector2(0, 0), bounceBackForce);
		}
		//UI
		display.text = "" + textColor;
    }

	public void LoadCard(Card _card)
	{
		//cardSpriteRenderer.sprite = resourceManager.sprites[(int)_card.cardSprite];
		cardSpriteRenderer.sprite = _card.cardIcon;
		leftQuote = _card.leftQuote;
		rightQuote = _card.rightQuote;
		currentCard = testCard;
		characterDialogue.text = _card.dialogue;
	}

	public void NewCard()
	{
		int rollDice = Random.Range(0, resourceManager.cards.Length);
		LoadCard(resourceManager.cards[rollDice]);
	}
}