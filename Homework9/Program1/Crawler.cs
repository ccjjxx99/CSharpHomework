using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;

namespace Program1
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;

        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();

            string startUrl1 = "http://www.cnblogs.com/dstang2000/";
            string startUrl2 = "https://www.cnblogs.com/dstang2000/archive/";
            

            myCrawler.urls.Add(startUrl1, false);       //加入初始页面
            myCrawler.urls.Add(startUrl2, false);

            Parallel.Invoke(new Action[] {              //开始爬行
                ()=>myCrawler.Crawl(),
                ()=>myCrawler.Crawl()
            });    
        }

        private void Crawl()
        {
            Console.WriteLine("爬虫" + Thread.CurrentThread.ManagedThreadId + "开始爬行了...");
            while (true)
            {
                string current = null;
                foreach(string url in urls.Keys)    //找到一个还没有下载过的链接
                {
                    if ((bool)urls[url]) continue;  //已经下载过的，不再下载
                    current = url;
                    urls[current] = true;
                    break;
                }
                if (current == null || count > 10) break;

                Console.WriteLine("爬虫" + Thread.CurrentThread.ManagedThreadId + "爬行" + current + "页面！");

                string html = Download(current);    //下载
                
                Prase(html);                        //解析，并加入新的链接
            }
            Console.WriteLine("爬虫" + Thread.CurrentThread.ManagedThreadId + "爬行结束");
        }

        public string Download(string url)
        {
            try
            {
                WebClient webClient = new WebClient
                {
                    Encoding = Encoding.UTF8
                };
                string html = webClient.DownloadString(url);

                string fileName = count.ToString() + ".html";
                count++;
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Prase(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach(Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim
                    ('"', '\"', '#', ' ', '>');
                if (strRef.Length == 0) continue;

                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
