using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MvcApplication_PMIEnglishSite
{
    /// <summary>
    /// MVC 生成静态化页面类
    /// </summary>
    public class GenerateStaticFIleAttribute : ActionFilterAttribute
    {
        #region 公共属性
        public int Expiration { get; set; }
        public string Suffix { get; set; }
        public string CacheDirectory { get; set; }
        public string FileName { get; set; }
        private string filename = "0.html";
        private string directory = "HTML\\ProductDetails";
        #endregion

        #region 构造函数
        public GenerateStaticFIleAttribute()
        {
            Expiration = 1;
             string rootdirectory= AppDomain.CurrentDomain.BaseDirectory;
             CacheDirectory = Path.Combine(rootdirectory, this.directory);
        }
        #endregion

        #region 方法
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //base.OnResultExecuted(filterContext);
            var fileInfo = GetCacheFileInfo(filterContext);
            //文件存在且过期 或者文件过期了
            if (fileInfo.Exists&&fileInfo.CreationTime.AddHours(Expiration)<DateTime.Now || !fileInfo.Exists)
            {
                var deleted = false;
                try
                {
                    if (fileInfo.Exists)
                    {
                        fileInfo.Delete();
                    }
                    deleted = true;
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
                var created = false;
                try
                {
                    if (!fileInfo.Directory.Exists)
                    {
                        fileInfo.Directory.Create();
                    }
                    created = true;
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }

                if (deleted&&created)
                {
                    FileStream fileStream = null;
                    StreamWriter streamWriter = null;
                    try
                    {
                        ViewResult viewResult = filterContext.Result as ViewResult;
                        fileStream = new FileStream(fileInfo.FullName, FileMode.CreateNew, FileAccess.Write, FileShare.None);
                        streamWriter = new StreamWriter(fileStream);
                        var viewContext = new ViewContext(filterContext.Controller.ControllerContext, viewResult.View, viewResult.ViewData, viewResult.TempData, streamWriter);
                        viewResult.View.Render(viewContext, streamWriter);
                    
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                    finally
                    {
                        if (streamWriter!=null)
                        {
                            streamWriter.Close();
                        }
                        if (fileStream!=null)
                        {
                            fileStream.Close();
                        }
                    }
                }

            }








        }
        protected virtual string GenerateKey(ControllerContext context)
        {
            //var url = context.HttpContext.Request.Url.ToString();
            var url = filename;
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }
            //这里直接返回url
            return url;
        }

        protected virtual FileInfo GetCacheFileInfo(ControllerContext context)
        {
            var fileName = string.Empty;
            if (string.IsNullOrEmpty(fileName))
            {
                var key = GenerateKey(context);
                if (!string.IsNullOrWhiteSpace(key))
                {
                    fileName = Path.Combine(CacheDirectory, string.IsNullOrWhiteSpace(Suffix) ? key : string.Format("{0}.{1}", key, Suffix));
                }
            }
            else
            {
                fileName = Path.Combine(CacheDirectory, fileName);
            }
            return new FileInfo(fileName);
        }

        #endregion


    }
}