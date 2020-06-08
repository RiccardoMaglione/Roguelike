using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneDarkElf : MonoBehaviour
{

	//manca la direzione del martello e manca che blocca il movimento del personaggio



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
	void Start()
	{
		InitialPosition = Hammer.transform.position;
		InitialRotation = Hammer.transform.rotation;
		
		startPos = Hammer.transform.position;
		targetPos = new Vector3(startPos.x + 6, startPos.y, startPos.z);
		startPosFinale = targetPos;
		targetPosFinale = new Vector3(startPosFinale.x - 6, startPosFinale.y, startPosFinale.z);
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.K) && isStart == false)
		{
			InitialPosition = Hammer.transform.position;
			InitialRotation = Hammer.transform.rotation;
			startPos = Hammer.transform.position;
			targetPos = new Vector3(startPos.x + 6, startPos.y, startPos.z);
			startPosFinale = targetPos;
			targetPosFinale = new Vector3(startPosFinale.x - 6, startPosFinale.y, startPosFinale.z);
			isStart = true;
		}
		if(isArrived == false && isStart == true)
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
			float x0 = startPosFinale.x;
			float x1 = targetPosFinale.x;
			float dist = x1 - x0;
			float nextX = Mathf.MoveTowards(Hammer.transform.position.x, x1, speed * Time.deltaTime);
			float baseY = Mathf.Lerp(startPosFinale.y, targetPosFinale.y, (nextX - x0) / dist);
			float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
			nextPosFinale = new Vector3(nextX, baseY + arc, Hammer.transform.position.z);

			Hammer.transform.rotation = LookAt2D(nextPosFinale - Hammer.transform.position);
			Hammer.transform.position = nextPosFinale;
		}
		if (nextPosFinale == startPos)
		{
			isArrived = false;
			isStart = false;
			Hammer.transform.position = InitialPosition;
			Hammer.transform.rotation = InitialRotation;
		}
	}

	static Quaternion LookAt2D(Vector2 forward)
	{
		return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
	}
}
