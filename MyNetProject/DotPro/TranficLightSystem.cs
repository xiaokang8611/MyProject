using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DotPro
{
    /*
     1、信号灯   一直在变化10秒 两个 

2、车辆   

带有方向 12个方向

3、路 
两条路   四个方向



处理逻辑
1） 
     *

    车辆：  
    From: 在那条路上从南道到北 从北到南  从东到西  从西到东 
    To： 如果从西到东 那们他就有其他的三个方向  直行、向南、向北
     
     * 信号灯 
     * 红10秒绿灯10秒 需要两个红路灯 南北方向一个 东西方向一个 
     * 当南北是红灯时 则东西方向是路灯 倒计时
     
    ？？启动两个信号灯线程，一个是南北方向，一个是东西方向。
     *不断的循环，等到时刻后，就变颜色
     ？？同方向是否是有左转信号灯，有的话时间
     12个方向上队列上的车
     * 道路
     每一辆车就是一个线程
     
     
    
    



     */
    public partial class TranficLightSystem : Form
    {
        public TranficLightSystem()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
         AutoResetEvent[] arrAuto=new AutoResetEvent[12];
        //给每一个赋值
           // 分心.

        }
        //信号灯的问题 在信号灯发生变化时，则通知此方向的等待的车辆


        //十二条方向上的同步信号灯 
        public void ExecuteCar(object obj)
        {
            var car = obj as Car;
            if (car != null)
            {
                while (true)
                { 
                  //如果是
                  //获取信号好 是否有左转信号灯。
                 /*
                  如果信号灯为绿灯 
                  则查看前面是否有车在前面，如果没有则走，有则等待
                  //未红灯，则停止等待
                  
                  */
                }
            
            }
        }
        public void ExecteLight(Light obj)
        {
            var light = obj as Light;        
        
        }
        public LightStatus GetStatus(RoadDirection to)
        {
            return LightStatus.红;
        }
    }
    public class Light
    {
        public Light(RoadDirection RoadDirection, int LightSeconds)
        { 
        
        }
        public void Minutes()
        {
          
        }
        public void  Next()//到零边另一个状态
        { 
        
        }
        private RoadDirection _RoadDirection;
        public LightStatus LightStatus { get; set; }
        /// <summary>
        /// 变化的秒数
        /// </summary>
        private int _LightSeconds;
    }

    public enum LightStatus : byte
    { 
        红=1,
        绿=2
    }
    public class Car
    {
        public RoadDirection From { get; set; }
        public Rotate Rotate { get; set; }
        public AutoResetEvent autoEvent { get; set; }
    }

    public enum RoadDirection : byte
    { 
      西_东=1,
      东_西 = 2,
      南_北 = 3,
      北_南 = 4,
    }
    public enum Rotate : byte
    {
       直行=1,
       左转=2,
       右转=3
    }

}
