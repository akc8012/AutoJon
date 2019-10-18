using System;
using System.Collections.Generic;

public class ShuffleBox
{
	readonly Random RandomGenerator = new Random();

	// https://stackoverflow.com/a/1262619
	public List<T> Shuffle<T>(List<T> list)
	{
		int n = list.Count;
		while (n > 1)
		{
			n--;
			int k = RandomGenerator.Next(n + 1);
			var value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
		return list;
	}
}
