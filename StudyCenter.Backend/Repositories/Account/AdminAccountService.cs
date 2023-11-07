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
                    stateResponse.Code = (int)StatusCodes.Status404NotFound;
                    stateResponse.Message = nameof(StatusCodes.Status404NotFound);
                    stateResponse.Data = entityData;

                }
                if (stateResponse is not null)
                {
                    stateResponse.Code = (int)StatusCodes.Status200OK;
                    stateResponse.Message = nameof(StatusCodes.Status200OK);
                    stateResponse.Data = entityData;

                }
            }
            catch
            {

                stateResponse.Code = (int)StatusCodes.Status404NotFound;
                stateResponse.Message = nameof(StatusCodes.Status404NotFound);
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
                    stateResponse.Code = (int)StatusCodes.Status200OK;
                    stateResponse.Message = nameof(StatusCodes.Status200OK);
                    stateResponse.Data = entityData;

                }
                if (entityData is null)
                {
                    stateResponse.Code = (int)StatusCodes.Status404NotFound;
                    stateResponse.Message = nameof(StatusCodes.Status404NotFound);
                    stateResponse.Data = new Admin();

                }

            }
            catch
            {
                stateResponse.Code = (int)StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
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

                    state.Code = (int)StatusCodes.Status200OK;
                    state.Message = nameof(StatusCodes.Status200OK);
                    state.Data = entityData;

                }
                if (state is null)
                {
                    state.Code = (int)StatusCodes.Status404NotFound;
                    state.Message = nameof(StatusCodes.Status404NotFound);
                    state.Data = entityData;


                }


            }
            catch
            {
                state.Code = (int)StatusCodes.Status500InternalServerError;
                state.Message = nameof(StatusCodes.Status500InternalServerError);
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
                    stateResponse.Code = (int)StatusCodes.Status202Accepted;
                    stateResponse.Message = nameof(StatusCodes.Status202Accepted);
                    stateResponse.Data = true;

                }
                if (entityData is null)
                {
                    stateResponse.Code = (int)StatusCodes.Status202Accepted;
                    stateResponse.Message = nameof(StatusCodes.Status404NotFound);
                    stateResponse.Data = false;

                }

            }
            catch
            {
                stateResponse.Code = (int)StatusCodes.Status500InternalServerError;
                stateResponse.Message = nameof(StatusCodes.Status500InternalServerError);
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
                    stateResponse.Code = (int)StatusCodes.Status201Created;
                    stateResponse.Message = nameof(StatusCodes.Status201Created);
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

        public Task<StateResponse<bool>> UpdateAsync(Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}
