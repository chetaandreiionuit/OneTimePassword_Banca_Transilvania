using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTP_Banca_Transilvania.Services
{
    internal interface OTPServiceInterface
    {
        OtpPasswordTable GenerateOTP(String CustomerID);

        bool ValidateOTP(String Otp);
    }
}
