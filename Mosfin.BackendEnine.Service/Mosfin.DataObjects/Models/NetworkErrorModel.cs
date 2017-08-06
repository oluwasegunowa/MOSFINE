using System;
using System.Collections.Generic;
using System.Linq;

namespace Mosfin.DataObjects.Models
{
	public class NetworkErrorModel
	{
		public NetworkErrorModel()
		{

		}
		public NetworkErrorModel(string message)
		{
			Message = message;
		}
		public string Message
		{
			get;
			set;
		}

		public string ConcatinatedErrorMessage
		{
			get { return string.Join("\n", Errors); }
		}
		public IDictionary<string, List<string>> ModelState
		{
			get;
			set;
		}
		private List<string> errors = new List<string>();
		public List<string> Errors
		{
			get
			{
				if (!errors.Any())
				{

					if (ModelState != null)
					{
						errors.AddRange(from model in ModelState
										from error in model.Value
										select error.Trim());
					}
					else if (!string.IsNullOrWhiteSpace(Message))
						errors.Add(Message);
				}
				return errors;
			}
		}
	}
}
