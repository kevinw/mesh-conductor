using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GLLineRenderer : MonoBehaviour {
	public List<Vector3> points;
	public Color color;
	public float lineWidth = 1.0f;

	static Material lineMaterial;

    static void CreateLineMaterial() {
        if (lineMaterial)
			return;

		var shader = Shader.Find("Hidden/Internal-Colored");
		lineMaterial = new Material(shader);
		lineMaterial.hideFlags = HideFlags.HideAndDontSave;
		lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
		lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
		lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
		lineMaterial.SetInt("_ZWrite", 0);
    }

	public void SetVertexCount(int vertexCount) {
		if (points.Capacity < vertexCount)
			points.Capacity = vertexCount;
	}

	public void SetPosition(int index, Vector3 point) {
		while (points.Count < index + 1)
			points.Add(new Vector3(0, 0, 0));

		points[index] = point;
	}

	public void OnRenderObject() {
		CreateLineMaterial();
		lineMaterial.SetPass(0);

        GL.PushMatrix();
        GL.Begin(GL.QUADS);
        GL.Color(color);

		if (points.Count >= 2)
			for (var i = 0; i < points.Count - 1; ++i) {
				var start = points[i];
				var end = points[i + 1];
				Debug.Log(start + " " + end);
				GL.Vertex3(start.x, start.y - lineWidth, start.z);
				GL.Vertex3(start.x, start.y + lineWidth, start.z);
				GL.Vertex3(end.x, end.y + lineWidth, end.z);
				GL.Vertex3(end.x, end.y - lineWidth, end.z);
			}

        GL.End();
        GL.PopMatrix();
	}
}
