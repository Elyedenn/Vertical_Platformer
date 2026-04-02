using UnityEngine;

public class PlatformCleaner : MonoBehaviour
{
	void Update()
	{
		float cameraBottom = Camera.main.transform.position.y - 10f;

		if(transform.position.y < cameraBottom )
		{
			Destroy(gameObject);
		}
	}
}
