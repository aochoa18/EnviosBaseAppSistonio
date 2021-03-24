
using Enviosbase.Data;
using Enviosbase.Model;

namespace Enviosbase.Business
{
    public class RecoveryPasswordBusiness
    {
        public RecoveryPasswordModel Create(RecoveryPasswordModel item)
        {
            return new RecoveryPasswordDataMapper().Create(item);
        }

        public void Update(RecoveryPasswordModel item)
        {
            RecoveryPasswordDataMapper RecoveryPasswordDM = new RecoveryPasswordDataMapper();
            RecoveryPasswordDM.Update(item);
        }

        public RecoveryPasswordModel GetByToken(string Token)
        {
            return new RecoveryPasswordDataMapper().GetByToken(Token);
        }
    }
}

