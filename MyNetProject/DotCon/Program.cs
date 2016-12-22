using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;

namespace DotCon
{
    class Program
    {
        static void Main(string[] args)
        {
            //Action<string> a = Method1;
            //a.Invoke("dsfs");
           // a.BeginInvoke("aa", CallBack, "1234567890");
            Func<int, int, int> a = Sum;
            //a.BeginInvoke(100, 10, new AsyncCallback(CallBack), "123456");
            var endCallback = new AsyncCallback((IAsyncResult iasyn) =>
            {
              
                var asyn = (AsyncResult)iasyn;
                var result = ((Func<int, int, int>)asyn.AsyncDelegate).EndInvoke(iasyn);
                OutPut("result:" + result + asyn.AsyncDelegate.ToString());
            });
            a.BeginInvoke(100, 10, endCallback, "123456");
            OutPut("main");
            Console.ReadKey();
            
        }
        public static int Sum(int x,int y)
        {
            OutPut("inside sum");
            System.Threading.Thread.Sleep(100);
            return x + y;
        }
        public static  void OutPut(string s)
        {
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId + ":" + s);
        }
        public static void Method1(string s)
        {
            OutPut(s+"进入等待");
            System.Threading.Thread.Sleep(3000);
            OutPut(s + "结束");
        }
        public static void CallBack(IAsyncResult iasyn)
        {
            var asyn = (AsyncResult)iasyn;
            var result=  ((Func<int, int, int>)asyn.AsyncDelegate).EndInvoke(iasyn);
            OutPut("result:"+result + asyn.AsyncDelegate.ToString());
        }
    }
}
