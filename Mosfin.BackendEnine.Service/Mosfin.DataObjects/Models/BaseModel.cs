using System;
using System.Collections.Generic;
using Mosfin.DataObjects.DataObjects;

namespace Mosfin.DataObjects.Models
{
	public class BaseModel
	{
		private Dictionary<string, string> _errors;
		public Dictionary<string, string> Errors { get { return _errors; } }

		public BaseModel()
		{
			this._errors = new Dictionary<string, string>();
		}

		public BaseModel(BaseDO dataObject)
		{
			foreach (var key in dataObject.ModelState.Keys)
			{
				Errors[key] = dataObject.ModelState[key][0];
			}
		}

		public bool HasErrors
		{
			get
			{
				return Errors.Keys.Count > 0;
			}
		}
	}
}
