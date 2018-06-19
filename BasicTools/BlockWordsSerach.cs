/**
 * 作者：GAloliy
 * 完成日期：2018/5/10
 * 作用：屏蔽关键字（屏蔽词）,封装了FindWords。可以指定关键词,需要删除原ini文件并放一个指定路径名称的源文本,重新调用即可自动编译ini文件。TODO：该类读写文件并发性不是很好
 **/

using System;
using System.Collections.Generic;
using FindWords;

namespace BasicTools
{
    public sealed class BlockWordsSerach
    {
        //StringSearch searchBlockWords = new StringSearch();
        static StringSearchEx searchBlockWordsEx = null;
        static BlockWordsSerach instance = null;
        static readonly object padlock = new object();

        private BlockWordsSerach() { }

        //此处采用了double check,稍有思考不周就有可能报错。此种方式不能在Java中工作。
        private static BlockWordsSerach Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        if (searchBlockWordsEx == null)
                            searchBlockWordsEx = new StringSearchEx();

                        instance = new BlockWordsSerach();

                    }
                }
                    
                return instance;
            }
        }
        /// <summary>
        ///  获取实例（获取失败返回值为null）
        /// </summary>
        /// <returns></returns>
        public static BlockWordsSerach GetInstance()
        {
            BlockWordsSerach wordsSerach;
            if (instance == null)
            {
                wordsSerach = Instance;
                init();
                return wordsSerach;
            }
            else
                return Instance;
        }
        //初始化
        private static bool init()   
        {

            if (FileOperation.IsFileExists(Config.BadWords))
            {
                searchBlockWordsEx.Load(Config.BadWords);
                return true;
            }
            else
            {
                Log.WriteLog(new Error(@"找不到过滤文件!尝试重新编译文件,请把原文件放在WebGA\Controls\Tools下")); //错误类有待优化
                string path = AppDomain.CurrentDomain.BaseDirectory + @"Controls\Tool\BlockWords.txt";

                if (FileOperation.IsFileExists(path))    //下面操作可能会遇到WebServer.exe占用文件的情况，TODO:该用FileShare 异步读写文件。
                {
                    try
                    {
                        searchBlockWordsEx.Save(path);
                        searchBlockWordsEx.Load(Config.BadWords);
                    }
                    catch (Exception e)
                    {
                        Log.WriteLog(new Error("文件操作失败", "文件操作失败,可能是因为WebServer占用文件导致。", e));
                        return false;
                    }
                       
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 查找第一个关键字
        /// </summary>
        /// <returns></returns>
        public string FindFrist(string text)
        {
            return searchBlockWordsEx.FindFirst(text);
        }
        /// <summary>
        /// 查询所有关键字
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public List<string> FindAll(string text)
        {
            return searchBlockWordsEx.FindAll(text);
        }
        /// <summary>
        /// 判断内容是否包含关键字
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool IsBlockWord(string text)
        {
            return searchBlockWordsEx.ContainsAny(text);
        }

        /// <summary>
        /// 文本替换所有关键字为‘*’
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Replace(string text)
        {
            return searchBlockWordsEx.Replace(text);
        }
        /// <summary>
        /// 文本替换所有关键字
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="replaceChar">要替换的字符</param>
        /// <returns></returns>
        public string Replace(string text,char replaceChar)
        {
            return searchBlockWordsEx.Replace(text, replaceChar);
        }



        /*public List<string> ReadBadWord()
        {
            List<string> list = new List<string>();
            StreamReader sw = new StreamReader(File.OpenRead(Config.BadWords));

            string key = sw.ReadLine();
            while (key != null)
            {
                if (key != string.Empty)
                {
                    list.Add(key);
                }
                key = sw.ReadLine();
            }

            searchBlockWords.SetKeyWords(list);

            list = list.OrderBy(q => q).ToList();
            //var str = string.Join("|", list);
            return list;
        }*/
    }
}
