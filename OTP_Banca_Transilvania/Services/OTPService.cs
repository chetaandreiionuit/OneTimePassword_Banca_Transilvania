using System;
using System.Net.Mail;


namespace OTP_Banca_Transilvania.Services
{
    public class OTPService : OTPServiceInterface
    {
        private PasswordManagementService Pms = new PasswordManagementService();

        public OtpPasswordTable GenerateOTP(String CustomerID)
        {
            return Pms.GenerateOTP(CustomerID);
        }

        public bool ValidateOTP(string Otp)
        {
            return Pms.ValidateOTP(Otp);
            
        }
    }
}