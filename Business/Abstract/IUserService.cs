using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<Userr>> GetAll();
        IResult Add(Userr user);
        IResult Delete(Userr user);
        IResult Update(Userr user);
        //Refactor edilecek.
        List<OperationClaim> GetClaims(Userr user);
        Userr GetByMail(string email);
    }
}
