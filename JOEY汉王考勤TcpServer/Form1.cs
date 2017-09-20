/* ----------------------------------------------------------
 * 文件名称：Form1.cs
 * 作者：秦建辉
 * 
 * 微信：splashcn
 * 
 * 博客：http://www.firstsolver.com/wordpress/
 * 
 * 开发环境：
 *      Visual Studio V2013
 *      .NET Framework 4.0
 *      
 * 版本历史：
 *      V1.1	2016年07月14日
 *              因SDK改进更新代码
 *              
 *      V1.0	2014年09月12日
 *              人脸通SDK演示：接收卡点数据
------------------------------------------------------------ */
using Com.FirstSolver.Splash;

using System;
using System.Collections.Generic;
using System.Management;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PMSoft.Domain.Attendance.Interface;
using PMSoft.Domain.Attendance.Respository;
using PMSoft.Basic.Core.Models;

namespace Splash
{
    public partial class Form1 : Form
    {
        IAttendanceRecordContract _attendanceRecordContract = new AttendanceRecordContract();

        /// <summary>
        /// 设备通信字符集编码为简体中文
        /// </summary>           
        private const int DeviceCodePage = 936;

        /// <summary>
        /// 心跳包接收服务器
        /// </summary>
        private TcpListenerPlus TcpServer = null;

        /// <summary>
        /// 服务器是否已运行
        /// </summary>
        private bool IsServerRunning = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxAnswer.Clear();
        }

