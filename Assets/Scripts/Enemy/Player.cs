using UnityEngine;

public class Player : MonoBehaviour {

	private MazeCell currentCell;

	public void SetLocation (MazeCell cell) {
		currentCell = cell;
		transform.localPosition = cell.transform.localPosition;
	}
}