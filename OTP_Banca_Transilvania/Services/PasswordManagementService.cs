
using OTP_Banca_Transilvania.Repository;
using System;
using System.Text;

namespace OTP_Banca_Transilvania.Services
{
    public class PasswordManagementService
    {
        private OtpRepository repo = new OtpRepository();
        Random rnd = new Random();
        public OtpPasswordTable GenerateOTP(String CustomerID)
        { 
            int IdCustomer = Int32.Parse(CustomerID);
            String newPassword = this.BuildOTP(CustomerID, DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            OtpPasswordTable Password = new OtpPasswordTable(rnd.Next(1,10000),IdCustomer, newPassword, DateTime.Now);
            repo.OtpPassSave(Password);
            return Password;
        }

        public bool ValidateOTP(String Otp)
        {
            bool isPassed;
            String PassToDecode = Otp.Substring(3);
            String OtpDecoded = decode(PassToDecode);
            String datetimeGenerated = OtpDecoded.Substring(0, 19);
            String userId = OtpDecoded.Substring(19);
            var whenOtpWasGenerated = DateTime.Parse(datetimeGenerated);
            var now = DateTime.Now;
            int totalSec = (int)(now - whenOtpWasGenerated).TotalSeconds;
            if (totalSec <= 30)
            {
                isPassed = true;
            }
            else
            {
                isPassed = false;
            }

            return isPassed;
        }

        public String BuildOTP(String CustomerID, String time)
        {
            String prefix = "BT.";
            String bodypass = time + CustomerID;
            return prefix + encode(bodypass);
        }

        private String encode(String textToEncode)
        {
            byte[] bytes;
            bytes = Encoding.ASCII.GetBytes(textToEncode);
            String PassBase64 = Convert.ToBase64String(bytes);
            return PassBase64;
        }
        private String decode(String textToDecode)
        {
            byte[] bytes;
            bytes = Convert.FromBase64String(textToDecode);
            String decodedPass = Encoding.ASCII.GetString(bytes);
            return decodedPass;
        }
    }
}