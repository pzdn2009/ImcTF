using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImcFramework.Infrastructure
{
    public static class FileExtension
    {
        public static void CopyTo(this DirectoryInfo sourceDir, DirectoryInfo targetDir)
        {
            DirectoryInfo[] childrenDirs = sourceDir.GetDirectories();
            DirectoryInfo childTargetDir;
            foreach (DirectoryInfo dir in childrenDirs)
            {
                childTargetDir = targetDir.CreateSubdirectory(dir.Name);
                CopyTo(dir, childTargetDir);
            }
            FileInfo[] childrenFiles = sourceDir.GetFiles();
            foreach (FileInfo file in childrenFiles)
            {
                file.CopyTo(Path.Combine(targetDir.FullName, file.Name));
            }
        }

        public static bool FileExist(this string fileName)
        {
            return File.Exists(fileName);
        }

        public static bool DirectoryExist(this string dirName)
        {
            return Directory.Exists(dirName);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="str">文件路径</param>
        public static void Delete(this string str)
        {
            File.Delete(str);
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="str">目录地址</param>
        public static void CreateDirectory(this string str)
        {
            Directory.CreateDirectory(str);
        }
    }
}
