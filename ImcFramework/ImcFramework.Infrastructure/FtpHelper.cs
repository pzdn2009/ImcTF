using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Infrastructure
{
    public class FtpData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string HostAddress { get; set; }
        public string RemoteFilePath { get; set; }
    }

    public class FtpHelper
    {
        private string hostAddress;
        private string remoteFilePath;
        private string username;
        private string password;
        private string ftpURI;

        public FtpHelper(FtpData ftpData)
            : this(ftpData.HostAddress, ftpData.RemoteFilePath, ftpData.Username, ftpData.Password)
        {
        }

        public FtpHelper(string hostAddress, string remoteFilePath, string username, string password)
        {
            this.hostAddress = hostAddress;
            this.remoteFilePath = remoteFilePath;
            this.username = username;
            this.password = password;

            if (!string.IsNullOrEmpty(remoteFilePath))
            {
                if (remoteFilePath.First() == '/')
                    remoteFilePath = remoteFilePath.Remove(0, 1);
                if (remoteFilePath.Last() == '/')
                    remoteFilePath = remoteFilePath.Substring(0, remoteFilePath.Length - 1);

                ftpURI = "ftp://" + hostAddress + "//" + remoteFilePath;
            }
            else
                ftpURI = "ftp://" + hostAddress;
        }

        public void Upload(FileInfo fileInfo)
        {
            string uri = ftpURI + "/" + fileInfo.Name;

            var ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

            ftpRequest.Credentials = new NetworkCredential(username, password);
            ftpRequest.KeepAlive = false;
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
            ftpRequest.UseBinary = true;
            ftpRequest.ContentLength = fileInfo.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInfo.OpenRead();

            var sm = ftpRequest.GetRequestStream();
            contentLen = fs.Read(buff, 0, buffLength);
            while (contentLen != 0)
            {
                sm.Write(buff, 0, contentLen);
                contentLen = fs.Read(buff, 0, buffLength);
            }
            sm.Close();
            fs.Close();
        }

        public void Upload(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);

            Upload(fileInfo);
        }

        public void Download(string remoteFileName, string localFilePath)
        {
            FileStream outputStream = new FileStream(Path.Combine(localFilePath, remoteFileName), FileMode.Create);

            var ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(Path.Combine(ftpURI, remoteFileName)));
            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
            ftpRequest.UseBinary = true;
            ftpRequest.Credentials = new NetworkCredential(username, password);

            var response = (FtpWebResponse)ftpRequest.GetResponse();
            Stream sm = response.GetResponseStream();
            long cl = response.ContentLength;
            int bufferSize = 2048;
            byte[] buffer = new byte[bufferSize];

            var readCount = sm.Read(buffer, 0, bufferSize);
            while (readCount > 0)
            {
                outputStream.Write(buffer, 0, readCount);
                readCount = sm.Read(buffer, 0, bufferSize);
            }

            sm.Close();
            outputStream.Close();
            response.Close();
        }

        public string[] GetFilesDetailList()
        {
            var result = new StringBuilder();

            var ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
            ftp.Credentials = new NetworkCredential(username, password);
            ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            WebResponse response = ftp.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);

            string line = reader.ReadLine();
            while (line != null)
            {
                result.Append(line);
                result.Append("\n");
                line = reader.ReadLine();
            }
            result.Remove(result.ToString().LastIndexOf("\n"), 1);
            reader.Close();
            response.Close();
            return result.ToString().Split('\n');
        }

        public string[] GetFileList(string mask)
        {
            var result = new StringBuilder();

            var reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
            reqFTP.UseBinary = true;
            reqFTP.Credentials = new NetworkCredential(username, password);
            reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;

            WebResponse response = reqFTP.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);

            string line = reader.ReadLine();
            while (line != null)
            {
                if (mask.Trim() != string.Empty && mask.Trim() != "*.*")
                {
                    string mask_ = mask.Substring(0, mask.IndexOf("*"));
                    if (line.Substring(0, mask_.Length) == mask_)
                    {
                        result.Append(line);
                        result.Append("\n");
                    }
                }
                else
                {
                    result.Append(line);
                    result.Append("\n");
                }
                line = reader.ReadLine();
            }
            result.Remove(result.ToString().LastIndexOf('\n'), 1);
            reader.Close();
            response.Close();
            return result.ToString().Split('\n');
        }

        public string[] GetDirectoryList()
        {
            string result = string.Empty;
            foreach (string str in GetFilesDetailList())
            {
                int dirPos = str.IndexOf("<DIR>");
                if (dirPos > 0)
                {
                    /*判断 Windows 风格*/
                    result += str.Substring(dirPos + 5).Trim() + "\n";
                }
                else if (str.Trim().Substring(0, 1).ToUpper() == "D")
                {
                    /*判断 Unix 风格*/
                    string dir = str.Substring(54).Trim();
                    if (dir != "." && dir != "..")
                    {
                        result += dir + "\n";
                    }
                }
            }

            char[] n = new char[] { '\n' };
            return result.Split(n);
        }

        public bool DirectoryExist(string remoteDirectoryName)
        {
            foreach (string str in GetDirectoryList())
            {
                if (str.Trim() == remoteDirectoryName.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        public bool FileExist(string remoteFileName)
        {
            foreach (string str in GetFileList("*.*"))
            {
                if (str.Trim() == remoteFileName.Trim())
                {
                    return true;
                }
            }
            return false;
        }
    }
}