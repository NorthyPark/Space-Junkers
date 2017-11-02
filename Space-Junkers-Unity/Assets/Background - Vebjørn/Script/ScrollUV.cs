using UnityEngine;
using System.Collections;

public class ScrollUV : MonoBehaviour {

	public float parralax = 2f;

	void Update () {

		MeshRenderer mr = GetComponent<MeshRenderer>();

		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.x += Time.deltaTime / parralax;
		offset.y += Time.deltaTime / parralax;



		mat.mainTextureOffset = offset;

	}

}
