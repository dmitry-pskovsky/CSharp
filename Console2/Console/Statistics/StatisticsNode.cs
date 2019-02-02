using System;
using System.Collections.Generic;

namespace Console.Statistics
{
	public class StatisticsNode
	{
		Dictionary<string, int> content;
		
		public StatisticsNode()
		{
			content = new Dictionary<string, int>();
		}
		
		public void incrementValue(String key)
		{
			if (content.ContainsKey(key))
			{
				content[key] = content[key] += 1;
			}
			else
			{
				content.Add(key, 1);
			}

		}
		
		public void WrightConsole()
		{
			float coeficient = 0f;
			int summ = 0;
			
			foreach(KeyValuePair<string, int> kvp in content)
        	{
				summ += kvp.Value;
       		}
			coeficient = summ / 100f;
			
        	foreach(KeyValuePair<string, int> kvp in content)
        	{
            	System.Console.WriteLine("{0}: {1}% ({2})", 
        		                         kvp.Key, Math.Round(kvp.Value / coeficient, 1), kvp.Value);
       		}
		}
		
		
	}
}
