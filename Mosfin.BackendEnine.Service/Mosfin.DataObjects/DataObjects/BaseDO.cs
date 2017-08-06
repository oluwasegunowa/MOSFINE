using System;
using System.Collections.Generic;
using System.Linq;

namespace Mosfin.DataObjects.DataObjects
{
    public class BaseDO
    {
		public string Message { get; set; }
		public Dictionary<string, List<string>> ModelState { get; set; }

		public BaseDO()
		{
			this.Message = null;
			this.ModelState = new Dictionary<string, List<string>>();
		}

		public bool HasErrors
		{
			get
			{
				return !string.IsNullOrEmpty(Message) || ModelState.Any();
			}
		}

		private Dictionary<string, string> _errors;
		public Dictionary<string, string> Errors
		{
			get
			{
				if (_errors == null)
				{
					_errors = new Dictionary<string, string>();
					foreach (var key in ModelState.Keys)
					{
						_errors[key] = ModelState[key]?.FirstOrDefault();
					}
					if (!string.IsNullOrEmpty(Message))
					{
						_errors["ErrorMessage"] = Message;
					}
				}

				return _errors;
			}
		}
    }
}
