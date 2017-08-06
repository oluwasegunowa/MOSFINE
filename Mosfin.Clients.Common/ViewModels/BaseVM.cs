using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Mosfin.DataObjects.Models;

namespace Mosfin.Clients.Common.ViewModels
{
    public class BaseVM: INotifyPropertyChanged
    {
		//private ITelephony _telephony;
		public NetworkErrorModel NetworkError { get; set; }


		private Dictionary<string, string> _errors;

		public string GENERIC_ERROR_MESSAGE = "Sorry,something went wrong on our end,please try again.";


		public BaseVM()
		{
			Errors = new Dictionary<string, string>();
		}

		public bool HasErrors
		{
			get
			{
				return Errors.Keys.Count > 0;
			}
		}

		public Dictionary<string, string> Errors;
		protected virtual void RaisePropertyChanged([CallerMemberName] string property = "")
		{
			RaisePropertyChanged(false, property);
		}

		public Boolean IsModified { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;



		public void SetModelErrors(BaseModel model)
		{
			if (model.HasErrors)
			{

				foreach (var key in model.Errors.Keys)
				{
					Errors[key] = model.Errors[key];
				}
			}
		}


		public void SetServiceErrors(NetworkErrorModel networkErrorModel)
		{
			if (networkErrorModel != null)
			{
				if (networkErrorModel.ModelState != null)
				{
					foreach (var key in networkErrorModel.ModelState?.Keys)
					{
						Errors[key] = networkErrorModel.ModelState[key]?.FirstOrDefault();
					}
				}
				else if (!string.IsNullOrEmpty(networkErrorModel.Message))
				{
					Errors["ErrorMessage"] = networkErrorModel.Message;
				}
			}
		}


		protected virtual void RaisePropertyChanged(bool causesModification,
			[CallerMemberName] string property = "")
		{
			IsModified = IsModified || causesModification;

			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(property));
			}
		}
    }
}
