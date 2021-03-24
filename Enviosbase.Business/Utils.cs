using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Enviosbase.Business
{
    public static class Utils
    {

        public static string MessageBox(string Title, string Message, string urlRedirect, string type)
        {
            string redirect = @"""onclick"":null,";
            string dismiss = "true";
            if (!string.IsNullOrEmpty(urlRedirect))
            {
                redirect = @"""onclick"": function(){ window.location.href='" + urlRedirect + @"' },";
                Message += @"<br /><br /><button type=""button"" class=""btn clear"">OK</button>";
                dismiss = "false";
            }
            return @"<script>
            toastr.options = {
                ""closeButton"": " + dismiss + @",
                ""debug"": false,
                ""newestOnTop"": false,
                ""progressBar"": false,
                ""positionClass"": ""toast-top-right"",
                ""preventDuplicates"": false,
                " + redirect + @"
                ""showDuration"": ""300"",
                ""hideDuration"": ""1000"",
                ""timeOut"": 0,
                ""extendedTimeOut"": 0,
                ""showEasing"": ""swing"",
                ""hideEasing"": ""linear"",
                ""showMethod"": ""fadeIn"",
                ""hideMethod"": ""fadeOut"",
                ""tapToDismiss"": false
            }
            $(function(){
                toastr['" + type + @"']('" + Message + @"', '" + Title + @"')
            });
            </script>";
        }

        public static void DisableForm(ControlCollection ctrls)
        {
            foreach (System.Web.UI.Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Enabled = false;
                if (ctrl is Button)
                    ((Button)ctrl).Enabled = false;
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).Enabled = false;
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Enabled = false;
                else if (ctrl is RadioButton)
                    ((RadioButton)ctrl).Enabled = false;
                else if (ctrl is HtmlInputButton)
                    ((HtmlInputButton)ctrl).Disabled = true;
                else if (ctrl is HtmlInputText)
                    ((HtmlInputText)ctrl).Disabled = true;
                else if (ctrl is HtmlSelect)
                    ((HtmlSelect)ctrl).Disabled = true;
                else if (ctrl is HtmlInputCheckBox)
                    ((HtmlInputCheckBox)ctrl).Disabled = true;
                else if (ctrl is HtmlInputRadioButton)
                    ((HtmlInputRadioButton)ctrl).Disabled = true;

                DisableForm(ctrl.Controls);
            }
        }

        public static string GetSHA512(string text)
        {
            byte[] hashValue;
            byte[] message = Encoding.ASCII.GetBytes(text);
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:X2}", x);
            }
            return hex;
        }


    }
}

