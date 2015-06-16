using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        #region 1. INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise property changed to be called with property name:
        /// </summary>
        /// <param name="propertyName"></param>
        public void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Raise property changed to be called with lambda expression:
        /// PropertyChanged.Raise(() => this.Now);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyExpression"></param>
        public void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                var body = propertyExpression.Body as MemberExpression;
                var expression = body.Expression as ConstantExpression;
                handler(expression.Value, new PropertyChangedEventArgs(body.Member.Name));
            }
        }
        #endregion

        //#region 2. Service Proxies

        //private WebServiceClient _serviceClient;
        //public WebServiceClient ServiceClient
        //{
        //    get
        //    {
        //        if (_serviceClient == null)
        //        {
        //            _serviceClient = new WebServiceClient();
        //        }
        //        return _serviceClient;
        //    }
        //}


        //#endregion

        #region 3. DesignMode

        #endregion

        #region 4. Methods
        public void AppendToResults(string value)
        {
            Results += string.Format("{0}\n", value);
        }

        private string _results = "Nothing";
        public string Results
        {
            get { return _results; }
            set
            {
                if (_results != value)
                {
                    _results = value;
                    RaisePropertyChanged("Results");
                }
            }
        }
        #endregion
    }
}
