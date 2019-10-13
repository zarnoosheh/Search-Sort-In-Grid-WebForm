using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Core.SmileAdmin.Components
{
    public partial class ComPager : System.Web.UI.UserControl
    {
        public long _Count { get; set; } // تعداد مطالب
        public int _StartPage { get; set; } // شماره صفحه شروع
        public int _EndPage { get; set; } // شماره صفحه پایان
        public int _LastPage { get; set; } // شماره آخرین صفحه
        public int _PageSize { get; set; }  // تعداد نمایش مطلب در صفحه
        public int _PagerSize { get; set; }  // تعداد شمارنده صفحه
        public int _PageCount
        {
            get
            {
                if (_PageSize == 0)
                    _PageSize = 50;

                int PageCount = 0;
                if (_Count % _PageSize == 0)
                {
                    PageCount = Convert.ToInt32(_Count / _PageSize);
                }
                else
                {
                    PageCount = Convert.ToInt32(_Count / _PageSize) + 1;
                }
                return PageCount;
            }
        }  // تعداد صفحات
        public int _CurrentPage
        {
            get
            {
                if (Request.QueryString["Page"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(Request.QueryString["Page"]);
                }
            }
        }  // صفحه انتخابی
        public string _PageUrl { get; set; }  // آدرس صفحه
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _LastPage = _PageCount;
                _StartPage = 1;
                if (_PagerSize == 0)
                    return;
                _EndPage = (_PageCount > _PagerSize == true) ? _PagerSize : _PageCount;
                if (_CurrentPage != -1)
                {
                    if (_CurrentPage < _PagerSize)
                    {
                        _StartPage = 1;
                    }
                    else if (_CurrentPage == _PagerSize)
                    {
                        _StartPage = 2;
                    }
                    else
                    {
                        _StartPage = (_CurrentPage - _PagerSize) + 1;
                    }

                    if ((_PageCount - _CurrentPage) < _PagerSize)
                    {
                        _EndPage = _PageCount;
                    }
                    else
                    {
                        if (_CurrentPage < _PagerSize)
                        {
                            _EndPage = _PagerSize;
                        }
                        else
                        {
                            _EndPage = _CurrentPage + _PagerSize;
                        }
                    }
                }
            }
            catch
            {

            }

        }

        public string _GetUrl(object _Page)
        {
            string _Url = _PageUrl;
            if (string.IsNullOrEmpty(_Url))
                _Url = Request.Url.AbsoluteUri;

            Uri url = new Uri(_Url);

            var nameValues = HttpUtility.ParseQueryString(url.Query);
            nameValues.Set("Page", _Page.ToString());
            string _output = url.AbsolutePath + "?" + nameValues.ToString();

            return _output;
        }
    }
}