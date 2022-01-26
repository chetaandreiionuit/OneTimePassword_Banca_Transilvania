using Microsoft.VisualStudio.TestTools.UnitTesting;
using OTP_Banca_Transilvania.Services;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OTP_Banca_Transilvania.Services.Tests
{
    [TestClass()]
    public class PasswordManagementServiceTests
    {
        [TestMethod()]
        public void GenerateOTP_TestPassIsSpecificFormat_ReturnTrue()
        {
            PasswordManagementService service = new PasswordManagementService();
            var OtpPass = service.BuildOTP("12", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            var PassPrefix = OtpPass.Substring(0, 3);
            var result = PassPrefix.Equals("BT.");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GenerateOTP_TestPassase64_ReturnTrue()
        {
            PasswordManagementService service = new PasswordManagementService();
            var OtpPass = service.BuildOTP("12", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")); ;
            var otpWithNotPrefix = OtpPass.Substring(3);
            otpWithNotPrefix = otpWithNotPrefix.Trim();
            bool isBase64 = (otpWithNotPrefix.Length % 4 == 0) && Regex.IsMatch(otpWithNotPrefix, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
            Assert.IsTrue(isBase64);
        }

        [TestMethod()]
        public void ValidateOTP_TestPassForTime_ReturnTrue()
        {
            PasswordManagementService service = new PasswordManagementService();
            String otpToPass =service.BuildOTP("12", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            var result = service.ValidateOTP(otpToPass);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ValidateOTP_TestNotPass_ReturnFalse()
        {
            PasswordManagementService service = new PasswordManagementService();
            String otpToPass = service.BuildOTP("12", DateTime.Now.AddSeconds(-40).ToString("MM/dd/yyyy HH:mm:ss"));
            var result = service.ValidateOTP(otpToPass);
            Console.Write(result);
            Assert.IsFalse(result);

        }



    }
}