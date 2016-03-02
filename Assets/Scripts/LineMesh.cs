using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
public class LineMesh : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var verts = new Vector3[] { Vector3.up, Vector3.right, Vector3.down, Vector3.left};
		var indicesForLineStrip = new int[] {0, 1, 2, 3, 0};
		//int[] indicesForLines = new int[]{0,1,1,2,2,3,3,0};
		//
		var mesh = new Mesh();
		mesh.vertices = verts;
		mesh.SetIndices(indicesForLineStrip, MeshTopology.LineStrip, 0);
		//mesh.SetIndicies(indicesForLines, MeshTopology.Lines, 0);
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();

		GetComponent<MeshFilter>().mesh = mesh;
	}
}
