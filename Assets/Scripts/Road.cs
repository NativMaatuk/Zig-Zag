using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Road : MonoBehaviour
{
	public GameObject roadPrefab;
	public Vector3 lastpos;
	public static bool isUpTen = false;
	public float offset = 0.707f;
	public Material[] material;

	private int roadCount = 0;

	public  void StartBuilding(){
		InvokeRepeating("CreateNewRoadPart", 1f, .5f);
	}

	public void CreateNewRoadPart(){
		Debug.Log("Create new road part");
		Vector3 spawnPos = Vector3.zero;
		float chance = Random.Range(0, 100);
		if(chance < 50) {
			spawnPos = new Vector3(lastpos.x + offset, lastpos.y, lastpos.z + offset);
		} else
			spawnPos = new Vector3(lastpos.x - offset, lastpos.y, lastpos.z + offset);
		GameObject g = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0,45,0));
		lastpos = g.transform.position;
		//if(isUpTen)
		
		roadCount++;
		if(roadCount % 5 == 0){
			g.transform.GetChild(0).gameObject.SetActive(true);
		}
	}

}
