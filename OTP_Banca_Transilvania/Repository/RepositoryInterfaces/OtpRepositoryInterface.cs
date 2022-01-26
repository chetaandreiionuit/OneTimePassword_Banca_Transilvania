using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTP_Banca_Transilvania.Repository
{
    public interface OtpRepositoryInterface
    {
        void OtpPassSave(OtpPasswordTable passToSave);

    }
}