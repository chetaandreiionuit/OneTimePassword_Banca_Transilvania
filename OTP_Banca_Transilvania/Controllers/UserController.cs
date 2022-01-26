using OTP_Banca_Transilvania.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace OTP_Banca_Transilvania.Controllers
{
    public class UserController : Controller
    {
        OTPServiceInterface otp = new OTPService();
        [HandleError]
        public ActionResult Home()
        {
            return View();
        }
        [HandleError]
        public ActionResult GenerateOTP(String ID)
        {
            OtpPasswordTable otpPAss = otp.GenerateOTP(ID);
            ViewBag.Pass = otpPAss.OTPPass;
            return View(otpPAss);
        }
        [HandleError]
        public ActionResult ValidateOTP(String OTP)
        {
            if (OTP == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            bool pased = otp.ValidateOTP(OTP);
            ViewBag.Passed = pased;
            return View(pased);
        }
    }
}