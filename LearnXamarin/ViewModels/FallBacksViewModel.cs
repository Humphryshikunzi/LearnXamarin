using System;
using System.Collections.Generic;
using System.Text;

namespace LearnXamarin.ViewModels
{
    class FallBacksViewModel : BaseViewModel
    {
		private  string  textValue = "Jambo Africa, wake up the Sun is Shining";

		public  string  TextValue
		{
			get { return  textValue; }
			set 
			{
				textValue = value;
				OnPropertyChanged("TextValue");
			}
		}
	
		public string Text2Value { get; set; }  


	}
}
