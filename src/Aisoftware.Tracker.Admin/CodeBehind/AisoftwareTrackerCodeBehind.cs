using Microsoft.AspNetCore.Http;
using Aisoftware.Tracker.Borders;
using Aisoftware.Tracker.UseCases.Handlers;
using System;
using System.Collections.Generic;

namespace Aisoftware.Tracker.Admin.CodeBehind
{
    public class AisoftwareTrackerCodeBehind
    {
        public Auth Auth;
        private HttpRequest _request;
        private HttpResponse _response;
        private HandlerFactory _handlerFactory;

        private readonly string ERROR_MESSAGE = "ErrorMessage";
        private readonly string WARNING_MESSAGE = "WarningMessage";
        private readonly string SUCCESS_MESSAGE = "SuccessMessage";
        private readonly string USER_AGENT = "User-Agent";
        private readonly int ONE_THOUSAND = 1000;
        private const string JS_CSS_VERSION = "v1.0.3.0";
        

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
            value = value?.ToString() + string.Empty;

            _response.Cookies.Delete(key);

            CookieOptions options = new CookieOptions();
            options.IsEssential = true;

            if (daysToExpire != null)
            {
                options.IsEssential = true;
                options.Expires = DateTime.Now.AddDays(daysToExpire.Value);
            }
            else
            {
                options.Expires = DateTime.Now.AddDays(ONE_THOUSAND);
            }

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
            SaveValue(ERROR_MESSAGE, msg, null);
        }

        public string GetErro()
        {
            return GetValueAndErase(ERROR_MESSAGE);
        }

        public void AdicionaWarning(string msg)
        {
            SaveValue(WARNING_MESSAGE, msg, null);
        }

        public string GetWarning()
        {
            return GetValueAndErase(WARNING_MESSAGE);
        }

        public void AdicionaSuccess(string msg)
        {
            SaveValue(SUCCESS_MESSAGE, msg, null);
        }

        public string GetSuccess()
        {
            return GetValueAndErase(SUCCESS_MESSAGE);
        }

        public string GetValueAndErase(string key)
        {
            string response = _valores.ContainsKey(key) ? _valores[key] : _request.Cookies[key];

            _valores.Remove(key);
            _response.Cookies.Delete(key);
            return response;
        }

        public string GetBrowser()
        {
            return _request.Headers[USER_AGENT];
        }

        public static string JsCssVersion()
        {
            return JS_CSS_VERSION;
        }
    }
}
