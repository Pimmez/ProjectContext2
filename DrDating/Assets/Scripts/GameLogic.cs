using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
	//GameObjects
	[SerializeField] private GameObject cardGameObject;
	[SerializeField] private CardLogic cardLogic;
	[SerializeField] private SpriteRenderer cardSpriteRenderer;
	private ResourceManager resourceManager;

	//Tweaking Variables
	[SerializeField] private float bounceBackForce = 1f;
	[SerializeField] private float sideMargin = 0.5f;
	[SerializeField] private float sideTrigger = 2f;
	[SerializeField] private float divideValue = 3f;
	private Color textColor;

	//UI
	[SerializeField] private TMP_Text display;
	[SerializeField] private TMP_Text characterDialogue;
	[SerializeField] private TMP_Text actionDialogue;

	//Card Variables
	[SerializeField] private Card currentCard;
	private string leftQuote;
	private string rightQuote;
	private int newsCounter = 0;
	private int sustainabilityCounter = 0;
	private int fakeNewsCounter = 0;
	private int scienceCounter = 0;
	private int cardCounter;


	private void Awake()
	{
		resourceManager = GetComponent<ResourceManager>();
		cardSpriteRenderer = cardGameObject.GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		cardCounter = 0;
		LoadCard(resourceManager.cards[cardCounter]);
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
				IncreaseCountCardTags(resourceManager.cards[cardCounter]);
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
				DecreaseCountCardTags(resourceManager.cards[cardCounter]);
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

	//Defines The Card:ScriptableObject
	private void LoadCard(Card _card)
	{
		cardSpriteRenderer.sprite = _card.cardIcon;
		leftQuote = _card.leftQuote;
		rightQuote = _card.rightQuote;
		currentCard = resourceManager.cards[cardCounter];
		characterDialogue.text = _card.dialogue;
	}

	//Makes A Random Card Chain
	private void NewCard()
	{
		if(cardCounter == resourceManager.cards.Length -1)
		{
			Matching();
		}
		else
		{
			cardCounter++;
			LoadCard(resourceManager.cards[cardCounter]);
		}
	}

	private void IncreaseCountCardTags(Card _card)
	{
		if((int)_card.cardTags == 0)
		{
			newsCounter++;
		}
		if ((int)_card.cardTags == 1)
		{
			fakeNewsCounter++;
		}
		if ((int)_card.cardTags == 2)
		{
			scienceCounter++;
		}
		if ((int)_card.cardTags == 3)
		{
			sustainabilityCounter++;
		}
	}

	private void DecreaseCountCardTags(Card _card)
	{
		if ((int)_card.cardTags == 0)
		{
			newsCounter--;
		}
		if ((int)_card.cardTags == 1)
		{
			fakeNewsCounter--;
		}
		if ((int)_card.cardTags == 2)
		{
			scienceCounter--;
		}
		if ((int)_card.cardTags == 3)
		{
			sustainabilityCounter--;
		}
	}

	private void Matching()
	{
		cardGameObject.SetActive(false);
		Debug.Log("newsCounter " + newsCounter);
		Debug.Log("fakeNewsCounter " + fakeNewsCounter);
		Debug.Log("ScienceCounter " + scienceCounter);
		Debug.Log("SustainabilityCounter " + sustainabilityCounter);

		Debug.Log("Initializing Matchup");
	}
}