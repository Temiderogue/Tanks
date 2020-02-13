using UnityEngine;
public class MapSpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject[] _obstaclesType;
	public void Start () 
	{
		MapGenerator generator = new MapGenerator();
		MapCell[,] _map = generator.GenerateMap();

		for (int x = 0; x < _map.GetLength(0); x++)
		{
			for (int z = 0; z < _map.GetLength(1); z++)
			{
				int _randomNum = Random.Range(0, 100);
				if (_randomNum > 98)
				{
					int _obsNum = Random.Range(0, 8);
					Instantiate(_obstaclesType[_obsNum], new Vector3(x, 0, z), Quaternion.identity);
				}
			}
		}
	}
}
