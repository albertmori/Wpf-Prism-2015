using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.Practices.Prism.Commands;

namespace HomeModule.ViewModels
{
    public class SideMenuViewModel : ViewModelBase
    {
        #region 1. Properties for binding

        private string _labelText;
        public string LabelText
        {
            get { return _labelText; }
            set
            {
                _labelText = value;
                RaisePropertyChanged(() => LabelText);
                RaisePropertyChanged(() => LabelLength);
            }
        }


        public int? LabelLength
        {
            get
            {
                if (LabelText != null)
                {
                    return LabelText.Length;
                }
                return null;
            }
        }

        private string _messageText;
        public string MessageText
        {
            get { return _messageText; }
            set
            {
                _messageText = value;
                RaisePropertyChanged(() => MessageText);
            }
        }

        #endregion

        #region 2. Commands for binding

        // Example of command that takes an int parameter

        private DelegateCommand<int?> _commandExample;
        public DelegateCommand<int?> CommandExample
        {
            get
            {
                if (_commandExample == null)
                {
                    _commandExample = new DelegateCommand<int?>(CommandExampleAction);
                }
                return _commandExample;
            }
        }

        public void CommandExampleAction(int? commandParameter)
        {
            if (commandParameter.HasValue)
            {
                MessageText = String.Format("User introduced a string {0} long", commandParameter);
            }
            else
            {
                MessageText = String.Format("Please write something!");
            }
        }

        #endregion

        public SideMenuViewModel()
        {

        }
    }
}
