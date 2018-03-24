using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Helpers
{
	public class LabFunctions
	{
		public static string GetLeader(string fileContents)
		{
			if (fileContents == null)
			{
				return "String is null";
			}
			var fileContentArray = fileContents.Split(',').OrderBy(x => x).ToList();

			var total = fileContentArray.Count();

			var sortedValue = from numbers in fileContentArray
							  group numbers by numbers into number
							  let count = number.Count()
							  orderby count descending
							  select new { Value = number.Key, Count = count };

			var leadingValueCount = sortedValue.First().Count;

			/*Adding this because the instrustion were abit ambiguos as to what had to be returned. 
			If this were a real life situation I would contact the person in charge of the spec
			PS sorry for this ugly comment, I believe there should be no comments in the code and 
			that the code should speak for itself through properly named variables and clean structure
			but if a company does use comments I would conform to meet their standards */
			Console.WriteLine("The leader is: " + sortedValue.First().Value);
			return leadingValueCount > total / 2 ? "1" : "-1";

		}
	}
}