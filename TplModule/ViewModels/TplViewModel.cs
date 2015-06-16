using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.Practices.Prism.Commands;

namespace TplModule.ViewModels
{
    public interface IMethodsToBeTested
    {
        int GetStringLength(string input);
    }

    public class TplViewModel : ViewModelBase, IMethodsToBeTested
    {

        #region Slow Process

        public virtual int GetStringLength(string input)
        {
            //var del = new Delegate(this, "GetRandomStringAsync");

            //var p = () => GetRandomStringAsync();
            return input.Length;
        }


        public async Task<string> GetRandomStringAsync()
        {
            using (var w = new WebClient())
            {
                var content = await w.DownloadStringTaskAsync("http://www.google.com");

                return content.Length.ToString();

            }         
        }
        #endregion

        private DelegateCommand _commandExample;
        public DelegateCommand CommandExample
        {
            get
            {
                if (_commandExample == null)
                {
                    _commandExample = new DelegateCommand(CommandExampleAction);
                }
                return _commandExample;
            }
        }

        public void CommandExampleAction()
        {
            // Create an asynchrnous task for GetRandomString. StartNew create a task on a new thread of the threadpool

            var result = GetRandomStringAsync();

            //result.Wait();
            //AppendToResults(result.Result);

            // task.ContinueWith happens after the task has completed to execute 
            result.ContinueWith(t => AppendToResults(t.Result));


            //// Create an asynchrnous task for GetRandomString. StartNew create a task on a new thread of the threadpool
            //var getRandomStringTask = Task<string>.Factory.StartNew(GetRandomString);

            //// task.ContinueWith happens after the task has completed to execute
            //getRandomStringTask.ContinueWith(t =>
            //    {
            //        if (t.IsFaulted)
            //        {
            //            AppendToResults(string.Format("{0}", t.Exception));
            //        }
            //        else
            //        {
            //            AppendToResults(t.Result);
            //        }
            //    });


        }
    }
}
