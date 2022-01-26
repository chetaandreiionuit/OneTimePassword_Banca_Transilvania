using OTP_Banca_Transilvania.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTP_Banca_Transilvania.Repository
{
    public class OtpRepository : OtpRepositoryInterface
    {
        private OtpPassEntities2 context = new OtpPassEntities2();
        public void OtpPassSave(OtpPasswordTable passToSave)
        {
            try
            {
                context.OtpPasswordTables.Add(passToSave);
                context.SaveChanges();
            }catch(Exception ex)
            {
                throw new EntitySaveToDatabaseException("Something when wrong at Repo -> save to DB");
            }
        }
    }
}