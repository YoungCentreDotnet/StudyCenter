using LinqToDB;
using StudyCenter.Backend.DataLayer;
using StudyCenter.Backend.Models;

namespace StudyCenter.Backend.Repositories.Account
{
    public class AdminAccountService : IAdminAccountService
    {
        private readonly StudyDbContext _studyDb;

        public AdminAccountService(StudyDbContext studyDb)
        {
            _studyDb = studyDb;
        }

        public async Task<StateResponse<IEnumerable<Admin>>> GetAllDataAsync()
        {
            StateResponse<IEnumerable<Admin>> stateResponse = new StateResponse<IEnumerable<Admin>>();
            try
            {
                var entityData = await _studyDb.Admins.ToListAsync();
                if (stateResponse is null)
                {
                    stateResponse.Code = (int)StatusResponse.Not_Found;
                    stateResponse.Message = nameof(StatusResponse.Not_Found);
                    stateResponse.Data = entityData;

                }
                if (stateResponse is not null)
                {
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = entityData;

                }
            }
            catch
            {

                stateResponse.Code = (int)StatusResponse.Success;
                stateResponse.Message = nameof (StatusResponse.Success);
                stateResponse.Data = null;
            }
            return stateResponse;
        }

        public async Task<StateResponse<Admin>> GetByIdAsync(int id)
        {
            StateResponse<Admin> stateResponse = new StateResponse<Admin>();
            try
            {
                var entityData = await _studyDb.Admins.FirstOrDefaultAsync(p => p.Id == id);
                if (entityData is null)
                {
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = entityData;

                }
                if (entityData is not null)
                {
                    stateResponse.Code = (int)StatusResponse.Not_Found;
                    stateResponse.Message = nameof(StatusResponse.Not_Found);
                    stateResponse.Data = new Admin();

                }

            }
            catch
            {
                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
                stateResponse.Data = new Admin();

            }
            return stateResponse;
        }

        public Task<StateResponse<Admin>> LogInAsync(string login, string password)
        {
            throw new NotImplementedException();
        }

        public Task<StateResponse<bool>> LogOutAsync(string login, string password)
        {
            throw new NotImplementedException();
        }

        public Task<StateResponse<Admin>> SignUpAsync(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