        private void buttonStartListener_Click(object sender, EventArgs e)
        {
            if (IsServerRunning)
            {
                TcpServer.Stop();
                TcpServer = null;

                IsServerRunning = false;
                buttonStartListener.Text = "开启侦听";
            }
            else
            {
                try
                {
                    TcpServer = new TcpListenerPlus(IPAddress.Parse(comboBoxServerIP.Text), Convert.ToInt32(textBoxServerPort.Text), checkBoxPassiveEncryption.Checked);
                    TcpServer.OnServerTaskRequest += OnServerTaskProcess;

                    // 启动侦听
                    TcpServer.StartListenThread(null, 0, 10 * 60 * 1000);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                IsServerRunning = true;
                buttonStartListener.Text = "停止侦听";
            }
        }

        // 接收数据处理程序
        private void OnServerTaskProcess(object sender, EventArgs e)
        {
            NetworkStreamPlus Stream = (NetworkStreamPlus)sender;

            AttendanceRecord model = new AttendanceRecord();

            while (true)
            {
                try
                {
                    string Answer;
                    Stream.Read(out Answer, DeviceCodePage);

                    // 显示接收字符串
                    //this.Invoke(new Action(() =>
                    //{
                    //    textBoxAnswer.AppendText(Answer + "\r\n");
                    //}));

                    if (Answer.StartsWith("PostRecord"))
                    {
                        // 提取序列号并保存 
                        model.SerialNumber = FaceId_Item.GetKeyValue(Answer, "sn"); // 设备序列号
                        // 答复已准备好接收考勤记录
                        if (checkBoxPostPhoto.Checked)
                        {   // 上传照片
                            Stream.Write("Return(result=\"success\" postphoto=\"true\")", DeviceCodePage);
                        }
                        else
                        {   // 不上传照片
                            Stream.Write("Return(result=\"success\" postphoto=\"false\")", DeviceCodePage);
                        }
                    }
                    else if (Answer.StartsWith("Record"))
                    {   // 读取考勤记录
                        Stream.Write("Return(result=\"success\")", DeviceCodePage);   // 答复数据接收成功
                         
                        model.PersonID = int.Parse(FaceId_Item.GetKeyValue(Answer, "id"));
                        model.ReceiveDate = DateTime.Parse(FaceId_Item.GetKeyValue(Answer, "time"));
                        model.ReceiveType = 0; 
                        model.Reason = 1; 
                        model.CardNumber = ""; 
                        model.ExtendParam = "0"; 
                        model.Score = "101"; 
                        model.Status = 1; 
                        model.UserData = "0"; 
                        model.PhotoData = FaceId_Item.GetKeyValue(Answer, "photo");
                        model.PhotoLen = model.PhotoData.Length.ToString(); 
                         
                    }
                    else if (Answer.StartsWith("PostEmployee"))
                    {   // 准备上传人员
                        Stream.Write("Return(result=\"success\")", DeviceCodePage);
                    }
                    else if (Answer.StartsWith("Employee"))
                    {   // 接收人员数据
                        Stream.Write("Return(result=\"success\")", DeviceCodePage);   // 答复数据接收成功
                    }
                    else if (Answer.StartsWith("GetRequest"))
                    {   // 下发命令
                        this.Invoke(new Action(() =>
                        {
                            string Command = textBoxCommand.Text;
                            if (!string.IsNullOrEmpty(Command))
                            {
                                Stream.Write(Command, DeviceCodePage);
                                textBoxCommand.Clear();
                            }
                        }));
                    }
                    else if (Answer.StartsWith("Quit"))
                    {   // 连接断开
                        if (!string.IsNullOrEmpty(model.SerialNumber) && model.PersonID != 0)
                        {
                            Log.Info(string.Format("考勤机序列号：{0}|工号：{1}|打卡时间点：{2}|上下班：{3}|状态：{4}|来源：{5}", model.SerialNumber, model.PersonID, model.ReceiveDate, model.ReceiveType, model.Status, model.Reason));
                            try
                            {
                                _attendanceRecordContract.SaveAttendanceRecord(model);
                            }
                            catch (Exception ex)
                            {
                                Log.Info("考勤记录写入失败,考勤机序列号:" + model.SerialNumber + "考勤工号:" + model.PersonID + ",异常信息:" + ex.ToString());
                            }
                        }
                        break;
                    }
                }
                catch (System.Net.Sockets.SocketException)
                {   // 套接字关闭                    
                    break;
                }
                catch (System.IO.IOException)
                {   // 套接字关闭
                    break;
                }
                catch (System.ObjectDisposedException)
                {   // 套接字关闭
                    break;
                }
                catch (Exception ex)
                {
                    string ErrorMessage = "错误信息：" + ex.GetType().Name;
                    MessageBox.Show(ErrorMessage, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 列举本机所有的有效IP地址（自动过滤掉虚拟网卡IP地址）
            string[] IPCollection = GetLocalIPv4Address();
            if (IPCollection != null)
            {
                comboBoxServerIP.DataSource = IPCollection;
                comboBoxServerIP.Enabled = !(IPCollection.Length == 1);  // 如果本机只有一个有效IP地址，则直接锁定
            }

            textBoxCommand.MaxLength = 0;
            textBoxAnswer.MaxLength = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TcpServer != null) { TcpServer.Stop(); TcpServer = null; }
        }

        /// <summary>
        /// 获取本机IP地址列表
        /// </summary>
        /// <param name="isIncludeUsb">是否包含USB网卡，默认为不包含</param>
        /// <returns>本机真实网卡信息</returns>
        public static string[] GetLocalIPv4Address(bool isIncludeUsb = false)
        {   // IPv4正则表达式
            const string IPv4RegularExpression = "^(?:(?:25[0-5]|2[0-4]\\d|((1\\d{2})|([1-9]?\\d)))\\.){3}(?:25[0-5]|2[0-4]\\d|((1\\d{2})|([1-9]?\\d)))$";

            // 注意：只获取已连接的网卡
            string NetworkAdapterQueryString;
            if (isIncludeUsb)
                NetworkAdapterQueryString = "SELECT * FROM Win32_NetworkAdapter WHERE (NetConnectionStatus = 2) AND (MACAddress IS NOT NULL) AND (NOT (PNPDeviceID LIKE 'ROOT%'))";
            else
                NetworkAdapterQueryString = "SELECT * FROM Win32_NetworkAdapter WHERE (NetConnectionStatus = 2) AND (MACAddress IS NOT NULL) AND (NOT (PNPDeviceID LIKE 'ROOT%')) AND (NOT (PNPDeviceID LIKE 'USB%'))";

            ManagementObjectCollection NetworkAdapterQueryCollection = new ManagementObjectSearcher(NetworkAdapterQueryString).Get();
            if (NetworkAdapterQueryCollection == null) return null;

            List<string> IPv4AddressList = new List<string>(NetworkAdapterQueryCollection.Count);
            foreach (ManagementObject mo in NetworkAdapterQueryCollection)
            {
                // 获取网卡配置信息
                string ConfigurationQueryString = "SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Index = " + mo["Index"];
                ManagementObjectCollection ConfigurationQueryCollection = new ManagementObjectSearcher(ConfigurationQueryString).Get();
                if (ConfigurationQueryCollection == null) continue;

                foreach (ManagementObject nacmo in ConfigurationQueryCollection)
                {
                    if ((bool)nacmo["IPEnabled"])
                    {
                        string[] IPCollection = nacmo["IPAddress"] as string[]; // IP地址
                        if (IPCollection != null)
                        {
                            foreach (string adress in IPCollection)
                            {
                                Match match = Regex.Match(adress, IPv4RegularExpression);
                                if (match.Success) { IPv4AddressList.Add(adress); break; }
                            }
                        }
                    }
                }
            }

            if (IPv4AddressList.Count > 0) return IPv4AddressList.ToArray(); else return null;
        }

        private void buttonExecuteCommand_Click(object sender, EventArgs e)
        {
            try
            {
                using (FaceId Client = new FaceId(textBoxDeviceIP.Text, Convert.ToInt32(textBoxDevicePort.Text)))
                {
                    // 设置通信密钥
                    Client.SecretKey = textBoxSecretKey.Text.Trim();

                    string Answer;
                    FaceId_ErrorCode ErrorCode = Client.Execute(textBoxCommand.Text, out Answer, DeviceCodePage);
                    if (ErrorCode == FaceId_ErrorCode.Success)
                    {
                        textBoxAnswer.Text = Answer;
                    }
                    else
                    {
                        textBoxAnswer.Text = Answer;
                        MessageBox.Show("错误代码：" + ErrorCode.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCommandHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("根目录下查看【汉王科技面部识别终端脱机通讯开发指南V2.3.pdf】/n简单命令：获取设备信息：GetDeviceInfo()可用来判断设备是否在线");
        }
    }
}
