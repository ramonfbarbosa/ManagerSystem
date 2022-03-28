using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserService(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<UserDTO>> Get()
        {
            var allUsers = await _repository.Get();

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> GetById(long id)
        {
            var user = await _repository.GetById(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _repository.GetByEmail(email);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var allUsers = await _repository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var allUsers = await _repository.SearchByName(name);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _repository.GetByEmail(userDTO.Email);

            if (userExists != null)
                throw new DomainException("Já existe um usuário cadastrado com este email informado");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var createdUser = await _repository.Create(user);

            return _mapper.Map<UserDTO>(createdUser);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _repository.GetById(userDTO.Id);

            if (userExists == null)
                throw new DomainException("Não existe nenhum usuário com este id informado");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var updatedUser = await _repository.Update(user);

            return _mapper.Map<UserDTO>(updatedUser);
        }

        public async Task Remove(long id)
        {
            await _repository.Delete(id);
        }
    }
}