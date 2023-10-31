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
            Admin admin = new Admin();
            List<Admin> admins = new List<Admin>(); 
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

                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof (StatusResponse.Server_Eror);
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
                if (entityData is not null)
                {
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = entityData;

                }
                if (entityData is null)
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

        public async Task<StateResponse<Admin>> LogInAsync(string login, string password)
        {

            StateResponse<Admin> state = new StateResponse<Admin>();
            try
            {
                var entityData = await _studyDb.Admins.FirstOrDefaultAsync(p => p.Login == login && p.Password == password);

                if (state is not null)
                {

                    state.Code = (int)StatusResponse.Success;
                    state.Message = nameof(StatusResponse.Success);
                    state.Data = entityData;

                }
                if (state is null)
                {
                    state.Code = (int)StatusResponse.Not_Found;
                    state.Message = nameof(StatusResponse.Not_Found);
                    state.Data = entityData;


                }


            }
            catch
            {
                state.Code = (int)StatusResponse.Server_Eror;
                state.Message = nameof(StatusResponse.Server_Eror);
                state.Data = new Admin();

                
            }

            return state;
        }


        public async Task<StateResponse<bool>> LogOutAsync(string login, string password)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {

                var entityData = await _studyDb.Admins.FirstOrDefaultAsync(p => p.Login == login && p.Password == password);

                if (entityData is not null)
                {
                    _studyDb.Admins.Remove(entityData);
                    await _studyDb.SaveChangesAsync();
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = true;

                }
                if (entityData is null)
                {
                    stateResponse.Code = (int)StatusResponse.Not_Found;
                    stateResponse.Message = nameof(StatusResponse.Not_Found);
                    stateResponse.Data = false;

                }

            }
            catch
            {
                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
                stateResponse.Data = false;

            }
            return stateResponse;
        }

        public async Task<StateResponse<Admin>> SignUpAsync(Admin entity)
        {
            StateResponse<Admin> stateResponse = new StateResponse<Admin>();
            var entityData = await _studyDb.Admins.FirstOrDefaultAsync(p => p.Id == entity.Id);
            try
            {
                if (entityData is not null)
                {

                    stateResponse.Code = StatusCodes.Status302Found;
                    stateResponse.Message = nameof(StatusCodes.Status302Found);
                    stateResponse.Data = entity;
                }
                else if(entityData is null && entity is not null)
                {
                    await _studyDb.Admins.AddAsync(entity);
                    await _studyDb.SaveChangesAsync();
                    stateResponse.Code = (int)StatusResponse.Created;
                    stateResponse.Message = nameof(StatusResponse.Created);
                    stateResponse.Data = entity;
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
    }
}
