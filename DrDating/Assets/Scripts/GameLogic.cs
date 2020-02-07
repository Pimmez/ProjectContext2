using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
	//GameObjects
	[SerializeField] private GameObject cardGameObject;
	[SerializeField] private GameObject cardOutlineGameObject;
	[SerializeField] private SpriteRenderer cardSpriteRenderer;
	[SerializeField] private SpriteRenderer outlineSpriteRenderer;
	[SerializeField] private GameObject matchCardGameObject;
	[SerializeField] private CardLogic cardLogic;
	[SerializeField] private SpriteRenderer mobileSpriteRenderer;
	[SerializeField] private GameObject mobileBackgroundGameObject;
	private ResourceManager resourceManager;
	[SerializeField] private GameObject backgroundPhone;

	//Tweaking Variables
	[SerializeField] private float bounceBackForce = 1f;
	[SerializeField] private float sideMargin = 0.5f;
	[SerializeField] private float sideTrigger = 2f;
	[SerializeField] private float divideValue = 3f;
	private Color textColor;

	//UI
	[SerializeField] private TMP_Text display;
	[SerializeField] private TMP_Text characterDialogue;

	//Match Card Variables
	[SerializeField] private MatchCard currentMatchCard;
	[SerializeField] private SpriteRenderer matchCardSpriteRenderer;
	[SerializeField] private TMP_Text matchCardDialogue;

	//Card Variables
	[SerializeField] private Card currentCard;
	private string leftQuote;
	private string rightQuote;
	private int newsCounter = 0;
	private int sustainabilityCounter = 0;
	private int fakeNewsCounter = 0;
	private int scienceCounter = 0;
	private int cardCounter;
	[SerializeField] private Color outlineColor;
	[SerializeField] private Color outlineColorLeft;
	[SerializeField] private Color outlineColorRight;


	private Vector2 cardTempPosition;

	[SerializeField] private Sprite image1;
	[SerializeField] private Sprite image2;


	private void Awake()
	{
		mobileSpriteRenderer = mobileBackgroundGameObject.GetComponent<SpriteRenderer>();
		resourceManager = GetComponent<ResourceManager>();
		cardSpriteRenderer = cardGameObject.GetComponent<SpriteRenderer>();
		outlineSpriteRenderer = cardOutlineGameObject.GetComponent<SpriteRenderer>();
		matchCardSpriteRenderer = matchCardGameObject.GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		backgroundPhone.SetActive(true);
		mobileSpriteRenderer.sprite = image1; 
		matchCardGameObject.SetActive(false);
		cardTempPosition = gameObject.transform.position;
		cardCounter = 0;
		LoadCard(resourceManager.cards[cardCounter]);
	}

	private void Update()
    {
		//Dialogue Text Handeling
		textColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - sideTrigger) / divideValue, 1);
		outlineSpriteRenderer.color = outlineColor;
		if (cardGameObject.transform.position.x > sideTrigger)
		{
			outlineSpriteRenderer.color = outlineColorRight;
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
			outlineSpriteRenderer.color = outlineColorLeft;

			if (Input.GetMouseButtonUp(0))
			{
				currentCard.Left();
				DecreaseCountCardTags(resourceManager.cards[cardCounter]);
				NewCard();
			}
		}

		//Movement
		if (Input.GetMouseButton(0) && cardLogic.isMouseOver)
		{
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			cardGameObject.transform.position = pos;
		}
		else
		{
			cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, cardTempPosition, bounceBackForce);
		}
		
		//UI
		display.text = "" + textColor;
    }

	//Defines The Card:ScriptableObject
	private void LoadCard(Card _card)
	{
		cardSpriteRenderer.sprite = _card.cardIcon;
		currentCard = resourceManager.cards[cardCounter];
		characterDialogue.text = _card.dialogue;
	}

	private void LoadMatchCard(MatchCard _matchCard)
	{
		matchCardSpriteRenderer.sprite = _matchCard.matchCardIcon;
		matchCardDialogue.text = _matchCard.dialogue;
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
		/*
		if ((int)_card.cardTags == 2)
		{
			scienceCounter++;
		}
		if ((int)_card.cardTags == 3)
		{
			sustainabilityCounter++;
		}
		*/
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
		/*
		if ((int)_card.cardTags == 2)
		{
			scienceCounter--;
		}
		if ((int)_card.cardTags == 3)
		{
			sustainabilityCounter--;
		}
		*/
	}

	//ONLY USE NEWS AND FAKENEWS - COUNTER
	private void Matching()
	{
		cardGameObject.SetActive(false);
		Debug.Log("newsCounter " + newsCounter);
		Debug.Log("fakeNewsCounter " + fakeNewsCounter);

		Debug.Log("Initializing Matchup");

		if(newsCounter > fakeNewsCounter)
		{
			DoMatchupNEWS();
		}
		else if(fakeNewsCounter > newsCounter)
		{
			DoMatchupFAKENEWS();
		}
		else
		{
			return;
		}
	}

	//MAKE A SWITCH STATEMENT OUT OF THIS
	private void DoMatchupNEWS()
	{
		backgroundPhone.SetActive(false);
		mobileSpriteRenderer.sprite = image2;
		matchCardGameObject.SetActive(true);
		LoadMatchCard(resourceManager.matchCards[0]);
	}

	private void DoMatchupFAKENEWS()
	{
		backgroundPhone.SetActive(false);
		mobileSpriteRenderer.sprite = image2;
		matchCardGameObject.SetActive(true);
		LoadMatchCard(resourceManager.matchCards[1]);
	}
}