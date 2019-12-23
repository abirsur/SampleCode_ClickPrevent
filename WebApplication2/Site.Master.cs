using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class SiteMaster : MasterPage
    {
        //private void InitializeComponent()
        //{
        //    this.PreRender += new System.EventHandler(this.OnClickPageEventHandler);
        //}

        //public void OnClickPageEventHandler(object sender, EventArgs e)
        //{
                //need to implement the same javascript method here
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckIllegalAttempt(sender);
        }

        private void CheckIllegalAttempt(object sendr) {
            if (Page.IsPostBack)
            {
                MasterPage master = (MasterPage)sendr;
                ContentPlaceHolder mainContent = (ContentPlaceHolder)master.FindControl("MainContent");
                foreach (Control ctrl in mainContent.Controls)
                {
                    Type controlType = ctrl.GetType();
                    if (string.Equals(controlType.Name, "button", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Button btn = (Button)ctrl;
                        string clickedElement = base64Decode(hdnClickedElemnet.Value);
                        if (string.Equals(clickedElement, btn.ClientID, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (!btn.Enabled)
                                Response.Redirect("~/Error.aspx?msg=9", true);
                        }
                    }
                }
            }
        }

        public string base64Decode(object obj)
        {
            try
            {
                string data = obj != null ? obj.ToString() : string.Empty;
                if (string.IsNullOrEmpty(data)) return string.Empty;
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();

                byte[] todecode_byte = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Decode" + e.Message);
            }
        }
    }

}