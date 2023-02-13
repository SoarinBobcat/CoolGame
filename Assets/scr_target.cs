using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_target : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Projectile"))
		{
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
	}
}
