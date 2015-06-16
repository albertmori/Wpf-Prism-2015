using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.Practices.Prism.Commands;
using System.Reactive;
using System.Reactive.PlatformServices;

namespace RXModule.ViewModels
{
    public class RXViewModel : ViewModelBase
    {

        #region 1. Properties for binding

        #endregion

        #region 2. Commands for binding
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

        public string LongOperation(int value)
        {
            Thread.Sleep(500);
            return string.Format("Processing value:{0} on worker thread {1} background: {2}", value.ToString(), Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground);
        }

        public void CommandExampleAction()
        {

            AppendToResults(string.Format("Dispatcher (UI) Thread {0}", Thread.CurrentThread.ManagedThreadId));

            var query = Enumerable.Range(1, 25).Select(n => LongOperation(n));

            // The following execute the observable query on a ThreadPool thread
            var observableQuery = query.ToObservable().SubscribeOn(ThreadPoolScheduler.Instance).ObserveOn(DispatcherScheduler.Current.Dispatcher).Subscribe(n => AppendToResults(n), Completed);
           
            // Here we subscribe the OnNext method AppendToResults and OnCompeted Completed on the Dispatcher Thread, to return the results
            //observableQuery.ObserveOn(DispatcherScheduler.Current.Dispatcher).Subscribe(n => AppendToResults(n), Completed);

        }

        void Completed()
        {
            AppendToResults(string.Format("Completed on thread {0}", Thread.CurrentThread.ManagedThreadId));
        }

        #endregion

        public RXViewModel()
        {

        }
    }
}
