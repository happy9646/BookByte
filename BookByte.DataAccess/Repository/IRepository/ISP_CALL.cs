using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookByte.DataAccess.Repository.IRepository
{
    public interface ISP_CALL:IDisposable 
    {

        // Executes a stored procedure and returns a list using Dapper Query.
        // DynamicParameters are used to pass parameters.   
        void Execute(string procedureName, DynamicParameters param= null);
        T Single<T>(string procedureName, DynamicParameters param = null);
        T OneRecord<T>(string procedureName, DynamicParameters param = null);
        IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null);
        // When we use the Tuple, we can return two different types of lists from the same stored procedure.
        Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null);
    }
}
