using System;
using System.Collections.Generic;

namespace Console.Statistics
{
	public class Statistics
	{
		static Dictionary<string, StatisticsNode> content = new Dictionary<string, StatisticsNode>();
		
		public Statistics()
		{
			
		}
		
		static public StatisticsNode GetNode(string key)
		{
			if (content.ContainsKey(key))
			{
				return content[key];
			}
			else
			{
				StatisticsNode node = new StatisticsNode();
				content.Add(key, node);
				return node;
			}
		}
		
		static public void WrightConsole()
		{
        	foreach(KeyValuePair<string, StatisticsNode> kvp in content)
        	{
            	System.Console.WriteLine("--- {0} ---", kvp.Key);
            	kvp.Value.WrightConsole();
            	System.Console.WriteLine();
       		}
		}
		
	}
}
