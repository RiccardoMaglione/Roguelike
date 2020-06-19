using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneDarkElf : MonoBehaviour
{
    #region Variables
    //manca la direzione del martello e manca che blocca il movimento del personaggio

    public GameObject[] player;
	bool SpellReady = true;
	public float CooldownRune = 6f;
	[Tooltip("Position we want to hit")]
	public Vector3 targetPos;

	[Tooltip("Horizontal speed, in units/sec")]
	public float speed = 10;

	[Tooltip("How high the arc should be, in units")]
	public float arcHeight = 1;


	public Vector3 startPos;
	Vector3 nextPos;

	public Vector3 startPosFinale;
	Vector3 nextPosFinale;
	public Vector3 targetPosFinale;

	public GameObject Hammer;
	public bool isArrived = false;
	public bool isStart = false;


	public Vector3 InitialPosition;
	public Quaternion InitialRotation;
	#endregion

	public bool X = false;
	public bool Z = false;

	void Start()
	{
		player = GameObject.FindGameObjectsWithTag("Player");
		Hammer = GameObject.FindGameObjectWithTag("Weapon");
		//InitialPosition = Hammer.transform.position;
		//InitialRotation = Hammer.transform.rotation;
		//
		//startPos = Hammer.transform.position;
		//targetPos = new Vector3(startPos.x + 6, startPos.y, startPos.z);
		//startPosFinale = targetPos;
		//targetPosFinale = new Vector3(startPosFinale.x - 6, startPosFinale.y, startPosFinale.z);
	}

	void Update()
	{
		if (InventorySystem.tempIDarkElf == 0)
		{
			if ((Input.GetKeyDown(ControlsManager.CM.runeOne) || Input.GetKeyDown(KeyCode.JoystickButton2)) && SpellReady == true && isStart == false)
			{
				PlayerManager.CanMove = false;
				InitialPosition = Hammer.transform.position;
				InitialRotation = Hammer.transform.rotation;
				startPos = Hammer.transform.position;
				if(PlayerManager.DirectionD == 1)
				{
					X = true;
					//PlayerManager.DirectionD = 0;
					targetPos = new Vector3(startPos.x + 6, startPos.y, startPos.z);
				}
				if (PlayerManager.DirectionA == 1)
				{
					X = true;
					//PlayerManager.DirectionA = 0;
					targetPos = new Vector3(startPos.x - 6, startPos.y, startPos.z);
				}
				if (PlayerManager.DirectionW == 1)
				{
					Z = true;
					//PlayerManager.DirectionD = 0;
					targetPos = new Vector3(startPos.x, startPos.y, startPos.z + 6);
				}
				if (PlayerManager.DirectionS == 1)
				{
					Z = true;
					//PlayerManager.DirectionA = 0;
					targetPos = new Vector3(startPos.x, startPos.y, startPos.z - 6);
				}
				startPosFinale = targetPos;

				if (PlayerManager.DirectionD == 1)
				{
					PlayerManager.DirectionD = 0;
					targetPosFinale = new Vector3(startPosFinale.x - 6, startPosFinale.y, startPosFinale.z);
				}
				if (PlayerManager.DirectionA == 1)
				{
					PlayerManager.DirectionA = 0;
					targetPosFinale = new Vector3(startPosFinale.x + 6, startPosFinale.y, startPosFinale.z);
				}
				if (PlayerManager.DirectionW == 1)
				{
					PlayerManager.DirectionW = 0;
					targetPosFinale = new Vector3(startPosFinale.x, startPosFinale.y, startPosFinale.z - 6);
				}
				if (PlayerManager.DirectionS == 1)
				{
					PlayerManager.DirectionS = 0;
					targetPosFinale = new Vector3(startPosFinale.x, startPosFinale.y, startPosFinale.z + 6);
				}

				//targetPosFinale = new Vector3(startPosFinale.x - 6, startPosFinale.y, startPosFinale.z);
				isStart = true;
				Ammo.AmmoW--;
				Ammo.NumAmmoW0.text = Ammo.AmmoW.ToString();
				SpellReady = false;
				StartCoroutine(cooldown());
			}
		}
		if (InventorySystem.tempIDarkElf == 1)
		{
			if ((Input.GetKeyDown(ControlsManager.CM.runeTwo) || Input.GetKeyDown(KeyCode.JoystickButton1)) && SpellReady == true && isStart == false)
			{
				WallTrigger.WallA = 0;
				WallTrigger.WallW = 0;
				WallTrigger.WallS = 0;
				WallTrigger.WallD = 0;
				InitialPosition = Hammer.transform.position;
				InitialRotation = Hammer.transform.rotation;
				startPos = Hammer.transform.position;
				if (PlayerManager.DirectionD == 1)
				{
					X = true;
					//PlayerManager.DirectionD = 0;
					targetPos = new Vector3(startPos.x + 6, startPos.y, startPos.z);
				}
				if (PlayerManager.DirectionA == 1)
				{
					X = true;
					//PlayerManager.DirectionA = 0;
					targetPos = new Vector3(startPos.x - 6, startPos.y, startPos.z);
				}
				if (PlayerManager.DirectionW == 1)
				{
					Z = true;
					//PlayerManager.DirectionD = 0;
					targetPos = new Vector3(startPos.x, startPos.y, startPos.z + 6);
				}
				if (PlayerManager.DirectionS == 1)
				{
					Z = true;
					//PlayerManager.DirectionA = 0;
					targetPos = new Vector3(startPos.x, startPos.y, startPos.z - 6);
				}
				startPosFinale = targetPos;
				if (PlayerManager.DirectionD == 1)
				{
					PlayerManager.DirectionD = 0;
					targetPosFinale = new Vector3(startPosFinale.x - 6, startPosFinale.y, startPosFinale.z);
				}
				if (PlayerManager.DirectionA == 1)
				{
					PlayerManager.DirectionA = 0;
					targetPosFinale = new Vector3(startPosFinale.x + 6, startPosFinale.y, startPosFinale.z);
				}
				if (PlayerManager.DirectionW == 1)
				{
					PlayerManager.DirectionW = 0;
					targetPosFinale = new Vector3(startPosFinale.x, startPosFinale.y, startPosFinale.z - 6);
				}
				if (PlayerManager.DirectionS == 1)
				{
					PlayerManager.DirectionS = 0;
					targetPosFinale = new Vector3(startPosFinale.x, startPosFinale.y, startPosFinale.z + 6);
				}
				isStart = true;
				Ammo.AmmoW--;
				Ammo.NumAmmoW1.text = Ammo.AmmoW.ToString();
				SpellReady = false;
				StartCoroutine(cooldown());
			}
		}

		if(isArrived == false && isStart == true)
		{
			if (X == true)
			{
				float x0 = startPos.x;
				float x1 = targetPos.x;
				float dist = x1 - x0;
				float nextX = Mathf.MoveTowards(Hammer.transform.position.x, x1, speed * Time.deltaTime);
				float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - x0) / dist);
				float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
				nextPos = new Vector3(nextX, baseY + arc, Hammer.transform.position.z);
				Hammer.transform.rotation = LookAt2D(nextPos - Hammer.transform.position);
				Hammer.transform.position = nextPos;
			}
			if (Z == true)
			{
				float z0 = startPos.z;
				float z1 = targetPos.z;
				float distz = z1 - z0;
				float nextZ = Mathf.MoveTowards(Hammer.transform.position.z, z1, speed * Time.deltaTime);
				float baseYZ = Mathf.Lerp(startPos.y, targetPos.y, (nextZ - z0) / distz);
				float arcz = arcHeight * (nextZ - z0) * (nextZ - z1) / (-0.25f * distz * distz);
				nextPos = new Vector3(Hammer.transform.position.x, baseYZ + arcz, nextZ);
				Hammer.transform.rotation = LookAt2DR(nextPos - Hammer.transform.position);
				Hammer.transform.position = nextPos;
			}
		}
		if (nextPos == targetPos && isStart == true)
		{
			isArrived = true;
			Arrived();
			
		}
	}

	void Arrived()
	{
		if (isArrived == true)
		{
			if (X == true)
			{
				float x0 = startPosFinale.x;
				float x1 = targetPosFinale.x;
				float dist = x1 - x0;
				float nextX = Mathf.MoveTowards(Hammer.transform.position.x, x1, speed * Time.deltaTime);
				float baseY = Mathf.Lerp(startPosFinale.y, targetPosFinale.y, (nextX - x0) / dist);
				float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
				nextPosFinale = new Vector3(nextX, baseY + arc, Hammer.transform.position.z);
				//X = false;
				Hammer.transform.rotation = LookAt2D(nextPosFinale - Hammer.transform.position);
				Hammer.transform.position = nextPosFinale;
			}
			if (Z == true)
			{
				float z0 = startPosFinale.z;
				float z1 = targetPosFinale.z;
				float distz = z1 - z0;
				float nextZ = Mathf.MoveTowards(Hammer.transform.position.z, z1, speed * Time.deltaTime);
				float baseYz = Mathf.Lerp(startPosFinale.y, targetPosFinale.y, (nextZ - z0) / distz);
				float arcz = arcHeight * (nextZ - z0) * (nextZ - z1) / (-0.25f * distz * distz);
				nextPosFinale = new Vector3(Hammer.transform.position.x, baseYz + arcz, nextZ);
				//Z = false;
				Hammer.transform.rotation = LookAt2DR(nextPosFinale - Hammer.transform.position);
				Hammer.transform.position = nextPosFinale;
			}

		}
		if (nextPosFinale == startPos)
		{
			isArrived = false;
			isStart = false;
			Hammer.transform.position = InitialPosition;
			Hammer.transform.rotation = InitialRotation;
			PlayerManager.CanMove = true;
		}
	}

	static Quaternion LookAt2D(Vector2 forward)
	{
		return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
	}
	static Quaternion LookAt2DR(Vector2 forward)
	{
		return Quaternion.Euler(0, 90, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
	}


	public IEnumerator cooldown()
	{
		if (InventorySystem.tempIDarkElf == 0)
		{
			player[0].GetComponent<Ammo>().SlotRuneOne.texture = player[0].GetComponent<Ammo>().RuneDarkElfTexture[1];
			yield return new WaitForSeconds(CooldownRune);
			SpellReady = true;
			player[0].GetComponent<Ammo>().SlotRuneOne.texture = player[0].GetComponent<Ammo>().RuneDarkElfTexture[0];
		}
		if (InventorySystem.tempIDarkElf == 1)
		{
			player[0].GetComponent<Ammo>().SlotRuneTwo.texture = player[0].GetComponent<Ammo>().RuneDarkElfTexture[1];
			yield return new WaitForSeconds(CooldownRune);
			SpellReady = true;
			player[0].GetComponent<Ammo>().SlotRuneTwo.texture = player[0].GetComponent<Ammo>().RuneDarkElfTexture[0];
		}
	}
}
