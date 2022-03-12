using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public Joystick Joystick_Move;
	public Joystick Joystick_Mouse;
	public bool pauza;
	public Camera CamerPlayer;
	//Obiekt odpowiedzialny za ruch gracza.
	public CharacterController characterControler;

	//Prêdkoœæ poruszania siê gracza.
	public float predkoscPoruszania = 9.0f;
	//Wysokoœæ skoku.
	public float wysokoscSkoku = 7.0f;
	//Aktualna wysokosc skoku.
	public float aktualnaWysokoscSkoku = 0f;
	//Predkosc biegania.
	public float predkoscBiegania = 7.0f;

	//Czuloœæ myszki (Sensitivity)
	public float czuloscMyszki = 3.0f;
	public float myszGoraDol = 0.0f;
	//Zakres patrzenia w górê i dó³.
	public float zakresMyszyGoraDol = 90.0f;

	// Use this for initialization
	void Start()
	{
		characterControler = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!pauza) { 
		klawiatura();
		myszka();
	}
	}
	private void klawiatura()
	{
		float rochPrzodTyl = Joystick_Move.Vertical * predkoscPoruszania;
		float rochLewoPrawo = Joystick_Move.Horizontal * predkoscPoruszania;
		Vector3 ruch = new Vector3(rochLewoPrawo, aktualnaWysokoscSkoku ,rochPrzodTyl);
		ruch = transform.rotation * ruch;

		characterControler.Move(ruch * Time.deltaTime);
	}
	private void myszka()
	{

		float myszLewoPrawo = Joystick_Mouse.Horizontal* czuloscMyszki;
		transform.Rotate(0, myszLewoPrawo, 0);
		myszGoraDol -= Joystick_Mouse.Vertical * czuloscMyszki;
		myszGoraDol = Mathf.Clamp(myszGoraDol, -zakresMyszyGoraDol, zakresMyszyGoraDol);
		CamerPlayer.transform.localRotation = Quaternion.Euler(myszGoraDol, 0, 0);
	}

}