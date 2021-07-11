using Microsoft.AspNetCore.Http;
using Aisoftware.Tracker.Borders;
using Aisoftware.Tracker.UseCases.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aisoftware.Tracker.Admin.CodeBehind
{
    public class AisoftwareTrackerCodeBehind
    {
        public Auth Auth;
        private HttpRequest _request;
        private HttpResponse _response;
        private HandlerFactory _handlerFactory;

        public AisoftwareTrackerCodeBehind(HttpRequest request, HttpResponse response, HandlerFactory handlerFactory)
        {
            _request = request;
            _response = response;
            _handlerFactory = handlerFactory;

            Auth = new Auth(this, handlerFactory);
        }

        private Dictionary<string, string> _valores = new Dictionary<string, string>();

        public void SaveValue(string key, object value, int? daysToExpire)
        {
            value = value?.ToString() + "";

            _response.Cookies.Delete(key);

            CookieOptions options = new CookieOptions();
            options.IsEssential = true;

            if (daysToExpire != null)
            {
                options.IsEssential = true;
                options.Expires = DateTime.Now.AddDays(daysToExpire.Value);
            }
            else
                options.Expires = DateTime.Now.AddDays(1000);

            _response.Cookies.Append(key, value.ToString(), options);

            if (_valores.ContainsKey(key))
                _valores[key] = value.ToString();
            else
                _valores.Add(key, value.ToString());
        }

        public string GetValue(string key)
        {
            if (_valores.ContainsKey(key))
                return _valores[key];
            else
                return _valores[key] = _request.Cookies[key];
        }

        public void AdicionaErro(string msg)
        {
            SaveValue("ErrorMessage", msg, null);
        }

        public string GetErro()
        {
            return GetValueAndErase("ErrorMessage");
        }

        public void AdicionaWarning(string msg)
        {
            SaveValue("WarningMessage", msg, null);
        }

        public string GetWarning()
        {
            return GetValueAndErase("WarningMessage");
        }

        public void AdicionaSuccess(string msg)
        {
            SaveValue("SuccessMessage", msg, null);
        }

        public string GetSuccess()
        {
            return GetValueAndErase("SuccessMessage");
        }

        public string GetValueAndErase(string key)
        {
            string ret;
            if (_valores.ContainsKey(key))
                ret = _valores[key];
            else
                ret = _request.Cookies[key];

            _valores.Remove(key);
            _response.Cookies.Delete(key);
            return ret;
        }

        public string GetBrowser()
        {
            return _request.Headers["User-Agent"];
        }

        public static string JsCssVersion()
        {
            return "v1.0.3.0";
        }
    }
}
