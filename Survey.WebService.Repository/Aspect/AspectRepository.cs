using Dapper;
using Survey.WebService.DataAccess.DbContexts.Survey;
using Survey.WebService.Models.Aspect;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.WebService.Repository
{
    public class AspectRepository : IRepository<AspectRequestDTO>, IAspectRepository
    {

        protected ISurveyContext _dbContext;
        public AspectRepository(ISurveyContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<IEnumerable<AspectRequestDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AspectRequestDTO> GetById(AspectRequestDTO id)
        {
            //using (var connection = _dbContext.CreateConnection())
            //{
            //    var id = await connection.QuerySingleAsync<int>(query, parameters);
            //    var createdCompany = new Company
            //    {
            //        Id = id,
            //        Name = company.Name,
            //        Address = company.Address,
            //        Country = company.Country
            //    };
            //    return createdCompany;
            //}
            throw new NotImplementedException();
        }


        public Task<AspectRequestDTO> Insert(AspectRequestDTO register)
        {
            //using (var connection = _dbContext.CreateConnection())
            //{
            //    var id = await connection.QuerySingleAsync<int>(query, parameters);
            //    var createdCompany = new Company
            //    {
            //        Id = id,
            //        Name = company.Name,
            //        Address = company.Address,
            //        Country = company.Country
            //    };
            //    return createdCompany;
            //}
            throw new NotImplementedException();
        }

        public Task<AspectRequestDTO> Update(AspectRequestDTO id)
        {
            throw new NotImplementedException();
        }
    }
}
