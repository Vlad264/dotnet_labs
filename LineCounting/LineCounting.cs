using System;
using System.IO;

namespace LineCounting
{
    class LineCounting
    {
        private readonly string singleComment = "//";
        private readonly string multiCommentStart = "/*";
        private readonly string multiCommentEnd = "*/";

        private readonly string format;
        private int result;

        public LineCounting(string format)
        {
            this.format = format;
        }

        public int Count()
        {
            result = 0;
            SearchDir(new System.IO.DirectoryInfo(System.IO.Directory.GetCurrentDirectory()));
            return result;
        }

        private void SearchDir(System.IO.DirectoryInfo di)
        {
            System.IO.FileInfo[] subFiles = di.GetFiles(format);
            foreach (var file in subFiles)
            {
                CountLines(file);
            }

            System.IO.DirectoryInfo[] subDir = di.GetDirectories();
            foreach (var dir in subDir)
            {
                SearchDir(dir);
            }
        }

        private void CountLines(System.IO.FileInfo file)
        {
            int count = 0;
            string str;
            using (StreamReader reader = file.OpenText())
            {
                while ((str = reader.ReadLine()) != null)
                {
                    var trim = str.Trim();
                    if (trim == "" || trim.StartsWith(singleComment)) {
                        continue;
                    }
                    if (trim.Contains(multiCommentStart))
                    {
                        if (trim.IndexOf(multiCommentStart) != 0)
                        {
                            ++count;
                        }
                        while ((str = reader.ReadLine()) != null && !str.Trim().Contains(multiCommentEnd));
                        if (str.Trim().IndexOf(multiCommentEnd) != 0)
                        {
                            ++count;
                        }
                        continue;
                    }
                    ++count;
                }
            }
            Console.WriteLine("In file {0}: {1} lines", file.Name, count);
            result += count;
        }
    }
}
