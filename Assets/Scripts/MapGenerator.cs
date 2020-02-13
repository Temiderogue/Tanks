public class MapCell
{
	public int X;
	public int Z;
}

public class MapGenerator
{

	private int _width = 100;
	private int _length = 100;


	public MapCell[,] GenerateMap() 
	{
		MapCell[,] _map = new MapCell[_width, _length];

		for (int x = 0; x < _width; x++)
		{
			for (int z = 0; z < _length; z++)
			{
				_map[x, z] = new MapCell { X = x, Z = z };
			}
		}
		return _map;
	}
}